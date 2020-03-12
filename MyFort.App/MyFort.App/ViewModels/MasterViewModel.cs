// <copyright file="MasterViewModel.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-12</date>

namespace MyFort.App.ViewModels
{
	using MyFort.App.Navigation;
	using MyFort.App.Services;
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
		/// Defines the navigationService
		/// </summary>
		private readonly INavigationService navigationService;

		/// <summary>
		/// Defines the viewLocator
		/// </summary>
		private readonly IViewLocator viewLocator;

		/// <summary>
		/// Defines the userName
		/// </summary>
		private string userName;

		/// <summary>
		/// Initializes a new instance of the <see cref="MasterViewModel"/> class.
		/// </summary>
		/// <param name="appSettings">The appSettings<see cref="IAppSettings"/></param>
		/// <param name="viewLocator">The viewLocator<see cref="IViewLocator"/></param>
		/// <param name="navigationService">The navigationService<see cref="INavigationService"/></param>
		public MasterViewModel(
			IAppSettings appSettings,
			IViewLocator viewLocator,
			INavigationService navigationService)
		{
			this.LogoutCommand = new Command(() => this.Logout());
			this.appSettings = appSettings;
			this.viewLocator = viewLocator;
			this.navigationService = navigationService;
		}

		/// <summary>
		/// Gets the LogoutCommand
		/// </summary>
		public ICommand LogoutCommand { get; }

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


		public ICommand usersCommand;
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

		private void Users()
		{
			try
			{
				var vm = this.viewLocator.GetViewModel<UsersViewModel>();
				this.navigationService.NavigateTo(vm);
			}
			catch (System.Exception)
			{

			}
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

		public async override Task BeforeFirstShown()
		{
			await Task.Run(() =>
			{
				this.UserName = this.appSettings.Get("Name");
			});
		}
	}
}
