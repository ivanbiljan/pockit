using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Pockit.Core.Constants;
using Pockit.Core.Exceptions;
using Xamarin.Essentials;

namespace Pockit.Core.Services.Authorization 
{
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
        public async Task<string> ExchangeCodeForAccessToken(string code, string state)
        {
            if (state != _state)
            {
                throw new MaliciousAuthorizationRequestException("States do not match. A third party created the request");
            }
            
            var httpClient = new HttpClient(new HttpClientHandler());
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var oauthJson = JsonDocument.Parse(File.ReadAllText("oauth.json"));

            var responseMessage = await httpClient.PostAsync(
                new Uri(
                    $"https://github.com/login/oauth/access_token?client_id={oauthJson.RootElement.GetProperty("client_id").GetString()}&client_secret={oauthJson.RootElement.GetProperty("client_secret").GetString()}"),
                null);
            var contentDom = JsonDocument.Parse(await responseMessage.Content.ReadAsStringAsync());

            return contentDom.RootElement.GetProperty("access_token").GetString();
        }
    }
}