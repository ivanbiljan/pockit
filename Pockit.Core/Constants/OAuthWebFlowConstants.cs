using System.Web;

namespace Pockit.Core.Constants
{
    internal static class OAuthWebFlowConstants
    {
        public const string CallbackScheme = "gitmax";
        public static readonly string CallbackUri = $"{CallbackScheme}://callback";

        public const string RedirectUri =
            "https://pockitfunctions20210211150644.azurewebsites.net/api/ExchangeCodeForAccessToken";

        public static string GetAuthorizationUriString(string clientId, string state, string login) =>
            $"https://github.com/login/oauth/authorize?client_id={clientId}&login={HttpUtility.UrlEncode(login)}&state={HttpUtility.UrlEncode(state)}";

        public static string GetAccessTokenUri(string clientId, string clientSecret, string code) =>
            $"https://github.com/login/oauth/access_token?client_id={clientId}&client_secret={clientSecret}&code={code}";
    }
}