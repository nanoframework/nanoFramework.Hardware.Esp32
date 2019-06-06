
namespace nanoFramework.Hardware.Esp32.TouchPad
{
	/// <summary>
	/// Configuration parameters for derived classes of TouchPadBase
	/// </summary>
	public class TouchPadBaseConfig
	{
		public TouchHighVolt TouchHighVolt { get; set; }

		public TouchLowVolt TouchLowVolt { get; set; }

		public TouchVoltAtten TouchVoltAtten { get; set; }

		public ushort TouchThreshNoUse { get; set; }

		public uint TouchPadFilterTouchPeriod { get; set; }


		public TouchPadBaseConfig()
		{
			TouchHighVolt = TouchHighVolt.TOUCH_HVOLT_2V7;
			TouchLowVolt = TouchLowVolt.TOUCH_LVOLT_0V5;
			TouchVoltAtten = TouchVoltAtten.TOUCH_HVOLT_ATTEN_1V;
			TouchThreshNoUse = 0;
			TouchPadFilterTouchPeriod = 10;
		}
	}
}
