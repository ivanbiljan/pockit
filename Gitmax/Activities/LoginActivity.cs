#nullable enable

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
using Android.Support.V7.App;
using Gitmax.Constants;
using Gitmax.Helpers;
using Xamarin.Essentials;

namespace Gitmax.Activities 
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
        }

        private async void AuthorizeButton_Click(object sender, EventArgs e)
        {
            var username = FindViewById<EditText>(Resource.Id.txtLoginUsername)!.Text;
            if (string.IsNullOrWhiteSpace(username))
            {
                return;
            }

            var expectedState = StringHelpers.GetRandomString();
            var result = await WebAuthenticator.AuthenticateAsync(
                new Uri(OAuthWebFlowConstants.GetAuthorizationUriString(username, expectedState)),
                new Uri(OAuthWebFlowConstants.CallbackUri));
            var code = result.Properties["code"];
            var returnedState = result.Properties["state"];

            System.Diagnostics.Debug.Assert(code != null, "code != null");
            System.Diagnostics.Debug.Assert(returnedState != null, "returnedState != null");

            if (returnedState != expectedState)
            {
                Finish();
            }
        }
    }
}