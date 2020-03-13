// <copyright file="IVisitsService.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-13</date>

namespace MyFort.App.Services
{
	using MyFort.App.Models;
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	/// <summary>
	/// Defines the <see cref="IVisitService" />
	/// </summary>
	public interface IVisitsService
	{
		/// <summary>
		/// The AddVisit
		/// </summary>
		/// <param name="Visit">The Visit<see cref="Visit"/></param>
		/// <returns>The <see cref="Task{APIResponse}"/></returns>
		Task<APIResponse> AddVisit(Visit Visit);

		/// <summary>
		/// The GetAllMyVisits
		/// </summary>
		/// <param name="dateTime">The dateTime<see cref="DateTime"/></param>
		/// <returns>The <see cref="Task{APIResponse{List{Visit}}}"/></returns>
		Task<APIResponse<List<Visit>>> GetAllMyVisits(DateTime dateTime);

		/// <summary>
		/// The GetAllVisits
		/// </summary>
		/// <param name="dateTime">The dateTime<see cref="DateTime"/></param>
		/// <returns>The <see cref="Task{APIResponse{List{Visit}}}"/></returns>
		Task<APIResponse<List<Visit>>> GetAllVisits(DateTime dateTime);
	}
}
