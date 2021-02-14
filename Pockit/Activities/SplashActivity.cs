using Android.App;
using Android.Content;
using Android.Support.V7.App;
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
        protected override void OnResume()
        {
            base.OnResume();

            var serviceCollection = new ServiceCollection()
                                    .AddSingleton<IAuthorizationService, AuthorizationService>()
                                    .AddSingleton(typeof(IPockitAzureFunctionsApi),
                                        RestService.For<IPockitAzureFunctionsApi>(AzureFunctionsConstants
                                            .BaseApiUri));
            var serviceProvider = serviceCollection.BuildServiceProvider();
            ServiceLocator.SetServiceProvider(serviceProvider);

            var preferences = GetSharedPreferences("pockit", FileCreationMode.Private)!;
            if (preferences.GetString("access_token", null) is null)
            {
                // Launch LoginActivity
                StartActivity(new Intent(this, typeof(LoginActivity)));
            }
        }
    }
}