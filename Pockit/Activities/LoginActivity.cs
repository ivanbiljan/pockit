#nullable enable

using System;
using System.Net.Http;
using System.Text.Json;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Pockit.Core.Constants;
using Pockit.Helpers;
using Xamarin.Essentials;

namespace Pockit.Activities
{
    [Activity]
    public sealed class LoginActivity : AppCompatActivity
    {
        /// <inheritdoc />
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginView);

            var authorizeButton = FindViewById<Button>(Resource.Id.btnAuthorize)!;
            authorizeButton.Click += AuthorizeButton_Click;

            Platform.Init(this, savedInstanceState);
        }

        /// <inheritdoc />
        protected override void OnResume()
        {
            base.OnResume();

            Platform.OnResume();
        }

        private async void AuthorizeButton_Click(object sender, EventArgs e)
        {
            var username = FindViewById<EditText>(Resource.Id.txtLoginUsername)!.Text;
            if (string.IsNullOrWhiteSpace(username)) {
                Snackbar.Make((View)sender, "Invalid username", Snackbar.LengthShort).Show();
                return;
            }

            Log.Debug(nameof(LoginActivity), "Initiating webflow authentication");

            var expectedState = StringHelpers.GetRandomString();
            var result = await WebAuthenticator.AuthenticateAsync(
                new Uri(OAuthWebFlowConstants.GetAuthorizationUriString(username, expectedState)),
                new Uri(OAuthWebFlowConstants.CallbackUri));
            var code = result.Properties["code"];
            var returnedState = result.Properties["state"];

            System.Diagnostics.Debug.Assert(code != null, "code != null");
            System.Diagnostics.Debug.Assert(returnedState != null, "returnedState != null");

            if (returnedState != expectedState) {
                Log.Debug(nameof(LoginActivity), "Aborting authentication: states do not match");
                Finish();
            }

            Log.Debug(nameof(LoginActivity), "Exchanging GitHub code for an access token");
            var httpClient = new System.Net.Http.HttpClient(new SocketsHttpHandler());
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var oauthJson = JsonDocument.Parse(await System.IO.File.ReadAllTextAsync("oauth.json"));

            var responseMessage = await httpClient.PostAsync(
                new Uri(
                    $"https://github.com/login/oauth/access_token?client_id={oauthJson.RootElement.GetProperty("client_id").GetString()}&client_secret={oauthJson.RootElement.GetProperty("client_secret").GetString()}"),
                new ReadOnlyMemoryContent(ReadOnlyMemory<byte>.Empty));
            var contentDom = JsonDocument.Parse(await responseMessage.Content.ReadAsStringAsync());

            Log.Debug(nameof(LoginActivity),
                $"Authentication complete. Token: {contentDom.RootElement.GetProperty("access_token").GetString()}");
        }
    }

    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Intent.ActionView }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable }, DataScheme = OAuthWebFlowConstants.CallbackScheme)]
    public sealed class WebAuthenticationCallbackActivity : WebAuthenticatorCallbackActivity
    {
    }
}