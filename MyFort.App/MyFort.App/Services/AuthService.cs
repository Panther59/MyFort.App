﻿// <copyright file="AuthService.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-11</date>

namespace MyFort.App.Services
{
	using MyFort.App.Models;
	using System.Threading.Tasks;

	/// <summary>
	/// Defines the <see cref="AuthService" />
	/// </summary>
	public class AuthService : BaseAPIService, IAuthService
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AuthService"/> class.
		/// </summary>
		/// <param name="appSettings">The appSettings<see cref="IAppSettings"/></param>
		public AuthService(IAppSettings appSettings) : base(appSettings)
		{
		}

		/// <summary>
		/// The Authenticate
		/// </summary>
		/// <param name="request">The request<see cref="AuthRequest"/></param>
		/// <returns>The <see cref="Task{AuthResponse}"/></returns>
		public async Task<APIResponse<AuthResponse>> Authenticate(AuthRequest request)
		{
			return await this.PostAsync<AuthResponse>(this.BaseUrl + "users/authenticate", request);
		}

		/// <summary>
		/// The CurrentUser
		/// </summary>
		/// <returns>The <see cref="Task{User}"/></returns>
		public async Task<APIResponse<User>> CurrentUser()
		{
			return await this.GetAsync<User>(this.BaseUrl + "users/current");
		}

		/// <summary>
		/// The Register
		/// </summary>
		/// <param name="user">The user<see cref="RegisterUser"/></param>
		/// <returns>The <see cref="Task"/></returns>
		public async Task<APIResponse> Register(RegisterUser user)
		{
			return await this.PostAsync(this.BaseUrl + "users/register", user);
		}
	}
}
