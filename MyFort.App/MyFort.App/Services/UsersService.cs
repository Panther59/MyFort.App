// <copyright file="UsersService.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-12</date>

namespace MyFort.App.Services
{
	using MyFort.App.Models;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	/// <summary>
	/// Defines the <see cref="UsersService" />
	/// </summary>
	public class UsersService : BaseAPIService, IUsersService
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UsersService"/> class.
		/// </summary>
		/// <param name="appSettings">The appSettings<see cref="IAppSettings"/></param>
		public UsersService(IAppSettings appSettings) : base(appSettings)
		{
		}

		/// <inheritdoc/>
		public async Task<APIResponse<List<User>>> GetAllUsers()
		{
			return await this.GetAsync<List<User>>(this.BaseUrl + "users");
		}

		/// <inheritdoc/>
		public async Task<APIResponse> UpdateUser(User user)
		{
			return await this.PostAsync(this.BaseUrl + "users", user);
		}
	}
}
