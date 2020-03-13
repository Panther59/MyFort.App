// <copyright file="IconEntryRenderer.cs" company="Avanade">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>DIR\utkarsh.chauhan</author>
// <date>23-04-2018</date>

using MyFort.App.Controls;
using MyFort.App.Droid.Renderers;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(IconEntry), typeof(IconEntryRenderer))]

namespace MyFort.App.Droid.Renderers
{
	using Android.Content;
	using Android.Content.Res;
	using Android.Graphics.Drawables;
	using Android.Text;
	using Xamarin.Forms;
	using Xamarin.Forms.Platform.Android;

	/// <summary>
	/// Defines the <see cref="IconEntryRenderer" />
	/// </summary>
	public class IconEntryRenderer : EntryRenderer
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="IconEntryRenderer"/> class.
		/// </summary>
		/// <param name="context">The <see cref="Context"/></param>
		public IconEntryRenderer(Context context) : base(context)
		{
		}

		#endregion

		#region Methods

		/// <summary>
		/// The OnElementChanged
		/// </summary>
		/// <param name="e">The <see cref="ElementChangedEventArgs{Entry}"/></param>
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (this.Control != null)
			{
				//var nativeEditText = (global::Android.Widget.EditText)Control;
				//var shape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
				//shape.Paint.Color = Xamarin.Forms.Color.Red.ToAndroid();
				//shape.Paint.SetStyle(Paint.Style.Stroke);
				//nativeEditText.Background = shape;

				GradientDrawable gd = new GradientDrawable();
				gd.SetColor(global::Android.Graphics.Color.Transparent);
				this.Control.SetBackgroundDrawable(gd);
				this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
				gd.SetStroke(1, global::Android.Graphics.Color.Transparent);
				Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Gray));

				e.NewElement.Unfocused += (sender, evt) =>
				{
					GradientDrawable gd = new GradientDrawable();
					gd.SetColor(global::Android.Graphics.Color.Transparent);
					this.Control.SetBackgroundDrawable(gd);
					this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
					Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Gray));
					gd.SetStroke(1, global::Android.Graphics.Color.Transparent);
				};
				e.NewElement.Focused += (sender, evt) =>
				{
					GradientDrawable gd = new GradientDrawable();
					gd.SetColor(global::Android.Graphics.Color.Transparent);
					this.Control.SetBackgroundDrawable(gd);
					this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
					gd.SetStroke(1, global::Android.Graphics.Color.Orange);
					Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Orange));
				};
			}
		}

		#endregion
	}
}
