// <copyright file="OutletService.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-13</date>

namespace MyFort.App.Services
{
	using MyFort.App.Models;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class OutletService : BaseAPIService, IOutletService
	{
		public OutletService(IAppSettings appSettings) : base(appSettings)
		{
		}

		public Task<APIResponse> AddOutlet(Outlet outlet)
		{
			return this.PostAsync(this.BaseUrl + "outlets/new", outlet);
		}

		public Task<APIResponse<List<Outlet>>> GetAllOutlets()
		{
			return this.GetAsync<List<Outlet>>(this.BaseUrl + "outlets");
		}

		public Task<APIResponse> UpdateOutlet(Outlet outlet)
		{
			return this.PostAsync(this.BaseUrl + "outlets/update", outlet);
		}
	}
}
