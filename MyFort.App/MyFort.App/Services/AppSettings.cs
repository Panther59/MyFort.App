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
			if (Application.Current.Properties.ContainsKey(key))
			{
				return Application.Current.Properties[key].ToString();
			}
			else
			{
				return null;
			}
		}

		public void Set(string key, string value)
		{
			Application.Current.Properties[key] = value;
		}
	}
}
