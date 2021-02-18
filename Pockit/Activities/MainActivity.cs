using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Pockit.Fragments;
using Xamarin.Essentials;

namespace Pockit.Activities
{
    [Activity(Theme = "@style/AppTheme.NoActionBar")]
    public sealed class MainActivity : AppCompatActivity 
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainView);

            if (savedInstanceState is null)
            {
                SupportFragmentManager.BeginTransaction().SetReorderingAllowed(true)
                                      .Add(Resource.Id.fragment_content, new ProfileFragment(), null).Commit();
            }
        }
    }
}