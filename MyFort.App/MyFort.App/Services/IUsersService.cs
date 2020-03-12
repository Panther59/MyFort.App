// <copyright file="IUsersService.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-11</date>

namespace MyFort.App.Services
{
	using MyFort.App.Models;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	/// <summary>
	/// Defines the <see cref="IAuthService" />
	/// </summary>
	public interface IUsersService
	{
		/// <summary>
		/// The GetAllUsers
		/// </summary>
		/// <returns>The <see cref="Task{APIResponse{List{User}}}"/></returns>
		Task<APIResponse<List<User>>> GetAllUsers();

		/// <summary>
		/// The UpdateUser
		/// </summary>
		/// <param name="user">The user<see cref="User"/></param>
		/// <returns>The <see cref="Task{APIResponse}"/></returns>
		Task<APIResponse> UpdateUser(User user);
	}
}
