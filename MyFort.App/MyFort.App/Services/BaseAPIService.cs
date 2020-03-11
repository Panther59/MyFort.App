using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyFort.App.Services
{
	public abstract class BaseAPIService
	{
		public string BaseUrl
		{
			get => "https://UtkarshLaptop:7001/api/";
		}

		public async Task<T> GetAsync<T>(string url)
		{
			var client = this.PreparedClient();

			var response = await client.GetAsync(url);
			var responseText = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>(responseText);
		}

		public async Task<T> PostAsync<T>(string url, object body) where T : class
		{
			try
			{
				var client = this.PreparedClient();
				string json = JsonConvert.SerializeObject(body);
				var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await client.PostAsync(url, httpContent);
				var responseText = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<T>(responseText);
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task PostAsync(string url, object body)
		{
			var client = this.PreparedClient();
			string json = JsonConvert.SerializeObject(body);
			var httpContent = new StringContent(json);
			var response = await client.PostAsync(url, httpContent);
		}

		private HttpClient PreparedClient()
		{
			//var filter = new HttpBaseProtocolFilter();

			//filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Expired);
			//filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
			//filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.InvalidName);

			HttpClientHandler handler = new HttpClientHandler();

			//not sure about this one, but I think it should work to allow all certificates:
			handler.ServerCertificateCustomValidationCallback += (sender, cert, chaun, ssPolicyError) =>
			{
				return true;
			};

			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

			HttpClient client = new HttpClient(handler);

			return client;
		}
	}
}
