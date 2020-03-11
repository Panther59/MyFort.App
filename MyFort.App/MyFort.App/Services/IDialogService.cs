// <copyright file="IDialogService.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-11</date>

namespace MyFort.App.Services
{
	using System.Threading.Tasks;

	/// <summary>
	/// Defines the <see cref="IDialogService" />
	/// </summary>
	public interface IDialogService
	{
		/// <summary>
		/// The ShowAlertAsync
		/// </summary>
		/// <param name="message">The message<see cref="string"/></param>
		/// <param name="title">The title<see cref="string"/></param>
		/// <param name="buttonLabel">The buttonLabel<see cref="string"/></param>
		/// <returns>The <see cref="Task"/></returns>
		Task ShowAlertAsync(string message, string title, string buttonLabel);
	}
}
