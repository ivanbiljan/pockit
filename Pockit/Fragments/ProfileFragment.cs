using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.Core.Widget;
using GalaSoft.MvvmLight.Helpers;

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
            return inflater.Inflate(Resource.Layout.ProfileFragmentView, container, false);
        }
    }
}