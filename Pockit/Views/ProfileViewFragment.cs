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
        private ImageView _avatarView = null!;
        private HttpClient _httpClient;

        public ProfileViewFragment()
        {
            
        }
        
        public ProfileViewFragment(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <inheritdoc />
        public override async void OnActivityCreated(Bundle savedInstanceState)
        {
            OnCreate(savedInstanceState);

            await using var avatarStream = await _httpClient.GetStreamAsync(ViewModel.Model.AvatarUrl);
            _avatarView.SetImageBitmap(await BitmapFactory.DecodeStreamAsync(avatarStream));
        }

        /// <inheritdoc />
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.RepositoryFragmentView, null);

            _avatarView = view.FindViewById<ImageView>(Resource.Id.imgAvatar)!;
            _avatarView.SetLayerType(LayerType.Software, null);

            return view;
        }
    }
}