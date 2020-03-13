// <copyright file="Visit.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-13</date>

namespace MyFort.App.Models
{
	using System;

	/// <summary>
	/// Defines the <see cref="Visit" />
	/// </summary>
	public class Visit
	{
		/// <summary>
		/// Gets or sets the Id
		/// </summary>
		public int? Id { get; set; }

		/// <summary>
		/// Gets or sets the MeetingWith
		/// </summary>
		public string MeetingWith { get; set; }

		/// <summary>
		/// Gets or sets the Notes
		/// </summary>
		public string Notes { get; set; }

		/// <summary>
		/// Gets or sets the Outlet
		/// </summary>
		public virtual Outlet Outlet { get; set; }

		/// <summary>
		/// Gets or sets the User
		/// </summary>
		public virtual User User { get; set; }

		/// <summary>
		/// Gets or sets the VisitedOn
		/// </summary>
		public DateTime VisitedOn { get; set; }
	}
}
