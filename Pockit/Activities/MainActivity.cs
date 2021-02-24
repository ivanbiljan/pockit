using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.App;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using Pockit.ViewModels;
using Pockit.Views;
using Xamarin.Essentials;

namespace Pockit.Activities
{
    [Activity]
    [MvxActivityPresentation]
    public sealed class MainActivity : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainView);

            ViewModel.ShowProfileViewCommand.Execute(null);
        }
    }
}