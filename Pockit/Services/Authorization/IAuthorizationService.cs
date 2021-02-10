﻿using Android.App;
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

namespace Pockit.Services.Authorization 
{
    public interface IAuthorizationService
    {
        Task RequestUserIdentity(string state, string? usernameHint = null);

        Task ExchangeCodeForAccessToken(string code, string state);
    }
}