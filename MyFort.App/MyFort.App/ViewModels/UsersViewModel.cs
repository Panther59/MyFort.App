// <copyright file="UsersViewModel.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-12</date>

namespace MyFort.App.ViewModels
{
	using MyFort.App.Models;
	using MyFort.App.Navigation;
	using MyFort.App.Services;
	using System;
	using System.Collections.ObjectModel;
	using System.Threading.Tasks;
	using System.Windows.Input;
	using Xamarin.Forms;

	/// <summary>
	/// Defines the <see cref="UsersViewModel" />
	/// </summary>
	public class UsersViewModel : BaseViewModel
	{
		/// <summary>
		/// Defines the navigationService
		/// </summary>
		private readonly INavigationService navigationService;

		/// <summary>
		/// Defines the usersService
		/// </summary>
		private readonly IUsersService usersService;

		/// <summary>
		/// Defines the viewLocator
		/// </summary>
		private readonly IViewLocator viewLocator;

		/// <summary>
		/// Defines the modifyUserCommand
		/// </summary>
		public ICommand modifyUserCommand;

		/// <summary>
		/// Defines the users
		/// </summary>
		private ObservableCollection<User> users;

		/// <summary>
		/// Initializes a new instance of the <see cref="UsersViewModel"/> class.
		/// </summary>
		/// <param name="usersService">The usersService<see cref="IUsersService"/></param>
		/// <param name="viewLocator">The viewLocator<see cref="IViewLocator"/></param>
		/// <param name="navigationService">The navigationService<see cref="INavigationService"/></param>
		public UsersViewModel(
			IUsersService usersService,
			IViewLocator viewLocator,
			INavigationService navigationService)
		{
			this.usersService = usersService;
			this.viewLocator = viewLocator;
			this.navigationService = navigationService;
		}

		/// <summary>
		/// Gets the ModifyUserCommand
		/// </summary>
		public ICommand ModifyUserCommand
		{
			get
			{
				if (this.modifyUserCommand == null)
				{
					this.modifyUserCommand = new Command<User>((u) => this.ModifyUser(u));
				}

				return this.modifyUserCommand;
			}
		}

		/// <summary>
		/// Gets or sets the Users
		/// </summary>
		public ObservableCollection<User> Users
		{
			get { return this.users; }
			set
			{
				this.SetProperty(ref this.users, value);
			}
		}

		/// <summary>
		/// The BeforeFirstShown
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		public async override Task BeforeFirstShown()
		{
			try
			{
				var response = await this.usersService.GetAllUsers();
				if (response.IsSuccess)
				{
					this.Users = new ObservableCollection<User>(response.Result);
				}
			}
			catch (Exception ex)
			{

			}
		}

		/// <summary>
		/// The ModifyUser
		/// </summary>
		/// <param name="user">The user<see cref="User"/></param>
		private void ModifyUser(User user)
		{
			var vm = this.viewLocator.GetViewModel<UserDetailViewModel>();
			vm.User = user;
			this.navigationService.NavigateTo(vm);
		}
	}
}
