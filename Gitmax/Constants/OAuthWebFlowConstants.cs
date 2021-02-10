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

namespace Gitmax.Constants 
{
    internal static class OAuthWebFlowConstants
    {
        public const string CallbackUri = "gitmax://";
        public static string GetAuthorizationUriString(string login, string state) =>
            $"https://github.com/login/oauth/authorize?login={login}&state={state}";
    }
}