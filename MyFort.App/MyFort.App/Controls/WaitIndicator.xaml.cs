// <copyright file="WaitIndicator.xaml.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-14</date>

namespace MyFort.App.Controls
{
	using Xamarin.Forms;
	using Xamarin.Forms.Xaml;

	/// <summary>
	/// Defines the <see cref="WaitIndicator" />
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WaitIndicator : Grid
	{
		/// <summary>
		/// Defines the IsBusyProperty
		/// </summary>
		public static readonly BindableProperty IsBusyProperty = BindableProperty.Create(
		nameof(IsBusy),
		typeof(bool),
		typeof(WaitIndicator),
		false,
		propertyChanging: (bindable, oldValue, newValue) =>
		{
			var ctrl = (WaitIndicator)bindable;
			ctrl.IsBusy = (bool)newValue;
		},
		defaultBindingMode: BindingMode.TwoWay);

		/// <summary>
		/// Defines the TextColorProperty
		/// </summary>
		public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
		nameof(TextColor),
		typeof(Color),
		typeof(WaitIndicator),
		Color.Black,
		propertyChanging: (bindable, oldValue, newValue) =>
		{
			var ctrl = (WaitIndicator)bindable;
			ctrl.TextColor = (Color)newValue;
		},
		defaultBindingMode: BindingMode.OneWay);

		/// <summary>
		/// Defines the TextProperty
		/// </summary>
		public static readonly BindableProperty TextProperty = BindableProperty.Create(
			nameof(Text),
			typeof(string),
			typeof(WaitIndicator),
			string.Empty,
			propertyChanging: (bindable, oldValue, newValue) =>
			{
				var ctrl = (WaitIndicator)bindable;
				ctrl.Text = (string)newValue;
			},
			defaultBindingMode: BindingMode.OneTime);

		/// <summary>
		/// Initializes a new instance of the <see cref="WaitIndicator"/> class.
		/// </summary>
		public WaitIndicator()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets or sets a value indicating whether IsBusy
		/// Gets or sets the IsBusy
		/// </summary>
		public bool IsBusy
		{
			get
			{
				return (bool)GetValue(IsBusyProperty);
			}

			set
			{
				SetValue(IsBusyProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the Text
		/// </summary>
		public string Text
		{
			get
			{
				return (string)GetValue(TextProperty);
			}

			set
			{
				SetValue(TextProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the TextColor
		/// </summary>
		public Color TextColor
		{
			get
			{
				return (Color)GetValue(TextColorProperty);
			}

			set
			{
				SetValue(TextColorProperty, value);
			}
		}
	}
}
