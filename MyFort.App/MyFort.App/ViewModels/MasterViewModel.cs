// <copyright file="MasterViewModel.cs" company="Ayvan">
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
	/// Defines the <see cref="MasterViewModel" />
	/// </summary>
	public class MasterViewModel : BaseViewModel
	{
		/// <summary>
		/// Defines the appSettings
		/// </summary>
		private readonly IAppSettings appSettings;

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
		/// Defines the myVisitsCommand
		/// </summary>
		public ICommand myVisitsCommand;

		/// <summary>
		/// Defines the outletsCommand
		/// </summary>
		public ICommand outletsCommand;

		/// <summary>
		/// Defines the themeChangedCommand
		/// </summary>
		public ICommand themeChangedCommand;

		/// <summary>
		/// Defines the usersCommand
		/// </summary>
		public ICommand usersCommand;

		/// <summary>
		/// Defines the visitsCommand
		/// </summary>
		public ICommand visitsCommand;

		/// <summary>
		/// Defines the isDarkTheme
		/// </summary>
		private bool isDarkTheme;

		/// <summary>
		/// Defines the userName
		/// </summary>
		private string userName;

		/// <summary>
		/// Initializes a new instance of the <see cref="MasterViewModel"/> class.
		/// </summary>
		/// <param name="dialogService">The dialogService<see cref="IDialogService"/></param>
		/// <param name="appSettings">The appSettings<see cref="IAppSettings"/></param>
		/// <param name="viewLocator">The viewLocator<see cref="IViewLocator"/></param>
		/// <param name="navigationService">The navigationService<see cref="INavigationService"/></param>
		public MasterViewModel(
			IDialogService dialogService,
			IAppSettings appSettings,
			IViewLocator viewLocator,
			INavigationService navigationService)
		{
			this.LogoutCommand = new Command(() => this.Logout());
			this.dialogService = dialogService;
			this.appSettings = appSettings;
			this.viewLocator = viewLocator;
			this.navigationService = navigationService;
		}

		/// <summary>
		/// Gets or sets a value indicating whether IsDarkTheme
		/// </summary>
		public bool IsDarkTheme
		{
			get { return this.isDarkTheme; }
			set
			{
				this.SetProperty(ref this.isDarkTheme, value);
			}
		}

		/// <summary>
		/// Gets the LogoutCommand
		/// </summary>
		public ICommand LogoutCommand { get; }

		/// <summary>
		/// Gets the MyVisitsCommand
		/// </summary>
		public ICommand MyVisitsCommand
		{
			get
			{
				if (this.myVisitsCommand == null)
				{
					this.myVisitsCommand = new Command(() => this.MyVisits());
				}

				return this.myVisitsCommand;
			}
		}

		/// <summary>
		/// Gets the OutletsCommand
		/// </summary>
		public ICommand OutletsCommand
		{
			get
			{
				if (this.outletsCommand == null)
				{
					this.outletsCommand = new Command(() => this.Outlets());
				}

				return this.outletsCommand;
			}
		}

		/// <summary>
		/// Gets the ThemeChangedCommand
		/// </summary>
		public ICommand ThemeChangedCommand
		{
			get
			{
				if (this.themeChangedCommand == null)
				{
					this.themeChangedCommand = new Command(() => this.ThemeChanged());
				}

				return this.themeChangedCommand;
			}
		}

		/// <summary>
		/// Gets or sets the UserName
		/// </summary>
		public string UserName
		{
			get { return userName; }
			set
			{
				this.SetProperty(ref userName, value);
			}
		}

		/// <summary>
		/// Gets the UsersCommand
		/// </summary>
		public ICommand UsersCommand
		{
			get
			{
				if (this.usersCommand == null)
				{
					this.usersCommand = new Command(() => this.Users());
				}

				return this.usersCommand;
			}
		}

		/// <summary>
		/// Gets the VisitsCommand
		/// </summary>
		public ICommand VisitsCommand
		{
			get
			{
				if (this.visitsCommand == null)
				{
					this.visitsCommand = new Command(() => this.Visits());
				}

				return this.visitsCommand;
			}
		}

		/// <summary>
		/// The BeforeFirstShown
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		public async override Task BeforeFirstShown()
		{
			await Task.Run(() =>
			{
				this.IsDarkTheme = App.AppTheme == Theme.Dark;
				this.UserName = this.appSettings.Get("Name");
			});
		}

		/// <summary>
		/// The Logout
		/// </summary>
		private void Logout()
		{
			this.appSettings.Set("Token", null);
			this.appSettings.Set("Name", null);
			LoginViewModel viewModel = null;
			this.navigationService.PresentAsNavigatableMainPage<LoginViewModel>(ref viewModel);
		}

		/// <summary>
		/// The MyVisits
		/// </summary>
		private void MyVisits()
		{
			try
			{
				var vm = this.viewLocator.GetViewModel<VisitsViewModel>();
				vm.IsPersonalView = true;
				this.navigationService.NavigateTo(vm);
			}
			catch (Exception ex)
			{
				this.dialogService.ShowAlertAsync(ex.Message, "My Fort", "OK");
			}
		}

		/// <summary>
		/// The Outlets
		/// </summary>
		private void Outlets()
		{
			try
			{
				var vm = this.viewLocator.GetViewModel<OutletsViewModel>();
				this.navigationService.NavigateTo(vm);
			}
			catch (Exception ex)
			{
				this.dialogService.ShowAlertAsync(ex.Message, "My Fort", "OK");
			}
		}

		/// <summary>
		/// The ThemeChanged
		/// </summary>
		private void ThemeChanged()
		{
			this.appSettings.Set("Theme", this.IsDarkTheme ? "Dark" : "Light");
			MessagingCenter.Send<object, Theme>(this, "ModeChanged", this.IsDarkTheme ? Theme.Dark : Theme.Light);
		}

		/// <summary>
		/// The Users
		/// </summary>
		private void Users()
		{
			try
			{
				var vm = this.viewLocator.GetViewModel<UsersViewModel>();
				this.navigationService.NavigateTo(vm);
			}
			catch (Exception ex)
			{
				this.dialogService.ShowAlertAsync(ex.Message, "My Fort", "OK");
			}
		}

		/// <summary>
		/// The Visits
		/// </summary>
		private void Visits()
		{
			try
			{
				var vm = this.viewLocator.GetViewModel<VisitsViewModel>();
				vm.IsPersonalView = false;
				this.navigationService.NavigateTo(vm);
			}
			catch (Exception ex)
			{
				this.dialogService.ShowAlertAsync(ex.Message, "My Fort", "OK");
			}
		}
	}
}
