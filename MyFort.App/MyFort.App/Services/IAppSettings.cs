// <copyright file="IAppSettings.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-11</date>

namespace MyFort.App.Services
{
	/// <summary>
	/// Defines the <see cref="IAppSettings" />
	/// </summary>
	public interface IAppSettings
	{
		/// <summary>
		/// The Get
		/// </summary>
		/// <param name="key">The key<see cref="string"/></param>
		/// <returns>The <see cref="string"/></returns>
		string Get(string key);

		/// <summary>
		/// The HasKey
		/// </summary>
		/// <param name="key">The key<see cref="string"/></param>
		/// <returns>The <see cref="bool"/></returns>
		bool HasKey(string key);

		/// <summary>
		/// The Set
		/// </summary>
		/// <param name="key">The key<see cref="string"/></param>
		/// <param name="value">The value<see cref="string"/></param>
		void Set(string key, string value);
	}
}
