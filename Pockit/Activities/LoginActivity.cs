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
using Pockit.Core.Services.Authorization;
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
            if (string.IsNullOrWhiteSpace(username))
            {
                Snackbar.Make((View) sender, "Invalid username", Snackbar.LengthShort).Show();
                return;
            }

            Log.Debug(nameof(LoginActivity), "Initiating webflow authentication");

            var authorizationService = ServiceLocator.Instance.Get<IAuthorizationService>();
            System.Diagnostics.Debug.Assert(authorizationService != null, "authorizationService != null");

            var state = StringHelpers.GetRandomString();
            await authorizationService.RequestUserIdentity(state, username);

            Log.Debug(nameof(LoginActivity), $"Authentication complete");
        }
    }

    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Intent.ActionView }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable }, DataScheme = OAuthWebFlowConstants.CallbackScheme)]
    public sealed class WebAuthenticationCallbackActivity : WebAuthenticatorCallbackActivity
    {
    }
}