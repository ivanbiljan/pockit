using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Xamarin.Essentials;

namespace Pockit.Activities
{
    [Activity]
    public sealed class MainActivity : AppCompatActivity 
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProfileView);
        }
    }
}