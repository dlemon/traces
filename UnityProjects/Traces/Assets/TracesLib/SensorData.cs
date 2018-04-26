using UnityEngine;

namespace Traces
{ 
    [System.Serializable]
    public struct GPSData
    {
        public float latitude;
        public float longitude;
        public float altitude;
    }

    [System.Serializable]
    public struct AccelerometerData
    {
        public float x;
        public float y;
        public float z;
        public float magnitude;
    }

    [System.Serializable]
    public struct SensorData
    {
        public int devicId;
        public GPSData gpsData;
        public AccelerometerData accelerometerData;
    }
}
