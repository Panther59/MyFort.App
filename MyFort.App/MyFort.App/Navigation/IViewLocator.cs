// <copyright file="IViewLocator.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-11</date>

namespace MyFort.App.Navigation
{
	using MyFort.App.ViewModels;
	using Xamarin.Forms;

	/// <summary>
	/// Defines the <see cref="IViewLocator" />
	/// </summary>
	public interface IViewLocator
	{
		/// <summary>
		/// The CreateAndBindPageFor
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <returns>The <see cref="Page"/></returns>
		Page CreateAndBindPageFor<TViewModel>() where TViewModel : BaseViewModel;

		/// <summary>
		/// The CreateAndBindPageFor
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <param name="viewModel">The viewModel<see cref="TViewModel"/></param>
		/// <returns>The <see cref="Page"/></returns>
		Page CreateAndBindPageFor<TViewModel>(TViewModel viewModel) where TViewModel : BaseViewModel;

		/// <summary>
		/// The GetViewModel
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <returns>The <see cref="TViewModel"/></returns>
		TViewModel GetViewModel<TViewModel>() where TViewModel : BaseViewModel;
	}
}
