using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Traces
{
    /// <summary>
    /// Event Arguments for broadcasting sensor data
    /// </summary>
    public class SensorDataEventArgs: EventArgs
    {
        public SensorDataEventArgs(SensorData sensorData)
        {
            this.SensorData = sensorData;
        }

        public SensorData SensorData
        {
            get; private set;
        }
    }
}
