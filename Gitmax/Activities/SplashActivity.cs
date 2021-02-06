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
using System.Threading.Tasks;
using Android.Support.V7.App;
using Android.Util;
using Android.Nfc;

namespace Gitmax.Activities
{
    [Activity(Theme = "@style/AppTheme.Splash", MainLauncher = true, NoHistory = true)]
    public sealed class SplashActivity : AppCompatActivity
    {
        /// <inheritdoc />
        public override void OnCreate(Bundle? savedInstanceState, PersistableBundle? persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            Log.Debug(nameof(SplashActivity), "SplashActivity.OnCreate");
        }

        /// <inheritdoc />
        protected override void OnResume()
        {
            base.OnResume();
            var preferences = GetPreferences(FileCreationMode.Private)!;
            if (preferences.GetString("access_token", null) is null)
            {
                // Launch LoginActivity
            }
            else
            {
                // Redirect to main page
            }

            //Task startupWork = new Task(SimulateStartup);
            //startupWork.Start();
        }

        // Simulates background work that happens behind the splash screen
        async void SimulateStartup() 
        {
            Log.Debug(nameof(SplashActivity), "Performing some startup work that takes a bit of time.");
            await Task.Delay(8000); // Simulate a bit of startup work.
            Log.Debug(nameof(SplashActivity), "Startup work is finished - starting MainActivity.");
        }
    }
}