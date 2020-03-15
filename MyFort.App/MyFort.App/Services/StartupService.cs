// <copyright file="StartupService.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-15</date>

namespace MyFort.App.Services
{
	using MyFort.App.Navigation;
	using MyFort.App.ViewModels;
	using System;
	using System.Threading.Tasks;
	using Xamarin.Forms;

	/// <summary>
	/// Defines the <see cref="StartupService" />
	/// </summary>
	public class StartupService : IStartupService
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
		/// Initializes a new instance of the <see cref="StartupService"/> class.
		/// </summary>
		/// <param name="navigationService">The navigationService<see cref="INavigationService"/></param>
		/// <param name="authService">The authService<see cref="IAuthService"/></param>
		/// <param name="appSettings">The appSettings<see cref="IAppSettings"/></param>
		/// <param name="viewLocator">The viewLocator<see cref="IViewLocator"/></param>
		/// <param name="logger">The logger<see cref="ILogger"/></param>
		public StartupService(
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
				if (!this.appSettings.HasKey("Theme"))
				{
					App.SetTheme(App.PhoneTheme);
				}
				else
				{
					var theme = this.appSettings.Get("Theme");
					if (theme != null && theme == "Dark")
					{
						App.SetTheme(Theme.Dark);
					}
					else
					{
						App.SetTheme(Theme.Light);
					}
				}

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

		/// <summary>
		/// The NavigateToLogin
		/// </summary>
		private void NavigateToLogin()
		{
			LoginViewModel viewModel = null;
			this.navigationService.PresentAsNavigatableMainPage<LoginViewModel>(ref viewModel);
		}
	}
}
