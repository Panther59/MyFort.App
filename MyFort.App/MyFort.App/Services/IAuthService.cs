// <copyright file="IAuthService.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-11</date>

namespace MyFort.App.Services
{
	using MyFort.App.Models;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IAuthService" />
    /// </summary>
    public interface IAuthService
	{
		/// <summary>
		/// The Authenticate
		/// </summary>
		/// <param name="request">The request<see cref="AuthRequest"/></param>
		/// <returns>The <see cref="AuthResponse"/></returns>
		Task<APIResponse<AuthResponse>> Authenticate(AuthRequest request);

		/// <summary>
		/// The CurrentUser
		/// </summary>
		/// <returns>The <see cref="User"/></returns>
		Task<APIResponse<User>> CurrentUser();

		/// <summary>
		/// The Register
		/// </summary>
		/// <param name="user">The user<see cref="AuthResponse"/></param>
		Task Register(AuthResponse user);
	}
}
