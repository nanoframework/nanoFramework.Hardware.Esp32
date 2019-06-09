//
// Copyright (c) 2018 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Hardware.Esp32.TouchPad
{
	/// <summary>
	/// The touch pad sensing process is under the control of a hardware-implemented finite-state machine 
	/// (FSM) which is initiated by software or a dedicated hardware timer
	/// </summary>
	public enum TouchFsmMode
	{
		/// <summary>
		/// To start touch FSM by timer.
		/// </summary>
		Timer = 0,

		/// <summary>
		/// To start touch FSM by software trigger.
		/// </summary>
		Software,

		/// <summary>
		/// Idf documentation supply no comments on this at the moment.
		/// </summary>
		Max
	}

	/// <summary>
	/// Touch sensor high reference voltage, counterpart of touch_high_volt_t in esp-idf
	/// </summary>
	public enum TouchHighVolt
	{
		/// <summary>
		///Touch sensor high reference voltage, no change 
		/// </summary>
		Keep = -1,

		/// <summary>
		/// Touch sensor high reference voltage, 2.4V
		/// </summary>
		H2V4 = 0,

		/// <summary>
		/// Touch sensor high reference voltage, 2.5V
		/// </summary>
		H2V5,

		/// <summary>
		///  Touch sensor high reference voltage, 2.6V
		/// </summary>
		H2V6,

		/// <summary>
		///  Touch sensor high reference voltage, 2.7V
		/// </summary>
		H2V7,

		/// <summary>
		/// Idf documentation supply no comments on this at the moment.
		/// </summary>
		Max
	}

	/// <summary>
	/// Counterpart of touch_low_volt_t in esp-idf
	/// </summary>
	public enum TouchLowVolt
	{
		/// <summary>
		/// Touch sensor low reference voltage, no change
		/// </summary>
		Keep = -1,

		/// <summary>
		/// Touch sensor low reference voltage, 0.5V
		/// </summary>
		L0V5 = 0,

		/// <summary>
		/// Touch sensor low reference voltage, 0.6V
		/// </summary>
		L0V6,

		/// <summary>
		/// Touch sensor low reference voltage, 0.7V
		/// </summary>
		L0V7,

		/// <summary>
		/// Touch sensor low reference voltage, 0.8V
		/// </summary>
		L0V8,

		/// <summary>
		/// Idf documentation supply no comments on this at the moment.
		/// </summary>
		Max
	}

	/// <summary>
	/// Counterpart of touch_volt_atten_t in esp-idf
	/// </summary>
	public enum TouchVoltAtten
	{
		/// <summary>
		/// Touch sensor high reference voltage attenuation, no change
		/// </summary>
		Keep = -1,

		/// <summary>
		/// Touch sensor high reference voltage attenuation, 1.5V attenuation
		/// </summary>
		A1V5 = 0,

		/// <summary>
		/// Touch sensor high reference voltage attenuation, 1V attenuation
		/// </summary>
		A1V,

		/// <summary>
		/// Touch sensor high reference voltage attenuation, 0.5V attenuation
		/// </summary>
		A0V5,

		/// <summary>
		/// Touch sensor high reference voltage attenuation, 0V attenuation
		/// </summary>
		A0V,

		/// <summary>
		/// Idf documentation supply no comments on this at the moment.
		/// </summary>
		Max
	}

}
