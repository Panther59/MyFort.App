// <copyright file="MyEntry.xaml.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-14</date>

namespace MyFort.App.Controls
{
	using Xamarin.Forms;
	using Xamarin.Forms.Xaml;

	/// <summary>
	/// Defines the <see cref="MyEntry" />
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyEntry : Grid
	{
		/// <summary>
		/// Defines the IconProperty
		/// </summary>
		public static readonly BindableProperty IconProperty = BindableProperty.Create(
		nameof(Icon),
		typeof(string),
		typeof(MyEntry),
		string.Empty,
		propertyChanging: (bindable, oldValue, newValue) =>
		{
			var ctrl = (MyEntry)bindable;
			ctrl.Icon = (string)newValue;
		},
		defaultBindingMode: BindingMode.OneWay);

		/// <summary>
		/// Defines the IsPasswordProperty
		/// </summary>
		public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
		nameof(IsPassword),
		typeof(bool),
		typeof(MyEntry),
		false,
		propertyChanging: (bindable, oldValue, newValue) =>
		{
			var ctrl = (MyEntry)bindable;
			ctrl.IsPassword = (bool)newValue;
		},
		defaultBindingMode: BindingMode.OneWay);

		/// <summary>
		/// Defines the KeyboardProperty
		/// </summary>
		public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(
		nameof(Keyboard),
		typeof(Keyboard),
		typeof(MyEntry),
		Keyboard.Default,
		propertyChanging: (bindable, oldValue, newValue) =>
		{
			var ctrl = (MyEntry)bindable;
			ctrl.Keyboard = (Keyboard)newValue;
		},
		defaultBindingMode: BindingMode.OneWay);

		/// <summary>
		/// Defines the PlaceholderColorProperty
		/// </summary>
		public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create(
		nameof(PlaceholderColor),
		typeof(Color),
		typeof(MyEntry),
		Color.Black,
		propertyChanging: (bindable, oldValue, newValue) =>
		{
			var ctrl = (MyEntry)bindable;
			ctrl.PlaceholderColor = (Color)newValue;
		},
		defaultBindingMode: BindingMode.OneWay);

		/// <summary>
		/// Defines the PlaceholderProperty
		/// </summary>
		public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
			nameof(Placeholder),
			typeof(string),
			typeof(MyEntry),
			string.Empty,
			propertyChanging: (bindable, oldValue, newValue) =>
			{
				var ctrl = (MyEntry)bindable;
				ctrl.Placeholder = (string)newValue;
			},
			defaultBindingMode: BindingMode.OneWay);

		/// <summary>
		/// Defines the TextColorProperty
		/// </summary>
		public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
		nameof(TextColor),
		typeof(Color),
		typeof(MyEntry),
		Color.Black,
		propertyChanging: (bindable, oldValue, newValue) =>
		{
			var ctrl = (MyEntry)bindable;
			ctrl.TextColor = (Color)newValue;
		},
		defaultBindingMode: BindingMode.OneWay);

		/// <summary>
		/// Defines the TextProperty
		/// </summary>
		public static readonly BindableProperty TextProperty = BindableProperty.Create(
			nameof(Text),
			typeof(string),
			typeof(MyEntry),
			string.Empty,
			propertyChanging: (bindable, oldValue, newValue) =>
			{
				var ctrl = (MyEntry)bindable;
				ctrl.Text = (string)newValue;
			},
			defaultBindingMode: BindingMode.TwoWay);

		/// <summary>
		/// Defines the icon
		/// </summary>
		private string icon;

		/// <summary>
		/// Defines the isPassword
		/// </summary>
		private bool isPassword;

		/// <summary>
		/// Defines the keyboard
		/// </summary>
		private Keyboard keyboard;

		/// <summary>
		/// Defines the placeholder
		/// </summary>
		private string placeholder;

		/// <summary>
		/// Defines the placeholderColor
		/// </summary>
		private Color placeholderColor;

		/// <summary>
		/// Defines the text
		/// </summary>
		private string text;

		/// <summary>
		/// Defines the textColor
		/// </summary>
		private Color textColor;

		/// <summary>
		/// Initializes a new instance of the <see cref="MyEntry"/> class.
		/// </summary>
		public MyEntry()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Gets or sets the Icon
		/// </summary>
		public string Icon
		{
			get
			{
				return this.icon;
			}

			set
			{
				this.icon = value;
				this.OnPropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether IsPassword
		/// </summary>
		public bool IsPassword
		{
			get { return isPassword; }
			set
			{
				isPassword = value;
				this.InlineEntry.IsPassword = value;
				this.OnPropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the Keyboard
		/// </summary>
		public Keyboard Keyboard
		{
			get { return keyboard; }
			set
			{
				keyboard = value;
				this.InlineEntry.Keyboard = value;
				this.OnPropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the Placeholder
		/// </summary>
		public string Placeholder
		{
			get
			{
				return this.placeholder;
			}

			set
			{
				this.placeholder = value;
				this.OnPropertyChanged();
			}
		}

		/// <summary>
		/// Gets or sets the PlaceholderColor
		/// </summary>
		public Color PlaceholderColor
		{
			get
			{
				return this.placeholderColor;
			}

			set
			{
				this.placeholderColor = value;
				this.OnPropertyChanged();
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
