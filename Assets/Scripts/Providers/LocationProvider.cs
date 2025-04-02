using System;
using System.Threading.Tasks;
using Providers.Models;
using UnityEngine;

namespace Providers
{
    public class LocationProvider
    {
        /// <summary>
        /// Higher values like 500 don't require the device to use its GPS chip and thus save battery power.
        /// The default value is 10 meters.
        /// </summary>
        private const float DesiredAccuracyInMeters = 500f;

        /// <summary>
        /// Higher values like 500 produce fewer updates and are less resource intensive to process.
        /// The default is 10 meters.
        /// </summary>
        private const float UpdateDistanceInMeters = 500f;

        private const float TimoutInSeconds = 20f;

        public async Task<LocationModel> GetOneTimeLocation()
        {
            if (!Input.location.isEnabledByUser)
            {
                throw new Exception($"{nameof(LocationProvider)}: Location service is not enabled by user.");
            }

            if (Input.location.status == LocationServiceStatus.Running)
            {
                Debug.Log($"{nameof(LocationProvider)}: Location service already started.");
                return new LocationModel(latitude: Input.location.lastData.latitude,
                    longitude: Input.location.lastData.longitude);
            }

            Input.location.Start(DesiredAccuracyInMeters, UpdateDistanceInMeters);

            // Waits until the location service initializes
            var timeOut = TimoutInSeconds;
            var startTime = Time.time;

            while (Input.location.status == LocationServiceStatus.Initializing)
            {
                timeOut -= Time.time - startTime;
                if (timeOut < 0)
                {
                    throw new Exception($"{nameof(LocationProvider)}: Initialization Timed out.");
                }

                await Task.Yield();
            }

            if (Input.location.status == LocationServiceStatus.Failed)
            {
                throw new Exception($"{nameof(LocationProvider)}: Unable to determine device location.");
            }

            Debug.Log(
                $"{nameof(LocationProvider)}: Successfully retrieved location service, latitude {Input.location.lastData.latitude}, longitude {Input.location.lastData.longitude}");
            
            Input.location.Stop();
            
            return new LocationModel(latitude: Input.location.lastData.latitude,
                longitude: Input.location.lastData.longitude);
        }
    }
}