using Newtonsoft.Json;

namespace Services.WeatherService.Models
{
    public class CurrentWeather
    {
        [JsonProperty("time")]
        public string Time { get; set; }
    
        [JsonProperty("temperature_2m")]
        public double Temperature { get; set; }
    }
}