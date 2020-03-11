using MyFort.App.Services;
using Plugin.GoogleClient;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyFort.App.ViewModels
{
	public class AboutViewModel : BaseViewModel
	{
		public AboutViewModel(IServerCommunication serverCommunication)
		{
			Title = "About";
			OpenWebCommand = new Command(async () => await this.OpenMethod());
			this.serverCommunication = serverCommunication;
		}

		private async Task OpenMethod()
		{
			try
			{
				CrossGoogleClient.Current.OnLogin += this.GoogleClient_OnLogin;
				CrossGoogleClient.Current.OnError += this.GoogleClient_OnError;
				//var response = await CrossGoogleClient.Current.LoginAsync();
				var apiResponse = await this.serverCommunication.GetFromServerAsync("https://UtkarshLaptop:7001/api/values");
			}
			catch (Exception ex)
			{
			}
		}

		private void GoogleClient_OnError(object sender, GoogleClientErrorEventArgs e)
		{
		}

		private void GoogleClient_OnLogin(object sender, GoogleClientResultEventArgs<Plugin.GoogleClient.Shared.GoogleUser> e)
		{
		}

		public ICommand OpenWebCommand { get; }

		private readonly IGoogleClientManager googleClient;
		private readonly IServerCommunication serverCommunication;
	}
}