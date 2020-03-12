// <copyright file="MainViewModel.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-12</date>

namespace MyFort.App.ViewModels
{
	using MyFort.App.Navigation;
	using MyFort.App.Services;
	using Plugin.GoogleClient;
	using System;
	using System.Threading.Tasks;

	/// <summary>
	/// Defines the <see cref="MainViewModel" />
	/// </summary>
	public class MainViewModel : BaseViewModel
	{
		/// <summary>
		/// Defines the appSettings
		/// </summary>
		private readonly IAppSettings appSettings;

		/// <summary>
		/// Defines the authService
		/// </summary>
		private readonly IAuthService authService;

		/// <summary>
		/// Defines the logger
		/// </summary>
		private readonly ILogger logger;

		/// <summary>
		/// Defines the navigationService
		/// </summary>
		private readonly INavigationService navigationService;

		/// <summary>
		/// Defines the viewLocator
		/// </summary>
		private readonly IViewLocator viewLocator;

		/// <summary>
		/// Initializes a new instance of the <see cref="MainViewModel"/> class.
		/// </summary>
		/// <param name="navigationService">The navigationService<see cref="INavigationService"/></param>
		/// <param name="authService">The authService<see cref="IAuthService"/></param>
		/// <param name="appSettings">The appSettings<see cref="IAppSettings"/></param>
		/// <param name="viewLocator">The viewLocator<see cref="IViewLocator"/></param>
		/// <param name="logger">The logger<see cref="ILogger"/></param>
		public MainViewModel(
			INavigationService navigationService,
			IAuthService authService,
			IAppSettings appSettings,
			IViewLocator viewLocator,
			ILogger logger)
		{
			this.navigationService = navigationService;
			this.authService = authService;
			this.appSettings = appSettings;
			this.viewLocator = viewLocator;
			this.logger = logger;
		}

		/// <summary>
		/// The Initialize
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		public async Task Initialize()
		{
			try
			{
				var token = this.appSettings.Get("Token");
				if (token != null)
				{
					try
					{
						var userResponse = await this.authService.CurrentUser();
						if (userResponse.IsSuccess)
						{
							this.appSettings.Set("Name", userResponse.Result.FirstName + " " + userResponse.Result.LastName);
							this.navigationService.MasterDetailPage<RootViewModel, MasterViewModel, HomeViewModel>();
						}
						else
						{
							this.appSettings.Set("Token", null);
							this.appSettings.Set("Name", null);
							this.NavigateToLogin();
						}
					}
					catch (Exception ex)
					{
						this.NavigateToLogin();
					}
				}
				else
				{
					this.NavigateToLogin();
				}
			}
			catch (Exception ex)
			{
			}
		}

		private void NavigateToLogin()
		{
			LoginViewModel viewModel = null;
			this.navigationService.PresentAsNavigatableMainPage<LoginViewModel>(ref viewModel);
		}

		/// <summary>
		/// The GoogleClient_OnError
		/// </summary>
		/// <param name="sender">The sender<see cref="object"/></param>
		/// <param name="e">The e<see cref="GoogleClientErrorEventArgs"/></param>
		private void GoogleClient_OnError(object sender, GoogleClientErrorEventArgs e)
		{
		}

		/// <summary>
		/// The GoogleClient_OnLogin
		/// </summary>
		/// <param name="sender">The sender<see cref="object"/></param>
		/// <param name="e">The e<see cref="GoogleClientResultEventArgs{Plugin.GoogleClient.Shared.GoogleUser}"/></param>
		private void GoogleClient_OnLogin(object sender, GoogleClientResultEventArgs<Plugin.GoogleClient.Shared.GoogleUser> e)
		{
		}
	}
}
