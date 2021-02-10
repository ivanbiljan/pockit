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
using System.Threading.Tasks;
using Pockit.Constants;
using Xamarin.Essentials;

namespace Pockit.Services.Authorization {
    internal sealed class AuthorizationService : IAuthorizationService
    {
        private string _state;
        
        /// <inheritdoc />
        public async Task RequestUserIdentity(string state, string? usernameHint = null)
        {
            if (string.IsNullOrWhiteSpace(state))
            {
                throw new ArgumentException("State must not be null or empty", nameof(state));
            }

            _state = state;
            await WebAuthenticator.AuthenticateAsync(
                new Uri(OAuthWebFlowConstants.GetAuthorizationUriString(usernameHint!, state)),
                new Uri(OAuthWebFlowConstants.CallbackUri));
        }

        /// <inheritdoc />
        public Task ExchangeCodeForAccessToken(string code, string state)
        {
            return null;
        }
    }
}