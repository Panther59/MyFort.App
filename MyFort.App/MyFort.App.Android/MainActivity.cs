using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.GoogleClient;
using Acr.UserDialogs;
using ImageCircle.Forms.Plugin.Droid;

namespace MyFort.App.Droid
{
    [Activity(Label = "My Fort", Icon = "@mipmap/my_fort", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            var clientId = "126413075708-3el4vijpiue3od7mkegv6mk9h5ap0a4n.apps.googleusercontent.com";
            GoogleClientManager.Initialize(this, null, clientId);
            UserDialogs.Init(this);
            Plugin.Iconize.Iconize.Init();
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule())
                          .With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule())
                          .With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule())
                          .With(new Plugin.Iconize.Fonts.MaterialModule());
            //FormsPlugin.Iconize.Droid.IconControls.Init();

            ImageCircleRenderer.Init();

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            GoogleClientManager.OnAuthCompleted(requestCode, resultCode, data);
        }
    }
}