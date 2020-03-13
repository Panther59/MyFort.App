// <copyright file="OutletDetailViewModel.cs" company="Ayvan">
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
    using System.Windows.Input;
	using Xamarin.Forms;

	/// <summary>
	/// Defines the <see cref="OutletDetailViewModel" />
	/// </summary>
	public class OutletDetailViewModel : BaseViewModel
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
		/// Defines the saveOutletCommand
		/// </summary>
		public ICommand saveOutletCommand;

		/// <summary>
		/// Defines the isAdd
		/// </summary>
		private bool isAdd;

		/// <summary>
		/// Defines the outlet
		/// </summary>
		private Outlet outlet;

		/// <summary>
		/// Initializes a new instance of the <see cref="OutletDetailViewModel"/> class.
		/// </summary>
		/// <param name="dialogService">The dialogService<see cref="IDialogService"/></param>
		/// <param name="navigationService">The navigationService<see cref="INavigationService"/></param>
		/// <param name="outletService">The outletService<see cref="IOutletService"/></param>
		public OutletDetailViewModel(
			IDialogService dialogService,
			INavigationService navigationService,
			IOutletService outletService)
		{
			this.dialogService = dialogService;
			this.navigationService = navigationService;
			this.outletService = outletService;
		}

		/// <summary>
		/// Gets or sets a value indicating whether IsAdd
		/// </summary>
		public bool IsAdd
		{
			get { return this.isAdd; }
			set
			{
				this.SetProperty(ref this.isAdd, value);
			}
		}

		/// <summary>
		/// Gets or sets the Outlet
		/// </summary>
		public Outlet Outlet
		{
			get { return this.outlet; }
			set
			{
				this.SetProperty(ref this.outlet, value);
			}
		}

		/// <summary>
		/// Gets the SaveOutletCommand
		/// </summary>
		public ICommand SaveOutletCommand
		{
			get
			{
				if (this.saveOutletCommand == null)
				{
					this.saveOutletCommand = new Command(() => this.SaveOutlet());
				}

				return this.saveOutletCommand;
			}
		}

		/// <summary>
		/// The Initialize
		/// </summary>
		/// <param name="outlet">The outlet<see cref="Outlet"/></param>
		public void Initialize(Outlet outlet = null)
		{
			this.IsAdd = outlet == null;
			this.Title = outlet?.Name ?? "Add Outlet";
			this.Outlet = outlet ?? new Outlet();
		}

		/// <summary>
		/// The SaveOutlet
		/// </summary>
		private async void SaveOutlet()
		{
			try
			{
				if (string.IsNullOrEmpty(this.Outlet.Name))
				{
					await this.dialogService.ShowAlertAsync("Please enter name of outlet", "Outlet", "OK");
					return;
				}

				if (string.IsNullOrEmpty(this.Outlet.Location))
				{
					await this.dialogService.ShowAlertAsync("Please enter location of outlet", "Outlet", "OK");
					return;
				}

				this.IsBusy = true;
				APIResponse response = null;
				if (this.IsAdd)
				{
					response = await this.outletService.AddOutlet(this.Outlet);
				}
				else
				{
					response = await this.outletService.UpdateOutlet(this.Outlet);
				}

				if (response.IsSuccess)
				{
					this.IsBusy = false;
					await this.navigationService.NavigateBack();
				}
				else
				{
					this.IsBusy = false;
					await this.dialogService.ShowAlertAsync(response.Error?.Error ?? "Error occured while saving", "Save Outlet", "OK");
				}
			}
			catch (Exception ex)
			{
				this.IsBusy = false;
				await this.dialogService.ShowAlertAsync(ex.Message, "Save Outlet", "OK");
			}
		}
	}
}
