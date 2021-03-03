using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using Pockit.ViewModels;

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