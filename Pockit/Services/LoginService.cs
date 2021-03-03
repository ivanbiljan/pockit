using Android.Content;
using MvvmCross.Platforms.Android;
using Pockit.Core.Services;

namespace Pockit.Services
{
    public sealed class LoginService : ILoginService
    {
        private readonly Context _appContext;
        
        public LoginService(IMvxAndroidGlobals androidGlobals)
        {
            _appContext = androidGlobals.ApplicationContext;
        }
        
        /// <inheritdoc />
        public bool TryGetLogin(out string? accessToken)
        {
            var preferences = _appContext.GetSharedPreferences(PreferencesKeys.PreferencesFile, FileCreationMode.Private)!;
            accessToken = preferences.GetString(PreferencesKeys.AccessToken, null);
            return accessToken != null;
        }
    }
}