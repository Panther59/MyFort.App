// <copyright file="ExtendedViewCell.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-14</date>

namespace MyFort.App.Controls
{
	using Xamarin.Forms;

	/// <summary>
	/// Defines the <see cref="ExtendedViewCell" />
	/// </summary>
	public class ExtendedViewCell : ViewCell
	{
		/// <summary>
		/// Defines the SelectedBackgroundColorProperty
		/// </summary>
		public static readonly BindableProperty SelectedBackgroundColorProperty =
			BindableProperty.Create("SelectedBackgroundColor",
									typeof(Color),
									typeof(ExtendedViewCell),
									Color.Default);

		/// <summary>
		/// Gets or sets the SelectedBackgroundColor
		/// </summary>
		public Color SelectedBackgroundColor
		{
			get { return (Color)GetValue(SelectedBackgroundColorProperty); }
			set { SetValue(SelectedBackgroundColorProperty, value); }
		}
	}
}
