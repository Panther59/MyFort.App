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
		private readonly IAppSettings appSettings;
		private readonly IDialogService dialogService;
		private readonly IAuthService authService;
		private readonly IViewLocator viewLocator;
		private readonly INavigationService navigationService;

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

		private bool CanLogin()
		{
			return string.IsNullOrEmpty(Email) == false && string.IsNullOrEmpty(this.Password);
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
		/// The Login
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		private async Task Login()
		{
			try
			{
				var response = await this.authService.Authenticate(new Models.AuthRequest { Email = this.Email, Password = this.Password });
				if (response != null)
				{
					this.appSettings.Set("Token", response.Token);
					this.appSettings.Set("Name", response.User.FirstName + " " + response.User.LastName);
					var viewModel = this.viewLocator.GetViewModel<HomeViewModel>();
					await this.navigationService.NavigateTo(viewModel);
				}
			}
			catch (Exception ex)
			{
				await this.dialogService.ShowAlertAsync(ex.Message, "Login Failed", "OK");
			}
		}
	}
}
