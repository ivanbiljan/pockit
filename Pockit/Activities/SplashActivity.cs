using Android.App;
using MvvmCross.Platforms.Android.Views;

namespace Pockit.Activities
{
    [Activity(Theme = "@style/AppTheme.Splash", MainLauncher = true, NoHistory = true)]
    public sealed class SplashActivity : MvxSplashScreenActivity
    {
    }
}