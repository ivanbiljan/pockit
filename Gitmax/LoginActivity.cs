using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
using Java.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.Apache.Http.Impl.Client;
using Xamarin.Essentials;
using static Firebase.Auth.FirebaseAuth;
using Uri = System.Uri;

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

            // There is no C# equivalent to Java's anonymous classes so we'll resort to DI
            _webView.SetWebViewClient(new LoginWebViewClient(this));

            SetContentView(Resource.Layout.activity_login);
            FindViewById<Button>(Resource.Id.btnSignIn).Click += OnSignInClick;
        }

        private void OnSignInClick(object sender, EventArgs e) {
            using var manifestStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Gitmax.oauth.json");
            using var streamReader = new StreamReader(manifestStream);
            var clientId = JObject.Parse(streamReader.ReadToEnd())["client_id"];

            _webView.LoadUrl($"https://github.com/login/oauth/authorize?client_id={clientId}");
            SetContentView(_webView);
        }
    }

    internal sealed class LoginWebViewClient : WebViewClient {
        private static readonly string CallbackUrl = "https://gitmax-51399.firebaseapp.com/__/auth/handler";
        private readonly LoginActivity _loginActivity;

        public LoginWebViewClient(LoginActivity activity) {
            _loginActivity = activity;
        }

        public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request) {
            if (!request.Url.ToString().StartsWith(CallbackUrl)) {
                return false;
            }

            var githubCode = request.Url.GetQueryParameter("code");
            if (githubCode == null) {
                Toast.MakeText(_loginActivity.ApplicationContext, "Expected GitHub to return a code.", ToastLength.Long).Show();
                _loginActivity.Finish();
            }

            var oauthSecrets = ParseOAuthResourceJson();
            var token = ExchangeAccessCodeForToken();
            var result = new Intent();
            result.PutExtra("result", new Regex("access_token=([^&]+)").Match(token).Groups[1].Value);
            _loginActivity.SetResult(Result.Ok, result);
            _loginActivity.Finish();
            return true;

            static JObject ParseOAuthResourceJson() {
                using var manifestStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Gitmax.oauth.json");
                using var streamReader = new StreamReader(manifestStream);
                return JObject.Parse(streamReader.ReadToEnd());
            }

            string ExchangeAccessCodeForToken() {
                // We're only creating 2 sockets throughout the lifetime of the app so we don't have to worry about
                // socket exhaustion. This socket only opens if the user hasn't authenticated and immediately closes anyway
                using var httpClient = new HttpClient();
                var uri = new Uri($"https://github.com/login/oauth/access_token?client_id={oauthSecrets["client_id"]}&client_secret={oauthSecrets["client_secret"]}&code={githubCode}");
                var response = httpClient.PostAsync(uri, new StringContent(string.Empty)).GetAwaiter().GetResult();
                var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return content;
            }
        }
    }
}