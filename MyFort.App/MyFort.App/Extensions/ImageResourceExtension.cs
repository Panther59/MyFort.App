// <copyright file="ImageResourceExtension.cs" company="Avanade">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>DIR\utkarsh.chauhan</author>
// <date>19-04-2018</date>

namespace MyFort.App.Extensions
{
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Defines the <see cref="ImageResourceExtension" />
    /// </summary>
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Source
        /// </summary>
        public string Source { get; set; }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// The ProvideValue
        /// </summary>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/></param>
        /// <returns>The <see cref="object"/></returns>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (this.Source == null)
            {
                return null;
            }

            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(this.Source);

            return imageSource;
        }

        #endregion

        #endregion
    }
}
