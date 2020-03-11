// <copyright file="INavigationService.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-11</date>

namespace MyFort.App.Navigation
{
	using MyFort.App.ViewModels;
	using System.Threading.Tasks;
	using Xamarin.Forms;

	/// <summary>
	/// Defines the <see cref="INavigationService" />
	/// </summary>
	public interface INavigationService
	{
		/// <summary>
		/// Navigate to the previous item in the navigation stack
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		Task NavigateBack();

		/// <summary>
		/// Navigate back to the element at the root of the navigation stack
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		Task NavigateBackToRoot();

		/// <summary>
		/// Navigate to the given page on top of the current navigation stack
		/// </summary>
		/// <param name="viewModel">The viewModel<see cref="BaseViewModel"/></param>
		/// <returns>The <see cref="Task"/></returns>
		Task NavigateTo(BaseViewModel viewModel);

		/// <summary>
		/// Sets the viewmodel to be the main page of the application
		/// </summary>
		/// <param name="viewModel">The viewModel<see cref="BaseViewModel"/></param>
		void PresentAsMainPage(BaseViewModel viewModel);

		/// <summary>
		/// Sets the viewmodel as the main page of the application, and wraps its page within a Navigation page
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <param name="">The <see cref="viewModel"/></param>
		/// <returns>The <see cref="Page"/></returns>
		Page PresentAsNavigatableMainPage<TViewModel>(ref TViewModel viewModel) where TViewModel : BaseViewModel;
	}
}
