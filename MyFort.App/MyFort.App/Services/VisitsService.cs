// <copyright file="VisitsService.cs" company="Ayvan">
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
	/// Defines the <see cref="VisitsService" />
	/// </summary>
	public class VisitsService : BaseAPIService, IVisitsService
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="VisitsService"/> class.
		/// </summary>
		/// <param name="appSettings">The appSettings<see cref="IAppSettings"/></param>
		public VisitsService(IAppSettings appSettings) : base(appSettings)
		{
		}

		/// <summary>
		/// The AddVisit
		/// </summary>
		/// <param name="Visit">The Visit<see cref="Visit"/></param>
		/// <returns>The <see cref="Task{APIResponse}"/></returns>
		public Task<APIResponse> AddVisit(Visit Visit)
		{
			return this.PostAsync(this.BaseUrl + "Visits/new", Visit);
		}

		/// <summary>
		/// The GetAllMyVisits
		/// </summary>
		/// <param name="dateTime">The dateTime<see cref="DateTime"/></param>
		/// <returns>The <see cref="Task{APIResponse{List{Visit}}}"/></returns>
		public Task<APIResponse<List<Visit>>> GetAllMyVisits(DateTime dateTime)
		{
			return this.PostAsync<List<Visit>>(this.BaseUrl + "visits/mine", dateTime);
		}

		/// <summary>
		/// The GetAllVisits
		/// </summary>
		/// <param name="dateTime">The dateTime<see cref="DateTime"/></param>
		/// <returns>The <see cref="Task{APIResponse{List{Visit}}}"/></returns>
		public Task<APIResponse<List<Visit>>> GetAllVisits(DateTime dateTime)
		{
			return this.PostAsync<List<Visit>>(this.BaseUrl + "visits", dateTime);
		}
	}
}
