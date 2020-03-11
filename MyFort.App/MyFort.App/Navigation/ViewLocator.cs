// <copyright file="ViewLocator.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-11</date>

namespace MyFort.App.Navigation
{
	using MyFort.App.ViewModels;
	using System;
	using Unity;	
	using Xamarin.Forms;

	/// <summary>
	/// Defines the <see cref="ViewLocator" />
	/// </summary>
	public class ViewLocator : IViewLocator
	{
		/// <summary>
		/// The CreateAndBindPageFor
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <returns>The <see cref="Page"/></returns>
		public Page CreateAndBindPageFor<TViewModel>() where TViewModel : BaseViewModel
		{
			var viewModel = App.Container.Resolve(typeof(TViewModel)) as TViewModel;

			return this.CreateAndBindPageFor(viewModel);
		}

		/// <summary>
		/// The CreateAndBindPageFor
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <param name="viewModel">The viewModel<see cref="TViewModel"/></param>
		/// <returns>The <see cref="Page"/></returns>
		public Page CreateAndBindPageFor<TViewModel>(TViewModel viewModel) where TViewModel : BaseViewModel
		{
			var pageType = FindPageForViewModel(viewModel.GetType());

			var page = (Page)Activator.CreateInstance(pageType);

			page.BindingContext = viewModel;

			return page;
		}

		/// <summary>
		/// The GetViewModel
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <returns>The <see cref="TViewModel"/></returns>
		public TViewModel GetViewModel<TViewModel>() where TViewModel : BaseViewModel
		{
			var viewModel = App.Container.Resolve(typeof(TViewModel));

			return viewModel as TViewModel;
		}

		/// <summary>
		/// The FindPageForViewModel
		/// </summary>
		/// <param name="viewModelType">The viewModelType<see cref="Type"/></param>
		/// <returns>The <see cref="Type"/></returns>
		protected virtual Type FindPageForViewModel(Type viewModelType)
		{
			var pageTypeName = viewModelType
				.AssemblyQualifiedName
				.Replace("ViewModel", "View");

			var pageType = Type.GetType(pageTypeName);
			if (pageType == null)
				throw new ArgumentException(pageTypeName + " type does not exist");

			return pageType;
		}
	}
}
