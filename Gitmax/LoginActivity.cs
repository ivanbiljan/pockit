using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Gitmax.Lib.Http;
using Gitmax.Lib.Modules;
using Java.Interop;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;
using static Firebase.Auth.FirebaseAuth;
using Uri = Android.Net.Uri;

namespace Gitmax {
    [Activity(Label = "LoginActivity")]
    public sealed class LoginActivity : AppCompatActivity {
        private WebView _webView;

        protected override void OnCreate(Bundle savedInstanceState) {   
            base.OnCreate(savedInstanceState);
            _webView = new WebView(ApplicationContext) {
                Settings = {
                    JavaScriptEnabled = true,
                    JavaScriptCanOpenWindowsAutomatically = true
                }
            };

            _webView.SetWebViewClient(new LoginWebViewClient());

            SetContentView(Resource.Layout.activity_login);
            FindViewById<Button>(Resource.Id.btnSignIn).Click += OnSignInClick;
        }

        private void OnSignInClick(object sender, EventArgs e) {
            // GitHub handles sign in/up
            _webView.LoadUrl("https://github.com/login/oauth/authorize?client_id=ab8ef61b50458d9a01db");
            SetContentView(_webView);
        }
    }

    internal sealed class LoginWebViewClient : WebViewClient {
        private static readonly Uri CallbackUrl = Uri.Parse("https://gitmax-51399.firebaseapp.com/__/auth/handler");

        public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request) {
            if (!request.Url.Equals(CallbackUrl)) {
                return false;
            }

            var githubCode = request.Url.GetQueryParameter("code");
            if (githubCode == null) {
                throw new Exception("Expected GitHub to return a code.");
            }

            var oauthSecrets = JObject.Parse("ouath.json");
            return true;
        }
    }
}