using Newtonsoft.Json;

namespace Services.WeatherService.Models
{
    public class CurrentUnits
    {
        [JsonProperty("temperature_2m")]
        public string TemperatureUnit { get; set; }
    }
}