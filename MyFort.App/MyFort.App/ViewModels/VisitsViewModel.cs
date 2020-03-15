// <copyright file="VisitsViewModel.cs" company="Ayvan">
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
	/// Defines the <see cref="VisitsViewModel" />
	/// </summary>
	public class VisitsViewModel : BaseViewModel
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
		/// Defines the viewLocator
		/// </summary>
		private readonly IViewLocator viewLocator;

		/// <summary>
		/// Defines the visitsService
		/// </summary>
		private readonly IVisitsService visitsService;

		/// <summary>
		/// Defines the addVisitCommand
		/// </summary>
		public ICommand addVisitCommand;

		/// <summary>
		/// Defines the getVisitsCommand
		/// </summary>
		public ICommand getVisitsCommand;

		/// <summary>
		/// Defines the businessDate
		/// </summary>
		private DateTime businessDate;

		/// <summary>
		/// Defines the isNoVisits
		/// </summary>
		private bool isNoVisits;

		/// <summary>
		/// Defines the visits
		/// </summary>
		private List<Visit> visits;

		/// <summary>
		/// Initializes a new instance of the <see cref="VisitsViewModel"/> class.
		/// </summary>
		/// <param name="visitsService">The visitsService<see cref="IVisitsService"/></param>
		/// <param name="viewLocator">The viewLocator<see cref="IViewLocator"/></param>
		/// <param name="dialogService">The dialogService<see cref="IDialogService"/></param>
		/// <param name="navigationService">The navigationService<see cref="INavigationService"/></param>
		public VisitsViewModel(
			IVisitsService visitsService,
			IViewLocator viewLocator,
			IDialogService dialogService,
			INavigationService navigationService)
		{
			this.visitsService = visitsService;
			this.viewLocator = viewLocator;
			this.dialogService = dialogService;
			this.navigationService = navigationService;
		}

		/// <summary>
		/// Gets the AddVisitCommand
		/// </summary>
		public ICommand AddVisitCommand
		{
			get
			{
				if (this.addVisitCommand == null)
				{
					this.addVisitCommand = new Command(() => this.AddVisit());
				}

				return this.addVisitCommand;
			}
		}

		/// <summary>
		/// Gets or sets the BusinessDate
		/// </summary>
		public DateTime BusinessDate
		{
			get { return this.businessDate; }
			set
			{
				this.SetProperty(ref this.businessDate, value);
			}
		}

		/// <summary>
		/// Gets the GetVisitsCommand
		/// </summary>
		public ICommand GetVisitsCommand
		{
			get
			{
				if (this.getVisitsCommand == null)
				{
					this.getVisitsCommand = new Command(async () => await this.GetVisits());
				}

				return this.getVisitsCommand;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether IsNoVisits
		/// </summary>
		public bool IsNoVisits
		{
			get { return this.isNoVisits; }
			set
			{
				this.SetProperty(ref this.isNoVisits, value);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether IsPersonalView
		/// </summary>
		public bool IsPersonalView { get; set; }

		/// <summary>
		/// Gets or sets the Visits
		/// </summary>
		public List<Visit> Visits
		{
			get { return this.visits; }
			set
			{
				this.SetProperty(ref this.visits, value);
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
				this.BusinessDate = DateTime.Now;
				this.Title = this.IsPersonalView ? "My Visits" : "Visits";
				await this.GetVisits();
			}
			catch (Exception ex)
			{
				await this.dialogService.ShowAlertAsync(ex.Message, "Visits", "OK");
			}
		}

		/// <summary>
		/// The BeforeNavigatedBack
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		public async override Task BeforeNavigatedBack()
		{
			try
			{
				await this.GetVisits();
			}
			catch (Exception ex)
			{
				await this.dialogService.ShowAlertAsync(ex.Message, "Visits", "OK");
			}
		}

		/// <summary>
		/// The AddVisit
		/// </summary>
		private void AddVisit()
		{
			var vm = this.viewLocator.GetViewModel<VisitDetailViewModel>();
			this.navigationService.NavigateTo(vm);
		}

		/// <summary>
		/// The GetVisits
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		private async Task GetVisits()
		{
			try
			{
				APIResponse<List<Visit>> response = null;
				if (this.IsPersonalView)
				{
					response = await this.visitsService.GetAllMyVisits(this.BusinessDate);
				}
				else
				{
					response = await this.visitsService.GetAllVisits(this.BusinessDate);
				}

				if (response.IsSuccess)
				{
					this.Visits = response.Result;
					if (this.Visits != null && this.Visits.Count > 0)
					{
						this.IsNoVisits = false;
					}
					else
					{
						this.IsNoVisits = true;
					}
				}
				else
				{
					await this.dialogService.ShowAlertAsync(response.Error?.Error ?? "Error loading visits", "Visits", "OK");
				}
			}
			catch (Exception ex)
			{
				await this.dialogService.ShowAlertAsync(ex.Message, "Visits", "OK");
			}
		}
	}
}
