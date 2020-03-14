// <copyright file="SplashActivity.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-03-14</date>

namespace MyFort.App.Droid
{
	using Android.App;
	using Android.Content.PM;
	using Android.OS;

	/// <summary>
	/// Defines the <see cref="SplashActivity" />
	/// </summary>
	[Activity(Theme = "@style/SplashTheme", Label = "My Fort", Icon = "@mipmap/my_fort",
				 MainLauncher = true,
				 NoHistory = true,
				 ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class SplashActivity : Activity
	{
		/// <summary>
		/// The OnCreate
		/// </summary>
		/// <param name="savedInstanceState">The savedInstanceState<see cref="Bundle"/></param>
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			StartActivity(typeof(MainActivity));
		}
	}
}
