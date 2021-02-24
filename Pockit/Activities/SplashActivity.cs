using Android.App;
using Android.Content;
using AndroidX.AppCompat.App;
using Microsoft.Extensions.DependencyInjection;
using MvvmCross.Platforms.Android.Views;
using Pockit.Core;
using Pockit.Core.Constants;
using Pockit.Core.Services.Authorization;
using Refit;

namespace Pockit.Activities
{
    [Activity(Theme = "@style/AppTheme.Splash", MainLauncher = true, NoHistory = true)]
    public sealed class SplashActivity : MvxSplashScreenActivity
    {
    }
}