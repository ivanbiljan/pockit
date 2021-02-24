using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.App;
using Pockit.Views;
using Xamarin.Essentials;

namespace Pockit.Activities
{
    [Activity]
    public sealed class MainActivity : AppCompatActivity 
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainView);
        }
    }
}