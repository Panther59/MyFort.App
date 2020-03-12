using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MyFort.App.Services
{
	public class AppSettings : IAppSettings
	{
		public string Get(string key)
		{
			if (Application.Current.Properties.ContainsKey(key) && Application.Current.Properties[key] != null)
			{
				return Application.Current.Properties[key]?.ToString();
			}
			else
			{
				return null;
			}
		}

		public void Set(string key, string value)
		{
			if (value == null)
			{
				Application.Current.Properties.Remove(key);
			}
			else
			{
				Application.Current.Properties[key] = value;
			}
		}
	}
}
