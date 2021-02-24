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
using Android.Content.Res;
using MvvmCross.Platforms.Android.Views.Fragments;
using Pockit.ViewModels;
using AndroidX.AppCompat.App;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace Pockit.Views 
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.fragment_content)]
    public sealed class ProfileViewFragment : MvxFragment<ProfileViewModel>
    {
        /// <inheritdoc />
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.ProfileFragmentView, null);
        }
    }
}