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
    private object _syncLock;

    private readonly int _pinNumber;

    /// <summary>
    /// Map of GPIO to touch pad number. 
    /// ESP32 offers up to 10 capacitive IOs that detect changes in capacitance on touch sensors due to finger contact or proximity. 
    /// </summary>
    private static readonly Hashtable GpioTouchPadMap = new Hashtable()
    {
      {4, 0}, {0, 1}, {2,  2}, {27, 7}, {15, 3}, {13, 4}, {12, 5}, {14, 6}, {33, 8}, {32, 9}
    };


    internal TouchPadBase(int pinNumber)
    {
      _pinNumber = pinNumber;
      _syncLock = new object();

			if (!GpioTouchPadMap.Contains(_pinNumber))
				throw new Exception($"Pin {_pinNumber} is not a valid touch pad pin.");

			if (!TouchPadInit())
				throw new Exception($"Touch pad initialization on pin {_pinNumber} failed.");

			//lock (_syncLock)
			//{
			//  if (s_eventListener == null)
			//  {
			//    s_eventListener = new GpioPinEventListener();
			//  }
			//}
		}

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
    private extern void DisposeNative();
    #endregion


  }
}

