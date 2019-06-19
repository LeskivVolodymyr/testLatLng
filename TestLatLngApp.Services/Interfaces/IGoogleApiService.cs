using System.Threading.Tasks;

namespace TestLatLngApp.Services.Interfaces
{
    public interface IGoogleApiService
    {
        Task<string> GetPlaces(string search);
        Task<string> GetPlaceGeoData(string address);
    }
}
