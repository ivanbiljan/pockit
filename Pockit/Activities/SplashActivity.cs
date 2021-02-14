using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Microsoft.Extensions.DependencyInjection;
using Pockit.Core;
using Pockit.Core.Constants;
using Pockit.Core.Services.Authorization;
using Refit;

namespace Pockit.Activities
{
    [Activity(Theme = "@style/AppTheme.Splash", MainLauncher = true, NoHistory = true)]
    public sealed class SplashActivity : AppCompatActivity
    {
        /// <inheritdoc />
        public override void OnCreate(Bundle? savedInstanceState, PersistableBundle? persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }

        /// <inheritdoc />
        protected override void OnResume()
        {
            base.OnResume();

            var serviceCollection = new ServiceCollection()
                                    .AddSingleton<IAuthorizationService, AuthorizationService>()
                                    .AddSingleton(typeof(IPockitAzureFunctionsApi),
                                        Refit.RestService.For<IPockitAzureFunctionsApi>(AzureFunctionsConstants
                                            .BaseApiUri));
            var serviceProvider = serviceCollection.BuildServiceProvider();
            ServiceLocator.SetServiceProvider(serviceProvider);
            
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