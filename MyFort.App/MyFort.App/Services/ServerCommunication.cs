// <copyright file="ServerCommunication.cs" company="Ayvan">
// Copyright (c) 2020 All Rights Reserved
// </copyright>
// <author>UTKARSHLAPTOP\Utkarsh</author>
// <date>2020-02-29</date>

namespace MyFort.App.Services
{
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

	/// <summary>
	/// Defines the <see cref="ServerCommunication" />
	/// </summary>
	public class ServerCommunication : IServerCommunication
	{
		public async Task<string> GetFromServerAsync(string URL)
		{
            try
            {
                var client = this.PreparedClient();
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                var response = await client.GetAsync(URL);
                var mobileResult = await response.Content.ReadAsStringAsync();

                return mobileResult;
            }
            catch (Exception ex)
            {
                return null;
            }
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


            HttpClient client = new HttpClient(handler);

            return client;
        }
    }
}
