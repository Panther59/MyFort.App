using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyFort.App.Services;
using MyFort.App.Views;
using MyFort.App.ViewModels;
using Unity;
using CommonServiceLocator;
using MyFort.App.Navigation;
using System.Threading.Tasks;
using MyFort.App.Styles;

namespace MyFort.App
{
	public enum Theme
	{
		Light,
		Dark
	}

	public partial class App : Application, IMainPage
	{
		public static bool IsAppLoaded = false;
		public static Theme AppTheme { get; set; }
		public static Theme PhoneTheme { get; set; }
		public static UnityContainer Container { get; set; }
		public static DarkTheme darkTheme = new DarkTheme();
		public static LightTheme lightTheme = new LightTheme();

		public App(Theme theme)
		{
			IsAppLoaded = false;
			PhoneTheme = theme;
			InitializeComponent();
			Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule())
						  .With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule())
						  .With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule())
						  .With(new Plugin.Iconize.Fonts.MaterialModule());
			RegisterService();

			var startupService = Container.Resolve<IStartupService>();
			Task.Run(async () =>
			{
				await startupService.Initialize();
				SetTheme(AppTheme);
				IsAppLoaded = true;
			}).Wait();
		}

		public static void SetTheme(Theme mode)
		{
			if (mode == MyFort.App.Theme.Dark)
			{
				if (IsAppLoaded && App.AppTheme == MyFort.App.Theme.Dark)
					return;
				App.Current.Resources.MergedDictionaries.Remove(lightTheme);
				App.Current.Resources.MergedDictionaries.Add(darkTheme);
			}
			else
			{
				if (IsAppLoaded && App.AppTheme == MyFort.App.Theme.Light)
					return;
				App.Current.Resources.MergedDictionaries.Remove(darkTheme);
				App.Current.Resources.MergedDictionaries.Add(lightTheme);
			}

			App.AppTheme = mode;
		}

		private void RegisterService()
		{
			Container = new UnityContainer();
			Container.RegisterInstance<IMainPage>(this);
			Container.RegisterType<IStartupService, StartupService>();
			Container.RegisterType<IAppSettings, AppSettings>();
			Container.RegisterType<ILogger, Logger>();
			Container.RegisterType<IVisitsService, VisitsService>();
			Container.RegisterType<IOutletService, OutletService>();
			Container.RegisterType<IAuthService, AuthService>();
			Container.RegisterType<IUsersService, UsersService>();
			Container.RegisterType<IDialogService, DialogService>();
			Container.RegisterType<INavigationService, NavigationService>();
			Container.RegisterType<IViewLocator, ViewLocator>();
			Container.RegisterType<LoginViewModel>();
			Container.RegisterType<HomeViewModel>();
			Container.RegisterType<MasterViewModel>();
			Container.RegisterType<UsersViewModel>();
			Container.RegisterType<UserDetailViewModel>();
			Container.RegisterType<OutletsViewModel>();
			Container.RegisterType<OutletDetailViewModel>();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
