using System;
using Android.Content;
using Android.Content.Res;
using MyFort.App.Styles;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(ContentPage), typeof(MyFort.App.Droid.Renderers.PageRenderer))]
namespace MyFort.App.Droid.Renderers
{
	public class PageRenderer : Xamarin.Forms.Platform.Android.PageRenderer
	{
		public PageRenderer(Context context) : base(context) { }

		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);
			SetAppTheme();
		}

		void SetAppTheme()
		{
			if (Resources.Configuration.UiMode.HasFlag(UiMode.NightYes))
			{
				SetTheme(MyFort.App.Theme.Dark);
			}
			else
			{
				SetTheme(MyFort.App.Theme.Light);
			}
		}

		void SetTheme(Theme mode)
		{
			if (mode == MyFort.App.Theme.Dark)
			{
				if (App.AppTheme == MyFort.App.Theme.Dark)
					return;

				App.Current.Resources = new DarkTheme();

				App.AppTheme = MyFort.App.Theme.Dark;
			}
			else
			{
				if (App.AppTheme != MyFort.App.Theme.Dark)
					return;
				App.Current.Resources = new LightTheme();
				App.AppTheme = MyFort.App.Theme.Light;
			}
		}
	}
}
