using MyFort.App.Models;
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
		private readonly IAppSettings appSettings;

		public BaseAPIService(IAppSettings appSettings)
		{
			this.appSettings = appSettings;
		}

		public string BaseUrl
		{
			//get => "https://UtkarshLaptop:7001/api/";
			get => "https://myfortapi.azurewebsites.net/api/";
		}

		public async Task<APIResponse<T>> GetAsync<T>(string url)
		{
			var client = this.PreparedClient();

			var response = await client.GetAsync(url);
			var responseText = await response.Content.ReadAsStringAsync();
			var responseObj = new APIResponse<T>();
			responseObj.IsSuccess = response.IsSuccessStatusCode;
			responseObj.StatusCode = (int)response.StatusCode;
			if (response.IsSuccessStatusCode)
			{
				responseObj.Result = JsonConvert.DeserializeObject<T>(responseText);
			}
			else
			{
				responseObj.Error = JsonConvert.DeserializeObject<APIError>(responseText);
			}

			return responseObj;
		}

		public async Task<APIResponse<T>> PostAsync<T>(string url, object body) where T : class
		{
			try
			{
				var client = this.PreparedClient();
				string json = JsonConvert.SerializeObject(body);
				var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await client.PostAsync(url, httpContent);
				var responseText = await response.Content.ReadAsStringAsync();
				var responseObj = new APIResponse<T>();
				responseObj.IsSuccess = response.IsSuccessStatusCode;
				responseObj.StatusCode = (int)response.StatusCode;
				if (response.IsSuccessStatusCode)
				{
					responseObj.Result = JsonConvert.DeserializeObject<T>(responseText);
				}
				else
				{
					responseObj.Error = JsonConvert.DeserializeObject<APIError>(responseText);
				}

				return responseObj;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task<APIResponse> PostAsync(string url, object body)
		{
			var client = this.PreparedClient();
			string json = JsonConvert.SerializeObject(body);
			var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await client.PostAsync(url, httpContent);
			var responseObj = new APIResponse();
			responseObj.IsSuccess = response.IsSuccessStatusCode;
			responseObj.StatusCode = (int)response.StatusCode;
			if (!response.IsSuccessStatusCode)
			{
				var responseText = await response.Content.ReadAsStringAsync();
				responseObj.Error = JsonConvert.DeserializeObject<APIError>(responseText);
			}

			return responseObj;
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
			if (this.appSettings.Get("Token") != null)
			{
				client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", this.appSettings.Get("Token"));
			}

			return client;
		}
	}
}
