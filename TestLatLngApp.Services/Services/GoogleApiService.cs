using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;
using TestLatLngApp.Services.Interfaces;
using TestLatLngApp.Services.Models;

namespace TestLatLngApp.Services.Services
{
    public class GoogleApiService : IGoogleApiService
    {
        private readonly IOptions<AppSettings> _config;
        private readonly IHttpClientFactory _clientFactory;

        public GoogleApiService(IOptions<AppSettings>  config, IHttpClientFactory clientFactory)
        {
            _config = config;
            _clientFactory = clientFactory;
        }

        public async Task<string> GetPlaces(string search)
        {
            var result = string.Empty;
            var apiKey = _config.Value.ApiKey;
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://maps.googleapis.com/maps/api/place/autocomplete/json?input={search}&key={apiKey}");
            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            return result;
        }

        public async Task<string> GetPlaceGeoData(string address)
        {
            var result = string.Empty;
            var apiKey = _config.Value.ApiKey;
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://maps.googleapis.com/maps/api/geocode/json?address={address}&key={apiKey}");
            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            return result;
        }
    }
}
