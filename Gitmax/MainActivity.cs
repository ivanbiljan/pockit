using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.Util.Prefs;

namespace Gitmax {
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public sealed class MainActivity : AppCompatActivity {
        internal const int LoginRequestCode = 666;

        protected override void OnCreate(Bundle savedInstanceState) {
        }

        public override bool OnCreateOptionsMenu(IMenu menu) {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings) {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data) {
            if (requestCode != LoginRequestCode || resultCode != Result.Ok) {
                // TODO: Do something
            }

            var preferences = GetPreferences(FileCreationMode.Private);
            var editor = preferences.Edit();
            editor.PutString("access_token", data.GetStringExtra("result"));
            editor.Apply();
            base.OnActivityResult(requestCode, resultCode, data);
        }

        private void FabOnClick(object sender, EventArgs eventArgs) {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}