using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyFort.App.Services;
using MyFort.App.Views;
using MyFort.App.ViewModels;
using Unity;
using CommonServiceLocator;
using MyFort.App.Navigation;

namespace MyFort.App
{
	public enum Theme
	{
		Light,
		Dark
	}

	public partial class App : Application, IMainPage
	{
		
		public static Theme AppTheme { get; set; }
		public static UnityContainer Container { get; set; }

		public App()
		{
			InitializeComponent();
			Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule())
						  .With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule())
						  .With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule())
						  .With(new Plugin.Iconize.Fonts.MaterialModule());
			RegisterService();

			MainViewModel viewModel = null;
			var navigator = Container.Resolve<INavigationService>();
			var page = navigator.PresentAsNavigatableMainPage<MainViewModel>(ref viewModel);
			base.MainPage = page;
			viewModel.Initialize();
		}

		private void RegisterService()
		{
			Container = new UnityContainer();
			Container.RegisterInstance<IMainPage>(this);
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
