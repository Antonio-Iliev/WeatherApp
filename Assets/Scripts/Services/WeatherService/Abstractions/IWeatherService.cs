using System.Threading.Tasks;
using Services.WeatherService.Models;

namespace Services.WeatherService.Abstractions
{
    public interface IWeatherService
    {
        Task<WeatherResponse> GetCurrentWeatherByLocation(float latitude, float longitude);
    }
}
