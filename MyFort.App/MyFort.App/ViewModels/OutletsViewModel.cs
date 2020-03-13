// <copyright file="OutletsViewModel.cs" company="Ayvan">
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
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using System.Windows.Input;
	using Xamarin.Forms;

	/// <summary>
	/// Defines the <see cref="OutletsViewModel" />
	/// </summary>
	public class OutletsViewModel : BaseViewModel
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
		/// Defines the outletService
		/// </summary>
		private readonly IOutletService outletService;

		/// <summary>
		/// Defines the viewLocator
		/// </summary>
		private readonly IViewLocator viewLocator;

		/// <summary>
		/// Defines the addOutletCommand
		/// </summary>
		public ICommand addOutletCommand;

		/// <summary>
		/// Defines the modifyOutletCommand
		/// </summary>
		public ICommand modifyOutletCommand;

		/// <summary>
		/// Defines the outlets
		/// </summary>
		private List<Outlet> outlets;

		/// <summary>
		/// Initializes a new instance of the <see cref="OutletsViewModel"/> class.
		/// </summary>
		/// <param name="dialogService">The dialogService<see cref="IDialogService"/></param>
		/// <param name="outletService">The outletService<see cref="IOutletService"/></param>
		/// <param name="viewLocator">The viewLocator<see cref="IViewLocator"/></param>
		/// <param name="navigationService">The navigationService<see cref="INavigationService"/></param>
		public OutletsViewModel(
			IDialogService dialogService,
			IOutletService outletService,
			IViewLocator viewLocator,
			INavigationService navigationService)
		{
			this.dialogService = dialogService;
			this.outletService = outletService;
			this.viewLocator = viewLocator;
			this.navigationService = navigationService;
		}

		/// <summary>
		/// Gets the AddOutletCommand
		/// </summary>
		public ICommand AddOutletCommand
		{
			get
			{
				if (this.addOutletCommand == null)
				{
					this.addOutletCommand = new Command(() => this.AddOutlet());
				}

				return this.addOutletCommand;
			}
		}

		/// <summary>
		/// Gets the ModifyOutletCommand
		/// </summary>
		public ICommand ModifyOutletCommand
		{
			get
			{
				if (this.modifyOutletCommand == null)
				{
					this.modifyOutletCommand = new Command<Outlet>((x) => this.ModifyOutlet(x));
				}

				return this.modifyOutletCommand;
			}
		}

		/// <summary>
		/// Gets or sets the Outlets
		/// </summary>
		public List<Outlet> Outlets
		{
			get { return this.outlets; }
			set
			{
				this.SetProperty(ref this.outlets, value);
			}
		}

		/// <summary>
		/// The BeforeFirstShown
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		public async override Task BeforeFirstShown()
		{
			await this.Initialise();
		}

		/// <summary>
		/// The Initialise
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		public async Task Initialise()
		{
			try
			{
				var response = await this.outletService.GetAllOutlets();
				if (response.IsSuccess)
				{
					this.Outlets = response.Result;
				}
				else
				{
					await this.dialogService.ShowAlertAsync(response.Error?.Error ?? "Error loading outlets", "Outlets Load", "OK");
				}
			}
			catch (Exception ex)
			{
				await this.dialogService.ShowAlertAsync(ex.Message, "Outlets Load", "OK");
			}
		}

		/// <summary>
		/// The AddOutlet
		/// </summary>
		private void AddOutlet()
		{
			var vm = this.viewLocator.GetViewModel<OutletDetailViewModel>();
			vm.Initialize();
			this.navigationService.NavigateTo(vm);
		}

		/// <summary>
		/// The ModifyOutlet
		/// </summary>
		private void ModifyOutlet(Outlet outlet)
		{
			var vm = this.viewLocator.GetViewModel<OutletDetailViewModel>();
			vm.Initialize(outlet);
			this.navigationService.NavigateTo(vm);
		}

		public async override Task BeforeNavigatedBack()
		{
			await this.Initialise();
		}
	}
}
