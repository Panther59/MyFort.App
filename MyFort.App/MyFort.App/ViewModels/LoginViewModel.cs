// <copyright file="LoginViewModel.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-12</date>

namespace MyFort.App.ViewModels
{
	using MyFort.App.Navigation;
	using MyFort.App.Services;
	using System;
	using System.Threading.Tasks;
	using System.Windows.Input;
	using Xamarin.Forms;

	/// <summary>
	/// Defines the <see cref="LoginViewModel" />
	/// </summary>
	public class LoginViewModel : BaseViewModel
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
		/// Defines the dialogService
		/// </summary>
		private readonly IDialogService dialogService;

		/// <summary>
		/// Defines the navigationService
		/// </summary>
		private readonly INavigationService navigationService;

		/// <summary>
		/// Defines the viewLocator
		/// </summary>
		private readonly IViewLocator viewLocator;

		/// <summary>
		/// Defines the registerCommand
		/// </summary>
		public ICommand registerCommand;

		/// <summary>
		/// Defines the email
		/// </summary>
		private string email;

		/// <summary>
		/// Defines the password
		/// </summary>
		private string password;

		/// <summary>
		/// Initializes a new instance of the <see cref="LoginViewModel"/> class.
		/// </summary>
		/// <param name="appSettings">The appSettings<see cref="IAppSettings"/></param>
		/// <param name="dialogService">The dialogService<see cref="IDialogService"/></param>
		/// <param name="authService">The authService<see cref="IAuthService"/></param>
		/// <param name="viewLocator">The viewLocator<see cref="IViewLocator"/></param>
		/// <param name="navigationService">The navigationService<see cref="INavigationService"/></param>
		public LoginViewModel(
			IAppSettings appSettings,
			IDialogService dialogService,
			IAuthService authService,
			IViewLocator viewLocator,
			INavigationService navigationService)
		{
			this.appSettings = appSettings;
			this.dialogService = dialogService;
			this.authService = authService;
			this.viewLocator = viewLocator;
			this.navigationService = navigationService;
			this.LoginCommand = new Command(async () => await this.Login());
		}

		/// <summary>
		/// Gets or sets the Email
		/// </summary>
		public string Email
		{
			get { return email; }
			set
			{
				this.SetProperty(ref email, value);
			}
		}

		/// <summary>
		/// Gets the LoginCommand
		/// </summary>
		public ICommand LoginCommand { get; }

		/// <summary>
		/// Gets or sets the Password
		/// </summary>
		public string Password
		{
			get { return password; }
			set
			{
				this.SetProperty(ref password, value);
			}
		}

		/// <summary>
		/// Gets the RegisterCommand
		/// </summary>
		public ICommand RegisterCommand
		{
			get
			{
				if (this.registerCommand == null)
				{
					this.registerCommand = new Command(() => this.Register());
				}

				return this.registerCommand;
			}
		}

		/// <summary>
		/// The CanLogin
		/// </summary>
		/// <returns>The <see cref="bool"/></returns>
		private bool CanLogin()
		{
			return string.IsNullOrEmpty(Email) == false && string.IsNullOrEmpty(this.Password);
		}

		/// <summary>
		/// The Login
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		private async Task Login()
		{
			try
			{
				if (string.IsNullOrEmpty(this.Email))
				{
					await this.dialogService.ShowAlertAsync("Please enter email address", "Login", "OK");
					return;
				}

				if (string.IsNullOrEmpty(this.Password))
				{
					await this.dialogService.ShowAlertAsync("Please enter password", "Login", "OK");
					return;
				}

				this.IsBusy = true;
				var response = await this.authService.Authenticate(new Models.AuthRequest { Email = this.Email, Password = this.Password });
				this.IsBusy = false;
				if (response.IsSuccess)
				{
					this.appSettings.Set("Token", response.Result.Token);
					this.appSettings.Set("Name", response.Result.User.FirstName + " " + response.Result.User.LastName);
					this.navigationService.MasterDetailPage<RootViewModel, MasterViewModel, HomeViewModel>();
				}
				else
				{
					await this.dialogService.ShowAlertAsync(response.Error?.Error ?? "Unable to login", "Login Failed", "OK");
				}
			}
			catch (Exception ex)
			{
				this.IsBusy = false;
				await this.dialogService.ShowAlertAsync(ex.Message, "Login Failed", "OK");
			}
		}

		/// <summary>
		/// The Register
		/// </summary>
		private async void Register()
		{
			try
			{
				var viewModel = this.viewLocator.GetViewModel<SignupViewModel>();
				await this.navigationService.NavigateTo(viewModel);
			}
			catch (Exception ex)
			{
				this.IsBusy = false;
				await this.dialogService.ShowAlertAsync(ex.Message, "Login Failed", "OK");
			}
		}
	}
}
