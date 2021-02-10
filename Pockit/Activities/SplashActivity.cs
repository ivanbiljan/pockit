using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Microsoft.Extensions.DependencyInjection;
using Pockit.Core.Services.Authorization;

namespace Pockit.Activities
{
    [Activity(Theme = "@style/AppTheme.Splash", MainLauncher = true, NoHistory = true)]
    public sealed class SplashActivity : AppCompatActivity
    {
        /// <inheritdoc />
        public override void OnCreate(Bundle? savedInstanceState, PersistableBundle? persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            Log.Debug(nameof(SplashActivity), "SplashActivity.OnCreate");

            var serviceCollection = new ServiceCollection()
                .AddSingleton<IAuthorizationService, AuthorizationService>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            ServiceLocator.SetServiceProvider(serviceProvider);
        }

        /// <inheritdoc />
        protected override void OnResume()
        {
            base.OnResume();
            var preferences = GetPreferences(FileCreationMode.Private)!;
            if (preferences.GetString("access_token", null) is null)
            {
                // Launch LoginActivity
                StartActivity(new Intent(this, typeof(LoginActivity)));
            }
            else
            {
                // Redirect to main page
            }
        }
    }
}