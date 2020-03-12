// <copyright file="InverseBoolConverter.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-12</date>

namespace MyFort.App.Extensions
{
	using System;
	using System.Globalization;
	using Xamarin.Forms;
	using Xamarin.Forms.Xaml;

	/// <summary>
	/// Defines the <see cref="InverseBoolConverter" />
	/// </summary>
	public class InverseBoolConverter : IValueConverter, IMarkupExtension
	{
		/// <summary>
		/// The Convert
		/// </summary>
		/// <param name="value">The value<see cref="object"/></param>
		/// <param name="targetType">The targetType<see cref="Type"/></param>
		/// <param name="parameter">The parameter<see cref="object"/></param>
		/// <param name="culture">The culture<see cref="CultureInfo"/></param>
		/// <returns>The <see cref="object"/></returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !((bool)value);
		}

		/// <summary>
		/// The ConvertBack
		/// </summary>
		/// <param name="value">The value<see cref="object"/></param>
		/// <param name="targetType">The targetType<see cref="Type"/></param>
		/// <param name="parameter">The parameter<see cref="object"/></param>
		/// <param name="culture">The culture<see cref="CultureInfo"/></param>
		/// <returns>The <see cref="object"/></returns>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}

		/// <summary>
		/// The ProvideValue
		/// </summary>
		/// <param name="serviceProvider">The serviceProvider<see cref="IServiceProvider"/></param>
		/// <returns>The <see cref="object"/></returns>
		public object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
	}
}
