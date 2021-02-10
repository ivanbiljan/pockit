namespace Pockit.Core.Constants
{
    internal static class OAuthWebFlowConstants
    {
        public const string CallbackScheme = "gitmax";
        public static readonly string CallbackUri = $"{CallbackScheme}://";

        public static string GetAuthorizationUriString(string login, string state) =>
            $"https://github.com/login/oauth/authorize?login={login}&state={state}";
    }
}