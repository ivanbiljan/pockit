#nullable enable

using System;
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
using Pockit.Core.DTOs;
using Pockit.Core.Helpers;
using Pockit.Core.Services.Authorization;
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

            var authorizationService = ServiceLocator.Instance.Get<IAuthorizationService>()!;
            await authorizationService.RequestAuthorizationAsync(username, StringHelpers.GetRandomString(),
                new Uri(OAuthWebFlowConstants.RedirectUri));
        }
    }

    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] {Intent.ActionView}, Categories = new[] {Intent.CategoryDefault, Intent.CategoryBrowsable},
        DataScheme = OAuthWebFlowConstants.CallbackScheme)]
    public sealed class WebAuthenticationCallbackActivity : WebAuthenticatorCallbackActivity
    {
        /// <inheritdoc />
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            if (Intent?.Data is null)
            {
                Log.Debug("TEST", "NULL?????");
                return;
            }

            //if (Intent.Scheme != OAuthWebFlowConstants.CallbackScheme)
            //{
            //    return;
            //}

            var authorizationService = ServiceLocator.Instance.Get<IAuthorizationService>()!;
            var accessToken = Intent.Data.GetQueryParameter("access_token");
            var state = Intent.Data.GetQueryParameter("state");
            Log.Debug("TEST", "await callback");
            if (!await authorizationService.CallbackAsync(new AccessTokenDTO(accessToken, state)))
            {
                Log.Debug(nameof(LoginActivity), "States do not match");
                return;
            }

            Log.Debug(nameof(LoginActivity), "Saving token");
            using var preferences = GetSharedPreferences("pockit", FileCreationMode.Private)!;
            using var editor = preferences.Edit()!;
            editor.PutString("access_token", accessToken);
            editor.Commit();
            Log.Debug(nameof(LoginActivity), "Login successful");
        }
    }
}