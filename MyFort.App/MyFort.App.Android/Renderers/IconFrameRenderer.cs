// <copyright file="IconFrameRenderer.cs" company="Avanade">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>DIR\utkarsh.chauhan</author>
// <date>23-04-2018</date>

using MyFort.App.Controls;
using MyFort.App.Droid.Renderers;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(IconFrame), typeof(IconFrameRenderer))]

namespace MyFort.App.Droid.Renderers
{
    using Android.Content;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.Android;

    /// <summary>
    /// Defines the <see cref="IconFrameRenderer" />
    /// </summary>
    public class IconFrameRenderer : FrameRenderer
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IconFrameRenderer"/> class.
        /// </summary>
        /// <param name="context">The <see cref="Context"/></param>
        public IconFrameRenderer(Context context) : base(context)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// The OnElementChanged
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Frame}"/></param>
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            this.SetBackgroundDrawable(Resources.GetDrawable(Droid.Resource.Drawable.blue_resct));
        }

        #endregion
    }
}
