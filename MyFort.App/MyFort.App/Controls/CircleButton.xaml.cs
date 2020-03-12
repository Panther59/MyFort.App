// <copyright file="CircleButton.xaml.cs" company="Avanade">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>DIR\utkarsh.chauhan</author>
// <date>22-04-2018</date>

namespace MyFort.App.Controls
{
    using System.Windows.Input;
    using SkiaSharp;
    using SkiaSharp.Views.Forms;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Defines the <see cref="CircleButton" />
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CircleButton : Grid
    {
        #region Fields

        /// <summary>
        /// Defines the CommandParameterProperty
        /// </summary>
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            nameof(CommandParameter),
            typeof(string),
            typeof(CircleButton),
            string.Empty,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (CircleButton)bindable;
                ctrl.CommandParameter = (string)newValue;
            },
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Defines the CommandProperty
        /// </summary>
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            "Command",
            typeof(ICommand),
            typeof(CircleButton),
            null,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (CircleButton)bindable;
                ctrl.Command = (ICommand)newValue;
            },
            defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Defines the IconBackgroundColorProperty
        /// </summary>
        public static readonly BindableProperty IconBackgroundColorProperty = BindableProperty.Create(
        nameof(IconBackgroundColor),
        typeof(Color),
        typeof(CircleButton),
        Color.White,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var ctrl = (CircleButton)bindable;
            ctrl.IconBackgroundColor = (Color)newValue;
        },
        defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Defines the IconColorProperty
        /// </summary>
        public static readonly BindableProperty IconColorProperty = BindableProperty.Create(
       nameof(IconColor),
       typeof(Color),
       typeof(CircleButton),
       Color.Black,
       propertyChanging: (bindable, oldValue, newValue) =>
       {
           var ctrl = (CircleButton)bindable;
           ctrl.IconColor = (Color)newValue;
       },
       defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Defines the IconProperty
        /// </summary>
        public static readonly BindableProperty IconProperty = BindableProperty.Create(
        nameof(Icon),
        typeof(string),
        typeof(CircleButton),
        string.Empty,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var ctrl = (CircleButton)bindable;
            ctrl.Icon = (string)newValue;
        },
        defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Defines the TextColorProperty
        /// </summary>
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
        nameof(TextColor),
        typeof(Color),
        typeof(CircleButton),
        Color.Black,
        propertyChanging: (bindable, oldValue, newValue) =>
        {
            var ctrl = (CircleButton)bindable;
            ctrl.TextColor = (Color)newValue;
        },
        defaultBindingMode: BindingMode.OneWay);

        /// <summary>
        /// Defines the TextProperty
        /// </summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(CircleButton),
            string.Empty,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (CircleButton)bindable;
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
        /// Defines the iconBackgroundColor
        /// </summary>
        private Color iconBackgroundColor;

        /// <summary>
        /// Defines the iconColor
        /// </summary>
        private Color iconColor;

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
        /// Initializes a new instance of the <see cref="CircleButton"/> class.
        /// </summary>
        public CircleButton()
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
        /// Gets or sets the IconBackgroundColor
        /// </summary>
        public Color IconBackgroundColor
        {
            get
            {
                return this.iconBackgroundColor;
            }

            set
            {
                this.iconBackgroundColor = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the IconColor
        /// </summary>
        public Color IconColor
        {
            get
            {
                return this.iconColor;
            }

            set
            {
                this.iconColor = value;
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

        #region Methods

        #region Private Methods

        /// <summary>
        /// The Draw_CircleFilled
        /// </summary>
        /// <param name="canvas">The <see cref="SKCanvas"/></param>
        /// <param name="radius">The <see cref="int"/></param>
        /// <param name="color">The <see cref="SKColor"/></param>
        private void Draw_CircleFilled(SKCanvas canvas, int radius, SKColor color)
        {
            // Drawing a Circle
            using (SKPaint paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Fill;
                paint.IsAntialias = true;
                paint.Color = color;

                canvas.DrawCircle(0, 0, 80, paint);
            }
        }

        /// <summary>
        /// The CanvasView_OnPaintSurface
        /// </summary>
        /// <param name="sender">The <see cref="object"/></param>
        /// <param name="e">The <see cref="SKPaintSurfaceEventArgs"/></param>
        private void CanvasView_OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            // Init skcanvas
            SKImageInfo imageInfo = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear(SKColors.Transparent);

            var canvasWidth = imageInfo.Width;
            var canvasheight = imageInfo.Height;

            //// move canvas X,Y to center of screen
            canvas.Translate((float)canvasWidth / 2, (float)canvasheight / 2);
            //// set the pixel scale of the canvas
            canvas.Scale(canvasWidth / 200f);

            var shader = SKShader.CreateLinearGradient(
                new SKPoint(0, 0), 
                new SKPoint(90, 90),
                new SKColor[] { SKColors.LightGreen, SKColors.YellowGreen },
                null, 
                SKShaderTileMode.Clamp);

            using (SKPaint paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Fill;
                paint.IsAntialias = true;
                paint.Color = this.IconBackgroundColor.ToSKColor();

                canvas.DrawCircle(0, 0, 90, paint);
            }

            using (SKPaint paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Stroke;
                paint.IsAntialias = true;
                paint.Shader = shader;
                paint.StrokeWidth = 5;

                canvas.DrawCircle(0, 0, 90, paint);
            }
        }

        #endregion

        #endregion
    }
}
