// <copyright file="IViewModelLifecycle.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-11</date>

namespace MyFort.App.ViewModels
{
	using System.Threading.Tasks;

	/// <summary>
	/// Defines the <see cref="IViewModelLifecycle" />
	/// </summary>
	public interface IViewModelLifecycle
	{
		/// <summary>
		/// Called exactly once, when the viewmodel leaves the navigation stack
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		Task AfterDismissed();

		/// <summary>
		/// Called exactly once, before the viewmodel enters the navigation stack
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		Task BeforeFirstShown();
	}
}
