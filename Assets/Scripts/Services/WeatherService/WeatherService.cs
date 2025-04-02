using System;
using System.Threading.Tasks;
using Services.WeatherService.Abstractions;
using Services.WeatherService.Models;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

namespace Services.WeatherService
{
    public class WeatherService : IWeatherService
    {
        private IWeatherUtil _util;

        [Inject]
        public void Construct(IWeatherUtil util)
        {
            _util = util;
        }

        public async Task<WeatherResponse> GetCurrentWeatherByLocation(float latitude, float longitude)
        {
            var url = _util.ConstructURLByLocation(latitude, longitude);
            using var request = UnityWebRequest.Get(url);
            var operation = request.SendWebRequest();

            while (!operation.isDone)
            {
                await Task.Yield();
            }

            if (request.result != UnityWebRequest.Result.Success)
            {
                throw new Exception($"{nameof(WeatherService)}: {request.error}");
            }

            var responseModel = _util.GetResponseModel(request.downloadHandler.text);
            return responseModel;
        }
    }
}