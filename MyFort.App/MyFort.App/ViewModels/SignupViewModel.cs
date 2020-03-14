// <copyright file="SignupViewModel.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-12</date>

namespace MyFort.App.ViewModels
{
	using MyFort.App.Models;
	using MyFort.App.Navigation;
	using MyFort.App.Services;
	using Plugin.GoogleClient;
	using Plugin.GoogleClient.Shared;
	using System;
	using System.Threading.Tasks;
	using System.Windows.Input;
	using Xamarin.Forms;

	/// <summary>
	/// Defines the <see cref="SignupViewModel" />
	/// </summary>
	public class SignupViewModel : BaseViewModel
	{
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
		/// Defines the createAccountCommand
		/// </summary>
		public ICommand createAccountCommand;

		/// <summary>
		/// Defines the signupWithGoogleCommand
		/// </summary>
		public ICommand signupWithGoogleCommand;

		/// <summary>
		/// Defines the confirmPassword
		/// </summary>
		private string confirmPassword;

		/// <summary>
		/// Defines the email
		/// </summary>
		private string email;

		/// <summary>
		/// Defines the fullName
		/// </summary>
		private string fullName;

		/// <summary>
		/// Defines the isGoogleSignedIn
		/// </summary>
		private bool isGoogleSignedIn;

		/// <summary>
		/// Defines the password
		/// </summary>
		private string password;

		/// <summary>
		/// Defines the userData
		/// </summary>
		private GoogleUser userData;

		/// <summary>
		/// Initializes a new instance of the <see cref="SignupViewModel"/> class.
		/// </summary>
		/// <param name="dialogService">The dialogService<see cref="IDialogService"/></param>
		/// <param name="navigationService">The navigationService<see cref="INavigationService"/></param>
		/// <param name="authService">The authService<see cref="IAuthService"/></param>
		public SignupViewModel(
			IDialogService dialogService,
			INavigationService navigationService,
			IAuthService authService)
		{
			CrossGoogleClient.Current.OnLogin += this.GoogleClient_OnLogin;
			CrossGoogleClient.Current.OnError += this.GoogleClient_OnError;
			this.dialogService = dialogService;
			this.navigationService = navigationService;
			this.authService = authService;
		}

		/// <summary>
		/// Gets or sets the ConfirmPassword
		/// </summary>
		public string ConfirmPassword
		{
			get { return confirmPassword; }
			set
			{
				this.SetProperty(ref confirmPassword, value);
			}
		}

		/// <summary>
		/// Gets the CreateAccountCommand
		/// </summary>
		public ICommand CreateAccountCommand
		{
			get
			{
				if (this.createAccountCommand == null)
				{
					this.createAccountCommand = new Command(() => this.CreateAccount());
				}

				return this.createAccountCommand;
			}
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
		/// Gets or sets the FullName
		/// </summary>
		public string FullName
		{
			get { return this.fullName; }
			set
			{
				this.SetProperty(ref this.fullName, value);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether IsGoogleSignedIn
		/// </summary>
		public bool IsGoogleSignedIn
		{
			get { return this.isGoogleSignedIn; }
			set
			{
				this.SetProperty(ref this.isGoogleSignedIn, value);
			}
		}

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
		/// Gets the SignupWithGoogleCommand
		/// </summary>
		public ICommand SignupWithGoogleCommand
		{
			get
			{
				if (this.signupWithGoogleCommand == null)
				{
					this.signupWithGoogleCommand = new Command(async () => await this.SignupWithGoogle());
				}

				return this.signupWithGoogleCommand;
			}
		}

		/// <summary>
		/// The CreateAccount
		/// </summary>
		private async void CreateAccount()
		{
			try
			{
				if (string.IsNullOrEmpty(Password) || Password.Length < 6)
				{
					await this.dialogService.ShowAlertAsync("Enter valid password containing at least 6 digits", "Sign Up", "OK");
					return;
				}

				if (this.Password != this.ConfirmPassword)
				{
					await this.dialogService.ShowAlertAsync("Both passwords dont match, please type again", "Sign Up", "OK");
					return;
				}

				this.IsBusy = true;
				var request = new RegisterUser
				{
					Password = this.Password,
					User = new User
					{
						Email = this.userData.Email,
						FirstName = this.userData.GivenName,
						LastName = this.userData.FamilyName,
					}
				};

				var response = await this.authService.Register(request);
				this.IsBusy = false;
				if (response.IsSuccess)
				{
					await this.dialogService.ShowAlertAsync("Your account has been created, however please reach out to Admin to activate your account", "Sign Up", "OK");
					await this.navigationService.NavigateBack();
				}
				else
				{
					await this.dialogService.ShowAlertAsync(response.Error.Error ?? "Account creation failed", "Sign Up", "OK");
				}
			}
			catch (Exception ex)
			{
				this.IsBusy = false;
				await this.dialogService.ShowAlertAsync(ex.Message, "Sign Up", "OK");
			}
		}

		/// <summary>
		/// The GoogleClient_OnError
		/// </summary>
		/// <param name="sender">The sender<see cref="object"/></param>
		/// <param name="e">The e<see cref="GoogleClientErrorEventArgs"/></param>
		private async void GoogleClient_OnError(object sender, GoogleClientErrorEventArgs e)
		{
			await this.dialogService.ShowAlertAsync(e.Message, "Sign up", "OK");
		}

		/// <summary>
		/// The GoogleClient_OnLogin
		/// </summary>
		/// <param name="sender">The sender<see cref="object"/></param>
		/// <param name="e">The e<see cref="GoogleClientResultEventArgs{Plugin.GoogleClient.Shared.GoogleUser}"/></param>
		private void GoogleClient_OnLogin(object sender, GoogleClientResultEventArgs<Plugin.GoogleClient.Shared.GoogleUser> e)
		{
			this.userData = e.Data;
			this.IsGoogleSignedIn = true;
			this.Email = e.Data.Email;
			this.FullName = e.Data.Name;
		}

		/// <summary>
		/// The SignupWithGoogle
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		private async Task SignupWithGoogle()
		{
			try
			{
				await CrossGoogleClient.Current.LoginAsync();
			}
			catch (Exception ex)
			{
				await this.dialogService.ShowAlertAsync(ex.Message, "Sign up", "OK");
			}
		}
	}
}
