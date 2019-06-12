//
// Copyright (c) 2018 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace nanoFramework.Hardware.Esp32.TouchPad
{
	/// <summary>
	/// Base class for toch pad sensors: interrupt or polling driven, using single or multiple gpio pins
	/// </summary>
	public abstract class TouchPadBase // : IDisposable
	{
		//code review: Gpio​Pin uses it, but it's internal to Windows.Devices.Gpio  - please review if it applicable here
		//private static GpioPinEventListener s_eventListener;

		// this is used as the lock object 
		// a lock is required because multiple threads can access the GpioPin
		private readonly object _syncLock = new object();

		protected readonly int _pinNumber;
		protected readonly int _touchPadIndex;

		/// <summary>
		/// Map of GPIO to touch pad number. 
		/// ESP32 offers up to 10 capacitive IOs that detect changes in capacitance on touch sensors due to finger contact or proximity. 
		/// </summary>
		private static readonly Hashtable GpioTouchPadMap = new Hashtable()
		{
			{4, 0}, {0, 1}, {2,  2}, {27, 7}, {15, 3}, {13, 4}, {12, 5}, {14, 6}, {33, 8}, {32, 9}
		};

		/// <summary>
		/// Constructs and initializes object based on given configuration.
		/// </summary>
		/// <param name="pinNumber">A valid touch pad pin, i.e. 0, 2, 4, 12, 13, 14, 15, 27, 32, 33 </param>
		/// <param name="config">Touchpad configuration object</param>
		/// <exception cref="ArgumentException">Invalid touchpad pin number</exception>
		/// <exception cref="ArgumentNullException">Configuration parameter is null</exception>
		/// <exception cref="Exception">One of native calls returned not OK return value.</exception>
		protected TouchPadBase(int pinNumber, TouchPadBaseConfig config)
		{
			if (!GpioTouchPadMap.Contains(_pinNumber))
				throw new ArgumentException(nameof(pinNumber));

			if (config == null)
				throw new ArgumentNullException(nameof(config));

			_pinNumber = pinNumber;
			_touchPadIndex = (int)GpioTouchPadMap[_pinNumber];
			//lock (_syncLock)
			//{
			//  if (s_eventListener == null)
			//  {
			//    s_eventListener = new GpioPinEventListener();
			//  }
			//}

			if (!TouchPadInit())
				throw new Exception();

			SetFsmMode();

			if (!TouchPadSetVoltage(config.TouchHighVolt, config.TouchLowVolt, config.TouchVoltAtten))
				throw new Exception();

			if (!TouchPadConfig(_touchPadIndex, config.TouchThreshNoUse))
				throw new Exception();

			if (!TouchPadSetFilterPeriod(config.TouchPadFilterTouchPeriod))
				throw new Exception();

		}

		/// <summary>
		/// Set touch sensor FSM mode, the test action can be triggered by the timer, as well as by the software.
		/// The default FSM mode is <see cref="TouchFsmMode.Software"/>. If you want to use interrupt trigger mode, 
		/// then set it to <see cref="TouchFsmMode.Timer"/> after calling init function.
		/// </summary>
		protected virtual void SetFsmMode() { }


		#region IDisposable Support
		private bool _disposedValue;

		private void Dispose(bool disposing)
		{
			if (!_disposedValue)
			{
				if (disposing)
				{
					// remove the pin from the event listner
					//s_eventListener.RemovePin(_pinNumber);
				}

				DisposeNative();

				_disposedValue = true;
			}
		}

#pragma warning disable 1591
		~TouchPadBase()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			lock (_syncLock)
			{
				if (!_disposedValue)
				{
					Dispose(true);

					GC.SuppressFinalize(this);
				}
			}
		}
		#endregion

		#region external calls to native implementations

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool TouchPadInit(); //esp_err_t touch_pad_init() https://docs.espressif.com/projects/esp-idf/en/latest/api-reference/peripherals/touch_pad.html#_CPPv414touch_pad_initv

		[MethodImpl(MethodImplOptions.InternalCall)]
		protected extern bool TouchPadSetFsmMode(TouchFsmMode touchFsmMode); //esp_err_t touch_pad_set_fsm_mode(touch_fsm_mode_tmode) https://docs.espressif.com/projects/esp-idf/en/latest/api-reference/peripherals/touch_pad.html#_CPPv422touch_pad_set_fsm_mode16touch_fsm_mode_t

		[MethodImpl(MethodImplOptions.InternalCall)]
		protected extern bool TouchPadSetVoltage(TouchHighVolt touchHighVolt, TouchLowVolt touchLowVolt, TouchVoltAtten touchVoltAtten); //esp_err_t touch_pad_set_voltage(touch_high_volt_trefh, touch_low_volt_trefl, touch_volt_atten_tatten) 

		[MethodImpl(MethodImplOptions.InternalCall)]
		protected extern bool TouchPadConfig(int touchPadIndex, ushort threshold); //esp_err_t touch_pad_config(touch_pad_ttouch_num, uint16_t threshold)

		[MethodImpl(MethodImplOptions.InternalCall)]
		protected extern bool TouchPadSetFilterPeriod(uint newPeriodMs); //esp_err_t touch_pad_set_filter_period(uint32_t new_period_ms

		[MethodImpl(MethodImplOptions.InternalCall)]
		protected extern ushort TouchPadRead(int touchPadIndex); //esp_err_t touch_pad_read(touch_pad_ttouch_num, uint16_t* touch_value)

		[MethodImpl(MethodImplOptions.InternalCall)]
		protected extern ushort TouchPadReadFiltered(int touchPadIndex); //esp_err_t touch_pad_read_filtered(touch_pad_ttouch_num, uint16_t *touch_value)

		//[MethodImpl(MethodImplOptions.InternalCall)]
		//protected extern ushort TouchPadSetReadRawData(int touchPadIndex); //esp_err_t touch_pad_read_raw_data(touch_pad_ttouch_num, uint16_t *touch_value)

		[MethodImpl(MethodImplOptions.InternalCall)]
		protected extern bool TouchPadSetThresh(int touchPadIndex, ushort threshold); //esp_err_t touch_pad_set_thresh(touch_pad_ttouch_num, uint16_t threshold)


		//todo
		//[MethodImpl(MethodImplOptions.InternalCall)]
		//protected extern bool TouchPadIsrRegister(todo); //esp_err_t touch_pad_isr_register(intr_handler_tfn, void* arg)

		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void DisposeNative();
		#endregion


	}
}

