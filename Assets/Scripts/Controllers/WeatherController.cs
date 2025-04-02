using System;
using Providers;
using Services.WeatherService.Abstractions;
using ToastMessageService.Abstractions;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Controllers
{
    public class WeatherController : MonoBehaviour
    {
        private IWeatherService _weatherService;
        private IMessageService _messageService;
        private LocationProvider _locationProvider;

        [SerializeField] private Button button;

        [Inject]
        public void Construct(IWeatherService weatherService, IMessageService messageService,
            LocationProvider locationProvider)
        {
            _weatherService = weatherService;
            _messageService = messageService;
            _locationProvider = locationProvider;
        }

        private void Awake()
        {
            button.onClick.AddListener(GetWeather);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(GetWeather);
        }

        private async void GetWeather()
        {
            try
            {
                button.interactable = false;

                var locationModel = await _locationProvider.GetOneTimeLocation();
                var (latitude, longitude) = locationModel;

                var weatherModel = await _weatherService.GetCurrentWeatherByLocation(latitude, longitude);

                _messageService.ShowMessage(
                    $"The temperature in {weatherModel.Timezone} is {weatherModel.Temperature}{weatherModel.TemperatureUnit}.");
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            finally
            {
                button.interactable = true;
            }
        }
    }
}