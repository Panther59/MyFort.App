// <copyright file="AppSettings.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-15</date>

namespace MyFort.App.Services
{
	using Xamarin.Forms;

	/// <summary>
	/// Defines the <see cref="AppSettings" />
	/// </summary>
	public class AppSettings : IAppSettings
	{
		/// <summary>
		/// The Get
		/// </summary>
		/// <param name="key">The key<see cref="string"/></param>
		/// <returns>The <see cref="string"/></returns>
		public string Get(string key)
		{
			if (Application.Current.Properties.ContainsKey(key) && Application.Current.Properties[key] != null)
			{
				return Application.Current.Properties[key]?.ToString();
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// The HasKey
		/// </summary>
		/// <param name="key">The key<see cref="string"/></param>
		/// <returns>The <see cref="bool"/></returns>
		public bool HasKey(string key)
		{
			return Application.Current.Properties.ContainsKey(key);
		}

		/// <summary>
		/// The Set
		/// </summary>
		/// <param name="key">The key<see cref="string"/></param>
		/// <param name="value">The value<see cref="string"/></param>
		public void Set(string key, string value)
		{
			if (value == null)
			{
				Application.Current.Properties.Remove(key);
			}
			else
			{
				Application.Current.Properties[key] = value;
			}

			Application.Current.SavePropertiesAsync();
		}
	}
}
