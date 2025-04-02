namespace Providers.Models
{
    public record LocationModel
    {
        public LocationModel(float latitude, float longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public float Latitude { get; }
        public float Longitude { get; }

        public void Deconstruct(out float latitude, out float longitude)
        {
            latitude = Latitude;
            longitude = Longitude;
        }
    }
}