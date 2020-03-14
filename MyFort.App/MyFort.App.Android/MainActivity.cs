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
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using static MyFort.App.App;
using Android.Support.V7.App;
using Android.Content.Res;
using MyFort.App.Styles;

namespace MyFort.App.Droid
{
	[Activity(Label = "My Fort", Icon = "@mipmap/my_fort", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
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

			ImageCircleRenderer.Init();

			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
			MessagingCenter.Subscribe<object, Theme>(this, "ModeChanged", callback: OnModeChanged);
			var theme = GetPhoneTheme();
			LoadApplication(new App(theme));
			Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
			SetAppTheme();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			MessagingCenter.Unsubscribe<object, Theme>(this, "ModeChanged");
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

		private void OnModeChanged(object arg1, Theme theme)
		{

			//if (theme == MyFort.App.Theme.Light)
			//{
			//	Delegate.SetLocalNightMode(AppCompatDelegate.ModeNightNo);
			//}
			//else
			//{
			//	Delegate.SetLocalNightMode(AppCompatDelegate.ModeNightYes);
			//}

			SetTheme(theme);
		}

		void SetAppTheme()
		{
			SetTheme(App.AppTheme);
		}

		Theme GetPhoneTheme()
		{
			if (Resources.Configuration.UiMode.HasFlag(UiMode.NightYes))
			{
				return MyFort.App.Theme.Dark;
			}
			else
			{
				return MyFort.App.Theme.Light;
			}
		}

		void SetTheme(Theme mode)
		{
			if (mode == MyFort.App.Theme.Dark)
			{
				if (App.AppTheme == MyFort.App.Theme.Dark)
					return;
				App.Current.Resources = new DarkTheme();
			}
			else
			{
				if (App.AppTheme != MyFort.App.Theme.Dark)
					return;
				App.Current.Resources = new LightTheme();
			}
			App.AppTheme = mode;
		}
	}
}