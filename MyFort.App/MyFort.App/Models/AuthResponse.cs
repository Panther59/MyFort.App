// <copyright file="AuthResponse.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-11</date>

namespace MyFort.App.Models
{
	/// <summary>
	/// Defines the <see cref="AuthResponse" />
	/// </summary>
	public class AuthResponse
	{
		/// <summary>
		/// Gets or sets the Token
		/// </summary>
		public string Token { get; set; }

		/// <summary>
		/// Gets or sets the User
		/// </summary>
		public User User { get; set; }
	}
}
