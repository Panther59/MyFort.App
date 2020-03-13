// <copyright file="VisitDetailViewModel.cs" company="Ayvan">
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
	/// Defines the <see cref="VisitDetailViewModel" />
	/// </summary>
	public class VisitDetailViewModel : BaseViewModel
	{
		private readonly IVisitsService visitsService;

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
		/// Defines the outletSelectionChangedCommand
		/// </summary>
		public ICommand outletSelectionChangedCommand;

		/// <summary>
		/// Defines the saveVisitCommand
		/// </summary>
		public ICommand saveVisitCommand;

		/// <summary>
		/// Defines the meetingWith
		/// </summary>
		private string meetingWith;

		/// <summary>
		/// Defines the note
		/// </summary>
		private string note;

		/// <summary>
		/// Defines the outlets
		/// </summary>
		private List<Outlet> outlets;

		/// <summary>
		/// Defines the selectedOutlet
		/// </summary>
		private Outlet selectedOutlet;

		/// <summary>
		/// Initializes a new instance of the <see cref="VisitDetailViewModel"/> class.
		/// </summary>
		/// <param name="dialogService">The dialogService<see cref="IDialogService"/></param>
		/// <param name="navigationService">The navigationService<see cref="INavigationService"/></param>
		/// <param name="outletService">The outletService<see cref="IOutletService"/></param>
		public VisitDetailViewModel(
			IVisitsService visitsService,
			IDialogService dialogService,
			INavigationService navigationService,
			IOutletService outletService)
		{
			this.visitsService = visitsService;
			this.dialogService = dialogService;
			this.navigationService = navigationService;
			this.outletService = outletService;
		}

		/// <summary>
		/// Gets or sets the MeetingWith
		/// </summary>
		public string MeetingWith
		{
			get { return this.meetingWith; }
			set
			{
				this.SetProperty(ref this.meetingWith, value);
			}
		}

		/// <summary>
		/// Gets or sets the Note
		/// </summary>
		public string Note
		{
			get { return this.note; }
			set
			{
				this.SetProperty(ref this.note, value);
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
		/// Gets the OutletSelectionChangedCommand
		/// </summary>
		public ICommand OutletSelectionChangedCommand
		{
			get
			{
				if (this.outletSelectionChangedCommand == null)
				{
					this.outletSelectionChangedCommand = new Command(() => this.OutletSelectionChanged());
				}

				return this.outletSelectionChangedCommand;
			}
		}

		/// <summary>
		/// Gets the SaveVisitCommand
		/// </summary>
		public ICommand SaveVisitCommand
		{
			get
			{
				if (this.saveVisitCommand == null)
				{
					this.saveVisitCommand = new Command(async () => await this.SaveVisit());
				}

				return this.saveVisitCommand;
			}
		}

		/// <summary>
		/// Gets or sets the SelectedOutlet
		/// </summary>
		public Outlet SelectedOutlet
		{
			get { return this.selectedOutlet; }
			set
			{
				this.SetProperty(ref this.selectedOutlet, value);
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
				var response = await this.outletService.GetAllOutlets();
				if (response.IsSuccess)
				{
					this.Outlets = response.Result;
				}
				else
				{
					await this.dialogService.ShowAlertAsync(response.Error?.Error ?? "Error loading outlets for Visit", "Outlets Load", "OK");
				}
			}
			catch (Exception ex)
			{
				await this.dialogService.ShowAlertAsync(ex.Message, "Visits", "OK");
			}
		}

		/// <summary>
		/// The OutletSelectionChanged
		/// </summary>
		private void OutletSelectionChanged()
		{
			if (this.SelectedOutlet != null)
			{
				this.MeetingWith = this.SelectedOutlet.ContactName;
			}
		}

		/// <summary>
		/// The SaveVisit
		/// </summary>
		private async Task SaveVisit()
		{
			try
			{
				if (this.SelectedOutlet == null)
				{
					await this.dialogService.ShowAlertAsync("Select outlet you visited", "Save Visit", "OK");
					return;
				}

				if (string.IsNullOrEmpty(this.Note))
				{
					await this.dialogService.ShowAlertAsync("Enter meeting note before saving", "Save Visit", "OK");
					return;
				}

				this.IsBusy = true;
				var request = new Visit
				{
					MeetingWith = this.MeetingWith != null ? this.MeetingWith.Trim() : string.Empty,
					Notes = this.Note != null?  this.Note.Trim() : string.Empty,
					Outlet = this.SelectedOutlet,
				};

				var response = await this.visitsService.AddVisit(request);
				this.IsBusy = false;
				if (response.IsSuccess)
				{
					await this.dialogService.ShowAlertAsync("Visit added.", "Save Visit", "OK");
					await this.navigationService.NavigateBack();
				}
				else
				{
					await this.dialogService.ShowAlertAsync(response.Error?.Error ?? "Error saving visit", "Save Visit", "OK");
				}
			}
			catch (Exception ex)
			{
				this.IsBusy = false;
				await this.dialogService.ShowAlertAsync(ex.Message, "Save Visit", "OK");
			}
		}
	}
}
