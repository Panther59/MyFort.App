// <copyright file="HomeViewModel.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-14</date>

namespace MyFort.App.ViewModels
{
	using MyFort.App.Navigation;
	using MyFort.App.Services;
	using System.Threading.Tasks;
	using System.Windows.Input;
	using Xamarin.Forms;

	/// <summary>
	/// Defines the <see cref="HomeViewModel" />
	/// </summary>
	public class HomeViewModel : BaseViewModel
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
		/// Defines the addVisitCommand
		/// </summary>
		public ICommand addVisitCommand;

		/// <summary>
		/// Initializes a new instance of the <see cref="HomeViewModel"/> class.
		/// </summary>
		/// <param name="viewLocator">The viewLocator<see cref="IViewLocator"/></param>
		/// <param name="dialogService">The dialogService<see cref="IDialogService"/></param>
		/// <param name="navigationService">The navigationService<see cref="INavigationService"/></param>
		public HomeViewModel(
			IViewLocator viewLocator,
			IDialogService dialogService,
			INavigationService navigationService)
		{
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
					this.addVisitCommand = new Command(async () => await this.AddVisit());
				}

				return this.addVisitCommand;
			}
		}

		/// <summary>
		/// The AddVisit
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		private async Task AddVisit()
		{
			var vm = this.viewLocator.GetViewModel<VisitDetailViewModel>();
			await this.navigationService.NavigateTo(vm);
		}
	}
}
