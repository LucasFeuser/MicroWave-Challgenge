using MicroOndas.Application.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MicroOndas.Application.Endpoint
{
    public class EndpointHelper
    {
        private string GET_PROGRAMASAQUECIMENTO_ENDPOINT = ConfigurationManager.AppSettings["getProgramasAquecimento"];

        private readonly HttpClient _client;

        public EndpointHelper()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetContentFromEndpointAsync()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(GET_PROGRAMASAQUECIMENTO_ENDPOINT);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}