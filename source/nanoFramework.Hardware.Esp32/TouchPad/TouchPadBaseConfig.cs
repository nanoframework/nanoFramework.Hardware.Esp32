//
// Copyright (c) 2018 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Hardware.Esp32.TouchPad
{
	/// <summary>
	/// Configuration parameters for derived classes of TouchPadBase
	/// </summary>
	public class TouchPadBaseConfig
	{
		/// <summary>
		/// Charging voltage threshold of the internal circuit of the touch sensor.
		/// </summary>
		public TouchHighVolt TouchHighVolt { get; set; }

		/// <summary>
		/// Discharging voltage threshold of the internal circuit of the touch sensor.
		/// </summary>
		public TouchLowVolt TouchLowVolt { get; set; }

		/// <summary>
		/// High voltage attenuation value (HATTEN).
		/// </summary>
		public TouchVoltAtten TouchVoltAtten { get; set; }

		/// <summary>
		/// Interrupt threshold
		/// </summary>
		public ushort TouchThreshNoUse { get; set; }

		/// <summary>
		///  Touch pad filter calibration period, in ms.
		/// </summary>
		public uint TouchPadFilterTouchPeriod { get; set; }

		/// <summary>
		/// Default constructor that sets configuration properties to common values. 
		/// </summary>
		public TouchPadBaseConfig()
		{
			TouchHighVolt = TouchHighVolt.H2V7;
			TouchLowVolt = TouchLowVolt.L0V5;
			TouchVoltAtten = TouchVoltAtten.A1V;
			TouchThreshNoUse = 0;
			TouchPadFilterTouchPeriod = 10;
		}
	}
}
