using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Traces
{
    /// <summary>
    /// Main Loop for continuously updating sensor data 
    /// </summary>
    public class SensorLoop : MonoBehaviour
    {
        /// <summary>
        /// Sensor Data Event handler
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="arg">The Sensor Data</param>
        public delegate void SensorDataEventHandler(object sender, SensorDataEventArgs arg);
        public event SensorDataEventHandler OnSensorData; 

        private bool _locationEnabled=false;

        // Use this for initialization
        void Start()
        {
            StartCoroutine(StartLocationService());
        }

        // Update is called once per frame
        void Update()
        {
            SensorData mySensorData = new SensorData();

            if (_locationEnabled)
            {
                mySensorData.gpsData.latitude = Input.location.lastData.latitude;
                mySensorData.gpsData.longitude = Input.location.lastData.longitude;
                mySensorData.gpsData.altitude = Input.location.lastData.altitude;
            }

            mySensorData.accelerometerData.magnitude = Input.acceleration.magnitude;
            mySensorData.accelerometerData.x = Input.acceleration.x;
            mySensorData.accelerometerData.y = Input.acceleration.y;
            mySensorData.accelerometerData.z = Input.acceleration.z;

            // Broadcast the sensor data to subscribers
            if (OnSensorData != null)
            {
                OnSensorData(this, new SensorDataEventArgs(mySensorData));
            }
        }

        /// <summary>
        /// Coroutine for starting the location service. 
        /// </summary>
        /// <returns></returns>
        private IEnumerator StartLocationService()
        {
            // First, check if user has location service enabled
            if (!Input.location.isEnabledByUser)
            {
                Debug.Log("Input Location is not enabled by user");
                yield break;
            }

            // Start service before querying location
            Input.location.Start();

            // Wait until service initializes
            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                maxWait--;
            }

            // Service didn't initialize in 20 seconds
            if (maxWait < 1)
            {
                Debug.Log("Timed out");
                yield break;
            }

            // Connection has failed
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("Unable to determine device location");
                yield break;
            }

            _locationEnabled = true;
        }
    }
}
