// <copyright file="NavigationItem.xaml.cs" company="Avanade">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>DIR\utkarsh.chauhan</author>
// <date>22-04-2018</date>

namespace MyFort.App.Controls
{
    using System.Windows.Input;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Defines the <see cref="NavigationItem" />
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationItem : Grid
    {
        #region Fields

        /// <summary>
        /// Defines the CommandParameterProperty
        /// </summary>
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            nameof(CommandParameter),
            typeof(string),
            typeof(NavigationItem),
            string.Empty,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (NavigationItem)bindable;
                ctrl.CommandParameter = (string)newValue;
            },
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Defines the CommandProperty
        /// </summary>
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            "Command",
            typeof(ICommand),
            typeof(NavigationItem),
            null,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (NavigationItem)bindable;
                ctrl.Command = (ICommand)newValue;
            },
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Defines the IconProperty
        /// </summary>
        public static readonly BindableProperty IconProperty = BindableProperty.Create(
        nameof(Icon),
        typeof(string),
        typeof(NavigationItem),
        string.Empty,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var ctrl = (NavigationItem)bindable;
            ctrl.Icon = (string)newValue;
        },
        defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Defines the TextColorProperty
        /// </summary>
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
        nameof(TextColor),
        typeof(Color),
        typeof(NavigationItem),
        Color.Black,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var ctrl = (NavigationItem)bindable;
            ctrl.TextColor = (Color)newValue;
        },
        defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Defines the TextProperty
        /// </summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(NavigationItem),
            string.Empty,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (NavigationItem)bindable;
                ctrl.Text = (string)newValue;
            },
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Defines the commandParameter
        /// </summary>
        private string commandParameter;

        /// <summary>
        /// Defines the icon
        /// </summary>
        private string icon;

        /// <summary>
        /// Defines the text
        /// </summary>
        private string text;

        /// <summary>
        /// Defines the textColor
        /// </summary>
        private Color textColor;

        #region Commands

        /// <summary>
        /// Defines the command
        /// </summary>
        private ICommand command;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationItem"/> class.
        /// </summary>
        public NavigationItem()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the CommandParameter
        /// </summary>
        public string CommandParameter
        {
            get
            {
                return this.commandParameter;
            }

            set
            {
                this.commandParameter = value;
                this.OnPropertyChanged();
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
        /// Gets or sets the Text
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                this.text = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the TextColor
        /// </summary>
        public Color TextColor
        {
            get
            {
                return this.textColor;
            }

            set
            {
                this.textColor = value;
                this.OnPropertyChanged();
            }
        }

        #region Commands

        /// <summary>
        /// Gets or sets the Command
        /// </summary>
        public ICommand Command
        {
            get
            {
                return this.command;
            }

            set
            {
                this.command = value;
                this.OnPropertyChanged();
            }
        }

        #endregion

        #endregion
    }
}
