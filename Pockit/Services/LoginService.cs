using Android.Content;
using Pockit.Core.Services;

namespace Pockit.Services
{
    public sealed class LoginService : ILoginService
    {
        /// <inheritdoc />
        public bool TryGetLogin(out string? accessToken)
        {
            var preferences = AndroidApplication.MainContext.GetSharedPreferences(PreferencesKeys.PreferencesFile, FileCreationMode.Private)!;
            accessToken = preferences.GetString(PreferencesKeys.AccessToken, null);
            return accessToken != null;
        }
    }
}