//
// Copyright (c) 2018 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Hardware.Esp32.TouchPad
{
	public enum TouchFsmMode
	{
		TOUCH_FSM_MODE_TIMER = 0,   /*!<To start touch FSM by timer */
		TOUCH_FSM_MODE_SW,          /*!<To start touch FSM by software trigger */
		TOUCH_FSM_MODE_MAX,
	}

	/// <summary>
	/// Counterpart of touch_high_volt_t in esp-idf
	/// ref: https://docs.espressif.com/projects/esp-idf/en/latest/api-reference/peripherals/touch_pad.html#_CPPv417touch_high_volt_t
	/// </summary>
	public enum TouchHighVolt
	{
		TOUCH_HVOLT_KEEP = -1, //Touch sensor high reference voltage, no change
		TOUCH_HVOLT_2V4 = 0,   //Touch sensor high reference voltage, 2.4V
		TOUCH_HVOLT_2V5,
		TOUCH_HVOLT_2V6,
		TOUCH_HVOLT_2V7,
		TOUCH_HVOLT_MAX
	}

	/// <summary>
	/// Counterpart of touch_low_volt_t in esp-idf
	/// </summary>
	public enum TouchLowVolt
	{
		TOUCH_LVOLT_KEEP = -1, //Touch sensor low reference voltage, no change
		TOUCH_LVOLT_0V5 = 0,
		TOUCH_LVOLT_0V6,
		TOUCH_LVOLT_0V7,
		TOUCH_LVOLT_0V8,
		TOUCH_LVOLT_MAX
	}

	/// <summary>
	/// Counterpart of touch_volt_atten_t in esp-idf
	/// </summary>
	public enum TouchVoltAtten
	{
		TOUCH_HVOLT_ATTEN_KEEP = -1, //Touch sensor high reference voltage attenuation, no change
		TOUCH_HVOLT_ATTEN_1V5 = 0,
		TOUCH_HVOLT_ATTEN_1V,
		TOUCH_HVOLT_ATTEN_0V5,
		TOUCH_HVOLT_ATTEN_0V,
		TOUCH_HVOLT_ATTEN_MAX
	}

}
