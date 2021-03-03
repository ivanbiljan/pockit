using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using Android.Content;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using MvvmCross;
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
            CreatableTypes(typeof(Pockit.Core.Assembly).Assembly).EndingWith("Service").AsInterfaces()
                                                       .RegisterAsLazySingleton();


            var preferences = AndroidApplication.MainContext.GetSharedPreferences(PreferencesKeys.PreferencesFile, FileCreationMode.Private)!;
            var accessToken = preferences.GetString(PreferencesKeys.AccessToken, null);

            Debug.Assert(accessToken != null, "accessToken != null");

            var graphQLClient = new GraphQLHttpClient("https://api.github.com/graphql", new SystemTextJsonSerializer());
            graphQLClient.HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            Mvx.IoCProvider.RegisterSingleton<IGraphQLClient>(graphQLClient);

            Mvx.IoCProvider.RegisterSingleton(() =>
                RestService.For<IPockitAzureFunctionsApi>(AzureFunctionsConstants.BaseApiUri));

            // Register custom app start
            RegisterCustomAppStart<PockitMvxAppStart>();
        }
    }
}