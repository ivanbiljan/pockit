using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Android.Content.Res;
using Android.Graphics;
using MvvmCross.Platforms.Android.Views.Fragments;
using Pockit.ViewModels;
using AndroidX.AppCompat.App;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

using Bitmap = Android.Graphics.Bitmap;

namespace Pockit.Views 
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.fragment_content)]
    public sealed class ProfileViewFragment : MvxFragment<ProfileViewModel>
    {
        /// <inheritdoc />
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var avatarView = container.FindViewById<ImageView>(Resource.Id.imgAvatar);

            return this.BindingInflate(Resource.Layout.ProfileFragmentView, null);
        }
    }
}