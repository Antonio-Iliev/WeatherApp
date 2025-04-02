using Services.WeatherService.Models;

namespace Services.WeatherService.Abstractions
{
    public interface IWeatherUtil
    {
        string ConstructURLByLocation(float latitude, float longitude);
        WeatherResponse GetResponseModel(string httpResponse);
    }
}
