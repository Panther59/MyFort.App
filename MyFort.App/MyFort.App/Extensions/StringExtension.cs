// <copyright file="StringExtension.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-13</date>

namespace MyFort.App.Extensions
{
	using System.Text.RegularExpressions;

	/// <summary>
	/// Defines the <see cref="StringExtensions" />
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// The SplitCamelCase
		/// </summary>
		/// <param name="str">The str<see cref="string"/></param>
		/// <returns>The <see cref="string"/></returns>
		public static string SplitCamelCase(this string str)
		{
			return Regex.Replace(
				Regex.Replace(
					str,
					@"(\P{Ll})(\P{Ll}\p{Ll})",
					"$1 $2"
				),
				@"(\p{Ll})(\P{Ll})",
				"$1 $2"
			);
		}
	}
}
