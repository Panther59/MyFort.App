using MyFort.App.Navigation;
using MyFort.App.Services;
using Plugin.GoogleClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFort.App.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		private readonly INavigationService navigationService;
		private readonly IAppSettings appSettings;
		private readonly IViewLocator viewLocator;
		private readonly ILogger logger;

		public MainViewModel(
			INavigationService navigationService,
			IAppSettings appSettings,
			IViewLocator viewLocator,
			ILogger logger)
		{
			this.navigationService = navigationService;
			this.appSettings = appSettings;
			this.viewLocator = viewLocator;
			this.logger = logger;
		}

		public async Task Initialize()
		{
			try
			{
				var token = this.appSettings.Get("Token");
				if (token != null)
				{
					var viewModel = this.viewLocator.GetViewModel<HomeViewModel>();
					await this.navigationService.NavigateTo(viewModel);
				}
				else
				{
					var viewModel = this.viewLocator.GetViewModel<LoginViewModel>();
					await this.navigationService.NavigateTo(viewModel);
				}
			}
			catch (Exception ex)
			{
			}

			//CrossGoogleClient.Current.OnLogin += this.GoogleClient_OnLogin;
			//CrossGoogleClient.Current.OnError += this.GoogleClient_OnError;
			//var response = await CrossGoogleClient.Current.LoginAsync();
		}

		private void GoogleClient_OnError(object sender, GoogleClientErrorEventArgs e)
		{
		}

		private void GoogleClient_OnLogin(object sender, GoogleClientResultEventArgs<Plugin.GoogleClient.Shared.GoogleUser> e)
		{
		}

	}
}
