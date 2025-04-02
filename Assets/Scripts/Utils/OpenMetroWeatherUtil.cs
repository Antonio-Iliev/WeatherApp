using Newtonsoft.Json;
using Services.WeatherService.Abstractions;
using Services.WeatherService.Models;

namespace Utils
{
    public class OpenMetroWeatherUtil : IWeatherUtil
    {
        const string URL =
            "https://api.open-meteo.com/v1/forecast?current=temperature_2m&timezone=auto&forecast_days=1";

        public string ConstructURLByLocation(float latitude, float longitude)
        {
            return $"{URL}&latitude={latitude}&longitude={longitude}";
        }

        public WeatherResponse GetResponseModel(string response)
        {
            var payload = JsonConvert.DeserializeObject<WeatherPayload>(response);
            var model = new WeatherResponse
            {
                Timezone = payload.Timezone,
                Time = payload.CurrentWeather.Time,
                Temperature = payload.CurrentWeather.Temperature,
                TemperatureUnit = payload.CurrentUnits.TemperatureUnit
            };
            
            return model;
        }
    }
}