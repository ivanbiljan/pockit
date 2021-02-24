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
using Android.Preferences;
using Pockit.Core.Services;

namespace Pockit.Services 
{
    public sealed class LoginService : ILoginService
    {
        /// <inheritdoc />
        public bool TryGetLogin(out string? accessToken)
        {
            return (accessToken =
                AndroidApplication.MainContext.GetSharedPreferences("pockit", FileCreationMode.Private)!.GetString(
                    "access_token", null)) is not null;
        }
    }
}