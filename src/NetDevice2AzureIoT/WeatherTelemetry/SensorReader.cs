﻿using Emmellsoft.IoT.Rpi.SenseHat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTelemetry
{
    public class SensorReader
    {
        public ISenseHat SenseHat;

        public SensorReader()
        {
        }

        public async Task InitializeSenseHat()
        {
            ISenseHat senseHat = await SenseHatFactory.GetSenseHat();
            this.SenseHat = senseHat;

            SenseHat.Display.Clear();
            await SenseHat.Sensors.HumiditySensor.InitAsync();
        }

        public void ReadSensors(out double temperature, out double humidity)
        {
            SenseHat.Sensors.HumiditySensor.Update();
            temperature = SenseHat.Sensors.Temperature ?? 0;
            humidity = SenseHat.Sensors.Humidity ?? 0;
        }
    }
}
