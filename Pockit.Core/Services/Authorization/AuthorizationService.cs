﻿using System;
using System.Threading.Tasks;
using Pockit.Core.Constants;
using Pockit.Core.Models;
using Xamarin.Essentials;

namespace Pockit.Core.Services.Authorization
{
    internal sealed class AuthorizationService : IAuthorizationService
    {
        private readonly IPockitAzureFunctionsApi _pockitAzureFunctionsApi;
        private string _expectedState;

        public AuthorizationService(IPockitAzureFunctionsApi pockitAzureFunctionsApi)
        {
            _pockitAzureFunctionsApi = pockitAzureFunctionsApi;
        }

        /// <inheritdoc />
        public async Task RequestAuthorizationAsync(string username, string state, Uri redirectUri)
        {
            /**
             * The process of obtaining an access code is as follows:
             *  1: An authorization URL is generated and the user is redirected to GitHub to request their identity
             *  2: Once logged in, the user is prompted to authorize the application
             *  3: GitHub redirects back to the site specified in step 1. with a temporary code
             *  4: A POST request is sent to exchange the code for an access token
             */

            if (username is null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            if (state is null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            if (redirectUri is null)
            {
                throw new ArgumentNullException(nameof(redirectUri));
            }

            _expectedState = state;
            var clientId = await _pockitAzureFunctionsApi.GetPockitClientIdAsync();
            await WebAuthenticator.AuthenticateAsync(
                new Uri(OAuthWebFlowConstants.GetAuthorizationUriString(clientId, state, username)),
                new Uri(OAuthWebFlowConstants.CallbackUri));
        }

        /// <inheritdoc />
        public async Task<bool> CallbackAsync(AccessTokenDTO accessTokenDto)
        {
            //return new Task<bool>(() => accessTokenDto.State == _expectedState);
            return accessTokenDto.State == _expectedState;
        }
    }
}