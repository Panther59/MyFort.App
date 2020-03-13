// <copyright file="User.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-11</date>

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyFort.App.Models
{
	/// <summary>
	/// Defines the TypeOfUser
	/// </summary>
	public enum TypeOfUser
	{
		/// <summary>
		/// Defines the RegularUser
		/// </summary>
		[Display(Description = "Regular")]
		RegularUser = 1,
		/// <summary>
		/// Defines the Supervisor
		/// </summary>
		[Display(Description = "Supervisor")]
		Supervisor = 2,
		/// <summary>
		/// Defines the Admin
		/// </summary>
		[Display(Description = "Admin")]
		Admin = 4,
		/// <summary>
		/// Defines the ITAdmin
		/// </summary>
		[Display(Description = "IT Admin")]
		ITAdmin = 8,
	}

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
		/// Gets or sets a value indicating whether IsActive
		/// </summary>
		public bool? IsActive { get; set; }

		/// <summary>
		/// Gets or sets the LastName
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Gets or sets the Type
		/// </summary>
		public TypeOfUser Type { get; set; }
	}
}
