﻿using MyFort.App.ViewModels;
using System;
using System.ComponentModel;
using Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFort.App.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class AboutView : ContentPage
	{
		public AboutView()
		{
			InitializeComponent();
			this.BindingContext = App.Container.Resolve<AboutViewModel>();
		}
	}
}