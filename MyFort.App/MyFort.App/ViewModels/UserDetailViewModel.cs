// <copyright file="UserDetailViewModel.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-13</date>

namespace MyFort.App.ViewModels
{
	using MyFort.App.Models;
	using MyFort.App.Navigation;
	using MyFort.App.Services;
	using System;
	using System.Threading.Tasks;
	using System.Windows.Input;
	using Xamarin.Forms;

	/// <summary>
	/// Defines the <see cref="UserDetailViewModel" />
	/// </summary>
	public class UserDetailViewModel : BaseViewModel
	{
		/// <summary>
		/// Defines the dialogService
		/// </summary>
		private readonly IDialogService dialogService;

		/// <summary>
		/// Defines the navigationService
		/// </summary>
		private readonly INavigationService navigationService;

		/// <summary>
		/// Defines the usersService
		/// </summary>
		private readonly IUsersService usersService;

		/// <summary>
		/// Defines the saveUserCommand
		/// </summary>
		public ICommand saveUserCommand;

		/// <summary>
		/// Defines the user
		/// </summary>
		private User user;

		/// <summary>
		/// Defines the userViewModel
		/// </summary>
		private UsersViewModel userViewModel;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserDetailViewModel"/> class.
		/// </summary>
		/// <param name="dialogService">The dialogService<see cref="IDialogService"/></param>
		/// <param name="navigationService">The navigationService<see cref="INavigationService"/></param>
		/// <param name="usersService">The usersService<see cref="IUsersService"/></param>
		public UserDetailViewModel(
			IDialogService dialogService,
			INavigationService navigationService,
			IUsersService usersService)
		{
			this.dialogService = dialogService;
			this.navigationService = navigationService;
			this.usersService = usersService;
		}

		/// <summary>
		/// Gets the SaveUserCommand
		/// </summary>
		public ICommand SaveUserCommand
		{
			get
			{
				if (this.saveUserCommand == null)
				{
					this.saveUserCommand = new Command(async () => await this.SaveUser());
				}

				return this.saveUserCommand;
			}
		}

		/// <summary>
		/// Gets or sets the User
		/// </summary>
		public User User
		{
			get { return this.user; }
			set
			{
				this.SetProperty(ref this.user, value);
			}
		}

		/// <summary>
		/// The Initialize
		/// </summary>
		/// <param name="user">The user<see cref="User"/></param>
		/// <param name="vm">The vm<see cref="UsersViewModel"/></param>
		public void Initialize(User user, UsersViewModel vm)
		{
			this.User = user;
			this.userViewModel = vm;
			this.Title = this.User.FirstName + " " + this.User.LastName;
		}

		/// <summary>
		/// The SaveUser
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		private async Task SaveUser()
		{
			try
			{
				this.IsBusy = true;
				var response = await this.usersService.UpdateUser(user);
				if (response.IsSuccess)
				{
					this.IsBusy = false;
					await this.userViewModel.BeforeFirstShown();
					await this.navigationService.NavigateBack();
				}
				else
				{
					this.IsBusy = false;
					await this.dialogService.ShowAlertAsync(response.Error?.Error ?? "Error occured in updating user", "Update User", "OK");
				}
			}
			catch (Exception ex)
			{
				this.IsBusy = false;
				await this.dialogService.ShowAlertAsync(ex.Message, "Update User", "OK");
			}
		}
	}
}
