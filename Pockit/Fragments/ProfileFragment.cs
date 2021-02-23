using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Fragment.App;
using AndroidX.Core.Widget;

namespace Pockit.Fragments 
{
    public sealed class ProfileFragment : Fragment
    {
        private ViewGroup _viewGroupContainer;
        
        /// <inheritdoc />
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        /// <inheritdoc />
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Set up the container
            _viewGroupContainer = container;

            // Force night mode / dark theme
            AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightYes;

            // Inflate the view
            return inflater.Inflate(Resource.Layout.ProfileFragmentView, container, false);
        }
    }
}