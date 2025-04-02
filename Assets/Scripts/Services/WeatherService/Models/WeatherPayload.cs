using Newtonsoft.Json;

namespace Services.WeatherService.Models
{
    public class WeatherPayload
    {
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    
        [JsonProperty("current_units")]
        public CurrentUnits CurrentUnits { get; set; }
    
        [JsonProperty("current")]
        public CurrentWeather CurrentWeather { get; set; }
    }
}