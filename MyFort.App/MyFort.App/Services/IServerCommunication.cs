// <copyright file="IServerCommunication.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-02-29</date>

namespace MyFort.App.Services
{
	using System.Threading.Tasks;

	/// <summary>
	/// Defines the <see cref="IServerCommunication" />
	/// </summary>
	public interface IServerCommunication
	{
		/// <summary>
		/// The GetFromServerAsync
		/// </summary>
		/// <param name="URL">The URL<see cref="string"/></param>
		/// <returns>The <see cref="Task{string}"/></returns>
		Task<string> GetFromServerAsync(string URL);
	}
}
