// <copyright file="APIResponse.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-12</date>

namespace MyFort.App.Models
{
	/// <summary>
	/// Defines the <see cref="APIResponse{T}" />
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class APIResponse<T> : APIResponse
	{
		/// <summary>
		/// Gets or sets the Result
		/// </summary>
		public T Result { get; set; }
	}

	public class APIResponse
	{
		/// <summary>
		/// Gets or sets the Error
		/// </summary>
		public APIError Error { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether IsSuccess
		/// </summary>
		public bool IsSuccess { get; set; }

		/// <summary>
		/// Gets or sets the StatusCode
		/// </summary>
		public int StatusCode { get; set; }
	}
}
