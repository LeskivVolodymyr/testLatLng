using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestLatLngApp.Services.Interfaces;

namespace TestLatLngApp.Controllers
{
    [Route("api/ApiData")]
    public class ApiDataController : Controller
    {
        private readonly IGoogleApiService _apiService;

        public ApiDataController(IGoogleApiService apiService)
        {
            _apiService = apiService;
        }


        [HttpGet("GetAddressAutocompleate")]
        public async Task<string> GetAddressAutocompleate(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                return  await _apiService.GetPlaces(search);
            }

            return "";
        }

        [HttpGet("GetCoordinates")]
        public async Task<string> GetCoordinates(string address)
        {
            if (!string.IsNullOrEmpty(address))
            {
                return await _apiService.GetPlaceGeoData(address);
            }

            return "";
        }

    }
}
