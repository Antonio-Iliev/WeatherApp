namespace Services.WeatherService.Models
{
    public record WeatherResponse
    {
        public string Timezone { get; set; }
        public string Time { get; set; }
        public double Temperature { get; set; }
        public string TemperatureUnit { get; set; }
    }
}
