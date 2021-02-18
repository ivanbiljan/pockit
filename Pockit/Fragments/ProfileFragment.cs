using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Helpers;
using Fragment = Android.Support.V4.App.Fragment;

namespace Pockit.Fragments 
{
    public sealed class ProfileFragment : Fragment
    {
        private ImageView _avatarImageView;
        private TextView _usernameTextView;
        
        /// <inheritdoc />
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        /// <inheritdoc />
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _avatarImageView = container.FindViewById<ImageView>(Resource.Id.imgAvatar);
            
            return inflater.Inflate(Resource.Layout.ProfileFragmentView, container, false);
        }
    }
}