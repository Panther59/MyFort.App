// <copyright file="BaseViewModel.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-11</date>

namespace MyFort.App.ViewModels
{
	using MyFort.App.Models;
	using MyFort.App.Services;
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	using System.Threading.Tasks;
	using Xamarin.Forms;

	/// <summary>
	/// Defines the <see cref="BaseViewModel" />
	/// </summary>
	public class BaseViewModel : INotifyPropertyChanged, IViewModelLifecycle
	{
		/// <summary>
		/// Defines the isBusy
		/// </summary>
		internal bool isBusy = false;

		/// <summary>
		/// Defines the title
		/// </summary>
		internal string title = string.Empty;

		/// <summary>
		/// Defines the PropertyChanged
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Gets the DataStore
		/// </summary>
		public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

		/// <summary>
		/// Gets or sets a value indicating whether IsBusy
		/// </summary>
		public bool IsBusy
		{
			get { return isBusy; }
			set { SetProperty(ref isBusy, value); }
		}

		/// <summary>
		/// Gets or sets the Title
		/// </summary>
		public string Title
		{
			get { return title; }
			set { SetProperty(ref title, value); }
		}

		/// <summary>
		/// The AfterDismissed
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		public virtual Task AfterDismissed()
		{
			return Task.CompletedTask;
		}

		/// <summary>
		/// The BeforeFirstShown
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		public virtual Task BeforeFirstShown()
		{
			return Task.CompletedTask;
		}

		/// <summary>
		/// The BeforeNavigatedBack
		/// </summary>
		/// <returns>The <see cref="Task"/></returns>
		public virtual Task BeforeNavigatedBack()
		{
			return Task.CompletedTask;
		}

		/// <summary>
		/// The OnPropertyChanged
		/// </summary>
		/// <param name="propertyName">The propertyName<see cref="string"/></param>
		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			var changed = PropertyChanged;
			if (changed == null)
				return;

			changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>
		/// The SetProperty
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="backingStore">The backingStore<see cref="T"/></param>
		/// <param name="value">The value<see cref="T"/></param>
		/// <param name="propertyName">The propertyName<see cref="string"/></param>
		/// <param name="onChanged">The onChanged<see cref="Action"/></param>
		/// <returns>The <see cref="bool"/></returns>
		protected bool SetProperty<T>(ref T backingStore, T value,
			[CallerMemberName]string propertyName = "",
			Action onChanged = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingStore, value))
				return false;

			backingStore = value;
			onChanged?.Invoke();
			OnPropertyChanged(propertyName);
			return true;
		}
	}
}
