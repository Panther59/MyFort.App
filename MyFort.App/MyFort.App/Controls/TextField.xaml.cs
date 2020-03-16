// <copyright file="TextField.xaml.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-16</date>

namespace MyFort.App.Controls
{
	using System;
	using Xamarin.Forms;
	using Xamarin.Forms.Xaml;

	/// <summary>
	/// A control that let users enter and edit text.
	/// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TextField : ContentView
	{
		/// <summary>
		/// Defines the ErrorTextColorProperty
		/// </summary>
		public static readonly BindableProperty ErrorTextColorProperty = BindableProperty.Create(
		nameof(ErrorTextColor),
		typeof(Color),
		typeof(TextField),
		Color.Red,
		propertyChanging: (bindable, oldValue, newValue) =>
		{
			var ctrl = (TextField)bindable;
			ctrl.ErrorTextColor = (Color)newValue;
		},
		defaultBindingMode: BindingMode.OneWay);

		/// <summary>
		/// Defines the ErrorTextProperty
		/// </summary>
		public static readonly BindableProperty ErrorTextProperty = BindableProperty.Create(
			nameof(ErrorText),
			typeof(string),
			typeof(TextField),
			string.Empty,
			propertyChanging: (bindable, oldValue, newValue) =>
			{
				var ctrl = (TextField)bindable;
				ctrl.ErrorText = (string)newValue;
			},
			defaultBindingMode: BindingMode.TwoWay);

		/// <summary>
		/// Defines the HasErrorProperty
		/// </summary>
		public static readonly BindableProperty HasErrorProperty = BindableProperty.Create(
			nameof(HasError),
			typeof(bool),
			typeof(TextField),
			false,
			propertyChanging: (bindable, oldValue, newValue) =>
			{
				var ctrl = (TextField)bindable;
				ctrl.HasError = (bool)newValue;
			},
			defaultBindingMode: BindingMode.TwoWay);

		/// <summary>
		/// Defines the IconProperty
		/// </summary>
		public static readonly BindableProperty IconProperty = BindableProperty.Create(
		nameof(Icon),
		typeof(string),
		typeof(TextField),
		string.Empty,
		propertyChanging: (bindable, oldValue, newValue) =>
		{
			var ctrl = (TextField)bindable;
			ctrl.Icon = (string)newValue;
		},
		defaultBindingMode: BindingMode.OneWay);

		/// <summary>
		/// Defines the IsPasswordProperty
		/// </summary>
		public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
		nameof(IsPassword),
		typeof(bool),
		typeof(TextField),
		false,
		propertyChanging: (bindable, oldValue, newValue) =>
		{
			var ctrl = (TextField)bindable;
			ctrl.IsPassword = (bool)newValue;
		},
		defaultBindingMode: BindingMode.OneWay);

		/// <summary>
		/// Defines the KeyboardProperty
		/// </summary>
		public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(
		nameof(Keyboard),
		typeof(Keyboard),
		typeof(TextField),
		Keyboard.Default,
		propertyChanging: (bindable, oldValue, newValue) =>
		{
			var ctrl = (TextField)bindable;
			ctrl.Keyboard = (Keyboard)newValue;
		},
		defaultBindingMode: BindingMode.OneWay);

		/// <summary>
		/// Defines the PlaceholderColorProperty
		/// </summary>
		public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create(
		nameof(PlaceholderColor),
		typeof(Color),
		typeof(TextField),
		Color.Black,
		propertyChanging: (bindable, oldValue, newValue) =>
		{
			var ctrl = (TextField)bindable;
			ctrl.PlaceholderColor = (Color)newValue;
		},
		defaultBindingMode: BindingMode.OneWay);

		/// <summary>
		/// Defines the PlaceholderProperty
		/// </summary>
		public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
			nameof(Placeholder),
			typeof(string),
			typeof(TextField),
			string.Empty,
			propertyChanging: (bindable, oldValue, newValue) =>
			{
				var ctrl = (TextField)bindable;
				ctrl.Placeholder = (string)newValue;
			},
			defaultBindingMode: BindingMode.OneWay);

		/// <summary>
		/// Defines the TextColorProperty
		/// </summary>
		public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
		nameof(TextColor),
		typeof(Color),
		typeof(TextField),
		Color.Black,
		propertyChanging: (bindable, oldValue, newValue) =>
		{
			var ctrl = (TextField)bindable;
			ctrl.TextColor = (Color)newValue;
		},
		defaultBindingMode: BindingMode.OneWay);

		/// <summary>
		/// Defines the TextProperty
		/// </summary>
		public static readonly BindableProperty TextProperty = BindableProperty.Create(
			nameof(Text),
			typeof(string),
			typeof(TextField),
			string.Empty,
			propertyChanging: (bindable, oldValue, newValue) =>
			{
				var ctrl = (TextField)bindable;
				ctrl.Text = (string)newValue;
			},
			defaultBindingMode: BindingMode.TwoWay);

		public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(
			nameof(MaxLength),
			typeof(int),
			typeof(TextField),
			int.MaxValue,
			propertyChanging: (bindable, oldValue, newValue) =>
			{
				var ctrl = (TextField)bindable;
				ctrl.MaxLength = (int)newValue;
			},
			defaultBindingMode: BindingMode.OneTime);

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
		/// Initializes a new instance of the <see cref="TextField"/> class.
		/// </summary>
		public TextField()
		{
			InitializeComponent();
			this.InlineEntry.Focused += this.InlineEntry_Focused;
			this.InlineEntry.Unfocused += this.InlineEntry_Unfocused;
			this.Initialize();
		}

		private void Initialize()
		{
			this.leadingIcon.IconColor = this.PlaceholderColor;
			this.persistentUnderline.Color = this.PlaceholderColor;
			this.persistentUnderline.HeightRequest = 1;
			this.persistentUnderline.Margin = new Thickness(5, 0, 5, 1);
		}

		public Entry Entry
		{
			get { return this.InlineEntry; }
			set { this.InlineEntry = value; }
		}


		~TextField()
		{
			this.InlineEntry.Focused -= this.InlineEntry_Focused;
			this.InlineEntry.Unfocused -= this.InlineEntry_Unfocused;
		}

		private void InlineEntry_Unfocused(object sender, FocusEventArgs e)
		{
			this.Initialize();
		}

		private void InlineEntry_Focused(object sender, FocusEventArgs e)
		{
			this.leadingIcon.IconColor = this.TextColor;
			this.persistentUnderline.Color = this.TextColor;
			this.persistentUnderline.HeightRequest = 2;
			this.persistentUnderline.Margin = new Thickness(0);
		}

		/// <summary>
		/// Gets or sets the ErrorText
		/// </summary>
		public string ErrorText
		{
			get
			{
				return (string)GetValue(ErrorTextProperty);
			}

			set
			{
				SetValue(ErrorTextProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets the ErrorTextColor
		/// </summary>
		public Color ErrorTextColor
		{
			get
			{
				return (Color)GetValue(ErrorTextColorProperty);
			}

			set
			{
				SetValue(ErrorTextColorProperty, value);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether HasError
		/// </summary>
		public bool HasError
		{
			get
			{
				return (bool)GetValue(HasErrorProperty);
			}

			set
			{
				SetValue(HasErrorProperty, value);
			}
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

		public int MaxLength
		{
			get
			{
				return (int)GetValue(MaxLengthProperty);
			}

			set
			{
				this.InlineEntry.MaxLength = value;
				SetValue(MaxLengthProperty, value);
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
