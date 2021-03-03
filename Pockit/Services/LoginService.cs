using Android.Content;
using Pockit.Core.Services;

namespace Pockit.Services
{
    public sealed class LoginService : ILoginService
    {
        /// <inheritdoc />
        public bool TryGetLogin(out string? accessToken)
        {
            var preferences = AndroidApplication.MainContext.GetSharedPreferences("pockit", FileCreationMode.Private)!;
            accessToken = preferences.GetString("access_token", null);
            return accessToken != null;
        }
    }
}