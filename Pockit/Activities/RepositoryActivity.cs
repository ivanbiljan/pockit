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
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using Pockit.ViewModels;

namespace Pockit.Activities
{
    [Activity]
    [MvxActivityPresentation]
    public sealed class RepositoryActivity : MvxActivity<RepositoryActivityViewModel>
    {
        /// <inheritdoc />
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.RepositoryActivityView);
        }
    }
}