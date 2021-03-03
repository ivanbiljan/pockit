using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using Android.Content;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Pockit.Core;
using Pockit.Core.Constants;
using Refit;

namespace Pockit
{
    /// <summary>
    ///     Represents the MvvmCross setup class. This class performs initialization logic and acts as a composition root.
    /// </summary>
    public sealed class PockitMvxApplicationSetup : MvxApplication
    {
        /// <inheritdoc />
        public override void Initialize()
        {
            // Set up service bindings
            CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();
            CreatableTypes(typeof(IGitHubApi).Assembly).EndingWith("Service").AsInterfaces()
                                                       .RegisterAsLazySingleton();

            MvxIoCProvider.Initialize();

            var preferences = AndroidApplication.MainContext.GetSharedPreferences("pockit", FileCreationMode.Private)!;
            var accessToken = preferences.GetString("access_token", null);

            Debug.Assert(accessToken != null, "accessToken != null");

            MvxIoCProvider.Instance.RegisterSingleton(() => RestService.For(new HttpClient
            {
                BaseAddress = new Uri("https://api.github.com"),
                DefaultRequestHeaders =
                {
                    {"Authorization", $"Bearer {accessToken}"}
                }
            }, RequestBuilder.ForType<IGitHubApi>()));

            var graphQLClient = new GraphQLHttpClient("https://api.github.com/graphql", new SystemTextJsonSerializer());
            graphQLClient.HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            MvxIoCProvider.Instance.RegisterSingleton<IGraphQLClient>(graphQLClient);

            MvxIoCProvider.Instance.RegisterSingleton(() =>
                RestService.For<IPockitAzureFunctionsApi>(AzureFunctionsConstants.BaseApiUri));

            // Register custom app start
            RegisterCustomAppStart<PockitMvxAppStart>();
        }
    }
}