using System.IO;
using System.Net.Http;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views.Fragments;
using Pockit.ViewModels;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Color = SixLabors.ImageSharp.Color;

namespace Pockit.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.fragment_content)]
    public sealed class ProfileViewFragment : MvxFragment<ProfileViewModel>
    {
        private ImageView _avatarView;

        /// <inheritdoc />
        public override async void OnActivityCreated(Bundle savedInstanceState)
        {
            OnCreate(savedInstanceState);

            var httpClient = new HttpClient(new HttpClientHandler());
            await using var avatarStream = await httpClient.GetStreamAsync(ViewModel.Model.AvatarUrl);
            using var originalImage = await Image.LoadAsync(avatarStream);
            using var croppedImage = originalImage.Clone(x => ConvertToAvatar(x, new Size(80, 80), 5));

            await using var croppedImageStream = new MemoryStream();
            await croppedImage.SaveAsync(croppedImageStream, BmpFormat.Instance);

            croppedImageStream.Position = 0;
            _avatarView.SetImageBitmap(await BitmapFactory.DecodeStreamAsync(croppedImageStream));
        }

        /// <inheritdoc />
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.ProfileFragmentView, null);
            _avatarView = view.FindViewById<ImageView>(Resource.Id.imgAvatar);
            _avatarView.SetLayerType(LayerType.Software, null);

            return view;
        }


        // This method can be seen as an inline implementation of an `IImageProcessor`:
        // (The combination of `IImageOperations.Apply()` + this could be replaced with an `IImageProcessor`)
        private static IImageProcessingContext ApplyRoundedCorners(IImageProcessingContext ctx, float cornerRadius)
        {
            var size = ctx.GetCurrentSize();
            IPathCollection corners = BuildCorners(size.Width, size.Height, cornerRadius);

            ctx.SetGraphicsOptions(new GraphicsOptions
            {
                Antialias = true,
                AlphaCompositionMode =
                    PixelAlphaCompositionMode
                        .DestOut // enforces that any part of this shape that has color is punched out of the background
            });

            // mutating in here as we already have a cloned original
            // use any color (not Transparent), so the corners will be clipped
            foreach (var c in corners)
            {
                ctx = ctx.Fill(Color.White, c);
            }

            return ctx;
        }

        private static IPathCollection BuildCorners(int imageWidth, int imageHeight, float cornerRadius)
        {
            // first create a square
            var rect = new RectangularPolygon(-0.5f, -0.5f, cornerRadius, cornerRadius);

            // then cut out of the square a circle so we are left with a corner
            IPath cornerTopLeft = rect.Clip(new EllipsePolygon(cornerRadius - 0.5f, cornerRadius - 0.5f, cornerRadius));

            // corner is now a corner shape positions top left
            //lets make 3 more positioned correctly, we can do that by translating the original around the center of the image

            var rightPos = imageWidth - cornerTopLeft.Bounds.Width + 1;
            var bottomPos = imageHeight - cornerTopLeft.Bounds.Height + 1;

            // move it across the width of the image - the width of the shape
            IPath cornerTopRight = cornerTopLeft.RotateDegree(90).Translate(rightPos, 0);
            IPath cornerBottomLeft = cornerTopLeft.RotateDegree(-90).Translate(0, bottomPos);
            IPath cornerBottomRight = cornerTopLeft.RotateDegree(180).Translate(rightPos, bottomPos);

            return new PathCollection(cornerTopLeft, cornerBottomLeft, cornerTopRight, cornerBottomRight);
        }

        // Implements a full image mutating pipeline operating on IImageProcessingContext
        private static IImageProcessingContext ConvertToAvatar(
            IImageProcessingContext processingContext,
            Size size,
            float cornerRadius)
        {
            return ApplyRoundedCorners(
                processingContext.Resize(new ResizeOptions {Size = size, Mode = ResizeMode.Crop}), cornerRadius);
        }
    }
}