// <copyright file="User.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-11</date>

namespace MyFort.App.Models
{
	/// <summary>
	/// Defines the <see cref="User" />
	/// </summary>
	public class User
	{
		/// <summary>
		/// Gets or sets the Email
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Gets or sets the FirstName
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the Id
		/// </summary>
		public int? Id { get; set; }

		/// <summary>
		/// Gets or sets the LastName
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Gets or sets the Role
		/// </summary>
		public string Role { get; set; }
	}
}
