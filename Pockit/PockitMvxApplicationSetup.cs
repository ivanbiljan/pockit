using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross.IoC;
using MvvmCross.Platforms.Android;
using MvvmCross.ViewModels;
using Pockit.Core;
using Pockit.Core.Constants;
using Pockit.Core.Services;
using Pockit.Services;
using Refit;

namespace Pockit 
{
    /// <summary>
    /// Represents the MvvmCross setup class. This class performs initial initialization logic and acts as a composition root.
    /// </summary>
    public sealed class PockitMvxApplicationSetup : MvxApplication
    {
        /// <inheritdoc />
        public override void Initialize()
        {
            // Set up service bindings
            CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();
            CreatableTypes(typeof(Pockit.Core.IGitHubApi).Assembly).EndingWith("Service").AsInterfaces()
                                                                   .RegisterAsLazySingleton();

            MvxIoCProvider.Initialize();

            var preferences = AndroidApplication.MainContext.GetSharedPreferences("pockit", FileCreationMode.Private)!;
            var accessToken = preferences.GetString("access_token", null);

            System.Diagnostics.Debug.Assert(accessToken != null, "accessToken != null");

            MvxIoCProvider.Instance.RegisterSingleton(() => RestService.For<IGitHubApi>(new HttpClient
            {
                BaseAddress = new Uri("https://api.github.com"),
                DefaultRequestHeaders =
                {
                    {"Authorization", $"Bearer {accessToken}"}
                }
            }, RequestBuilder.ForType<IGitHubApi>()));

            MvxIoCProvider.Instance.RegisterSingleton(() =>
                RestService.For<IPockitAzureFunctionsApi>(AzureFunctionsConstants.BaseApiUri));

            // Register custom app start
            RegisterCustomAppStart<PockitMvxAppStart>();
        }
    }
}