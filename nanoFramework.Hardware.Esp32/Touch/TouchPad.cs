// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// The touch pad. Some of the configurations are specific for each touch pad.
    /// Some are applied to all the touch pad like filtering, voltage and the capture mode.
    /// </summary>
    public class TouchPad : IDisposable
    {
        private const uint CyclesPerMillisec = 8_000_000;

        // Dummy initialization
        private static TouchHighVoltage _touchHighVoltage = (TouchHighVoltage)(-1);
        private static TouchLowVoltage _touchLowVoltage = (TouchLowVoltage)(-1);
        private static TouchHighVoltageAttenuation _touchHighVoltageAttenuation = (TouchHighVoltageAttenuation)(-1);
        private static bool _isFilterOn = false;
        // Needed to handle the eventing
        private static readonly TouchPadEventHandler _touchPadEventHandler = new TouchPadEventHandler();

        private int _calibrationData;
        // For events
        private PinValueChangedEventHandler _callbacks = null;
        private readonly object _syncLock = new object();
        private bool _disposedValue;

        // Used to know which touchpad it is
        private int _touchPadNumber;

        /// <summary>
        /// Gets the gpio number associated to a specific Touch Pad. Those are different depeending on the ESP32.
        /// Touch is available on ESP32 and ESP32-S2. Pins are different depending on the board used.
        /// </summary>
        /// <param name="touchpadNumber">The number of touch pad to get the GPIO. For 0 to 9 for ESP32, from 0 to 14 for ESP32-S2.</param>
        /// <returns>The Gpio number.</returns>
        public static int GetGpioNumberFromTouchNumber(int touchpadNumber) => NativeGetGpioNumberFromTouchNumber(touchpadNumber);

        /// <summary>
        /// The trigger mode is the same for **ALL** the touch pads. Chaning this value will change the behavior for all of them.
        /// The default vaue is bellow the threshold. This is the normal pattern. Values when not touched are high and low when touched.
        /// </summary>
        public static TouchTriggerMode TouchTriggerMode
        {
            get => NativeGetTriggerMode();
            set
            {
                NativeSetTriggerMode(value);
            }
        }


        /// <summary>
        /// The wakeup source mode is the same for **ALL** the touch pads. Chaning this value will change the behavior for all of them.
        /// By default, you need 2 different sources to be touched to wake the board. You can adjut for only one.
        /// </summary>
        public static WakeUpSource WakeUpSource
        {
            get => NativeGetTriggerSource();
            set
            {
                NativeSetTriggerSource(value);
            }
        }

        /// <summary>
        /// The measurement mode mode is the same for **ALL** the touch pads. Chaning this value will change the behavior for all of them.
        /// The default measurement mode is software, meaning you have to manually request a value to get it and also to potentially have the events.
        /// The timer value will automatically read in the background all the values and generates the touched events.
        /// </summary>
        public static MeasurementMode MeasurementMode
        {
            get => NativeGetMeasurementMode();
            set
            {
                NativeSetMeasurementMode(value);
            }
        }

        /// <summary>
        /// Sets the different voltage for operation. This is the same for **ALL** the touch pads. Chaning this value will change the behavior for all of them.
        /// The voltage parameters affect the system's stability and sensitivity. The greater the voltage threshold range,
        /// the stronger the anti-interference ability of the system, and the smaller the pulse count value.
        /// The voltage parameters (refh = 2.7V, refl = 0.5V, atten = 1V) suit most designs.
        /// </summary>
        /// <param name="touchHighVoltage">The high voltage.</param>
        /// <param name="touchLowVoltage">The low voltage.</param>
        /// <param name="touchHighVoltageAttenuation">The attenuation.</param>
        public static void SetVoltage(TouchHighVoltage touchHighVoltage, TouchLowVoltage touchLowVoltage, TouchHighVoltageAttenuation touchHighVoltageAttenuation)
        {
            NativeSetVoltage(touchHighVoltage, touchLowVoltage, touchHighVoltageAttenuation);
            _touchHighVoltage = touchHighVoltage;
            _touchLowVoltage = touchLowVoltage;
            _touchHighVoltageAttenuation = touchHighVoltageAttenuation;
        }

        /// <summary>
        /// Gets the high voltage.
        /// </summary>
        public static TouchHighVoltage TouchHighVoltage
        {
            get => _touchHighVoltage;
        }

        /// <summary>
        /// Gets the low voltage.
        /// </summary>
        public static TouchLowVoltage TouchLowVoltage
        {
            get => _touchLowVoltage;
        }

        /// <summary>
        /// Gets the high voltage attenuation.
        /// </summary>
        public static TouchHighVoltageAttenuation TouchHighVoltageAttenuation
        {
            get => _touchHighVoltageAttenuation;
        }

        /// <summary>
        /// Starts a filtering on a specific period. This is the same for **ALL** the touch pads. Chaning this value will change the behavior for all of them.
        /// Warning: this consume CPU and should be used carefully.
        /// </summary>
        /// <param name="filterSetting">The <see cref="IPeriodSetting"/> depending on your ESP32 series. ESP32 <seealso cref="Esp32PeriodSetting"/> and ESP32-S2/S3 <seealso cref="S2S3PeriodSetting"/> have different settings.</param>
        public static void StartFilter(IPeriodSetting filterSetting)
        {
            if (_isFilterOn)
            {
                return;
            }

            NativeStartFilter(filterSetting);
            _isFilterOn = true;
        }

        /// <summary>
        /// Stops the filtering. This is the same for **ALL** the touch pads. Chaning this value will change the behavior for all of them.
        /// </summary>
        public static void StopFilter()
        {
            if (!_isFilterOn)
            {
                return;
            }

            NativeStopFilter();
            _isFilterOn = false;
        }

        /// <summary>
        /// Gets if the filtering is running.
        /// </summary>
        public static bool IsFilterOn { get => _isFilterOn; }

        /// <summary>
        /// Gets the measurement time settings. This is the same for **ALL** the touch pads. Chaning this value will change the behavior for all of them.
        /// </summary>
        /// <returns>The <see cref="MeasurementTime"/> settings.</returns>
        public static MeasurementTime GetMeasurementTime()
        {
            ushort sleep = 0;
            ushort meas = 0;
            NativeGetMeasurementTime(ref sleep, ref meas);
            // Formula is the following: The duration of the touch sensor measurement. t_meas = meas_cycle / 8M, the maximum measure time is 0xffff / 8M = 8.19 ms
            // Using ticks not to loose preecision
            return new MeasurementTime() { SleepCycles = sleep, MeasurementCycles = TimeSpan.FromTicks(meas * 1000 * TimeSpan.TicksPerMillisecond / CyclesPerMillisec) };
        }

        /// <summary>
        /// Sets the measurement time settings. This is the same for **ALL** the touch pads. Chaning this value will change the behavior for all of them.
        /// </summary>
        /// <param name="measurementTime">The <see cref="MeasurementTime"/> settings.</param>
        /// <exception cref="ArgumentException">The measurement cycle should be less than 8.19 milliseconds</exception>
        public static void SetMeasurementTime(MeasurementTime measurementTime)
        {
            if (CyclesPerMillisec / measurementTime.MeasurementCycles.TotalMilliseconds > 0xFFFF)
            {
                throw new ArgumentException();
            }

            NativeSetMeasurementTime(measurementTime.SleepCycles, (ushort)(measurementTime.MeasurementCycles.TotalMilliseconds * CyclesPerMillisec));
        }

        /// <summary>
        /// Creates a <see cref="TouchPad"/>.
        /// </summary>
        /// <param name="touchPadNumber">A valid touch pad number.</param>
        /// <remarks>Use the <see cref="GetGpioNumberFromTouchNumber"/> to get the associated GPIO of a touch pad.</remarks>
        public TouchPad(int touchPadNumber)
        {
            _touchPadNumber = touchPadNumber;
            NativeInit();
            _touchPadEventHandler.AddPin(this);

            // Ensure we have the right values.
            NativeGetVoltage(ref _touchHighVoltage, ref _touchLowVoltage, ref _touchHighVoltageAttenuation);
        }

        /// <summary>
        /// Reads a value. This is accessible regardless of the mode used.
        /// </summary>
        /// <returns>A touch value.</returns>
        public uint Read() => NativeRead();

        /// <summary>
        /// Gets the calibration data which can be used as a reference point.
        /// </summary>
        public int CalibrationData { get => _calibrationData == 0 ? GetCalibrationData() : _calibrationData; }

        /// <summary>
        /// Gets the calibration data which can be used as a reference point.
        /// </summary>
        /// <param name="count">The number of read you want to do. If you have a signal that varies a lot, you may want to run more than the default one.</param>
        /// <returns></returns>
        public int GetCalibrationData(int count = 5)
        {
            _calibrationData = NativeCalibrate(count);
            return _calibrationData;
        }

        /// <summary>
        /// Gets or sets the threshold used to detect a touch.
        /// Using a value of 2/3 of the calibration data is a good estimation to start with.
        /// This will depends of the surface you have as touch point.
        /// To understand the best value, you should read values to find the lower point.
        /// </summary>
        public uint Threshold
        {
            get => NativeGetThreshold();
            set
            {
                NativeSetThreshold(value);
            }
        }

        /// <summary>
        /// The touch pad number.
        /// </summary>
        public int TouchPadNumber
        {
            get => _touchPadNumber;
        }

        /// <summary>
        /// Sets the charge speed and initial charge.
        /// High charge/discharge speed increases the system's anti-interference ability. Therefore, TouchChargeSpeed.Fastest is recommended.
        /// </summary>
        /// <param name="touchChargeSpeed">The <see cref="TouchChargeSpeed"/> configuration.</param>
        public void SetChargeSpeed(TouchChargeSpeed touchChargeSpeed) => NativeSetChargeSpeed((int)touchChargeSpeed.Speed, (int)touchChargeSpeed.Charge);

        /// <summary>
        /// Gets the touch charge configuration.
        /// </summary>
        /// <returns>The <see cref="TouchChargeSpeed"/> configuration.</returns>
        public TouchChargeSpeed GetChargeSpeed()
        {
            int speed = 0;
            int charge = 0;
            NativeGetTouchSpeed(ref speed, ref charge);
            return new TouchChargeSpeed() { Speed = (TouchChargeSpeed.ChargeSpeed)speed, Charge = (TouchChargeSpeed.InitialCharge)charge };
        }

        /// <summary>
        /// Occurs when the value of the touch pad changes. this happens when the touch pad is touched or released.
        /// </summary>
        public event PinValueChangedEventHandler ValueChanged
        {
            add
            {
                lock (_syncLock)
                {
                    if (_disposedValue)
                    {
                        throw new ObjectDisposedException();
                    }

                    var callbacksOld = _callbacks;
                    var callbacksNew = (PinValueChangedEventHandler)Delegate.Combine(callbacksOld, value);

                    try
                    {
                        _callbacks = callbacksNew;
                    }
                    catch
                    {
                        _callbacks = callbacksOld;
                        throw;
                    }
                }
            }

            remove
            {
                lock (_syncLock)
                {
                    if (_disposedValue)
                    {
                        throw new ObjectDisposedException();
                    }

                    var callbacksOld = _callbacks;
                    var callbacksNew = (PinValueChangedEventHandler)Delegate.Remove(callbacksOld, value);

                    try
                    {
                        _callbacks = callbacksNew;
                    }
                    catch
                    {
                        _callbacks = callbacksOld;
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Handles internal events and re-dispatches them to the publicly subscribed delegates.
        /// </summary>
        /// <param name="touched">Tur if touched, false if not, so if it's been released.</param>
        internal void OnPinChangedInternal(bool touched)
        {
            PinValueChangedEventHandler callbacks = null;

            lock (_syncLock)
            {
                if (!_disposedValue)
                {
                    callbacks = _callbacks;
                }
            }

            callbacks?.Invoke(this, new TouchPadEventArgs(_touchPadNumber, touched));
        }

        /// <summary>
        /// Disposes all the resources.
        /// </summary>
        public void Dispose()
        {
            if (!_disposedValue)
            {
                _touchPadEventHandler.RemovePin(_touchPadNumber);
                NativeDeinit();
                GC.SuppressFinalize(this);
                _disposedValue = true;
            }
        }

        #region Native Calls

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static int NativeGetGpioNumberFromTouchNumber(int touchpadNumber);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeInit();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeDeinit();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern uint NativeRead();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern uint NativeGetThreshold();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeSetThreshold(uint threshold);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeGetTouchSpeed(ref int speed, ref int charge);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeSetChargeSpeed(int speed, int charge);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern int NativeCalibrate(int count);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static TouchTriggerMode NativeGetTriggerMode();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void NativeSetTriggerMode(TouchTriggerMode touchMode);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static WakeUpSource NativeGetTriggerSource();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void NativeSetTriggerSource(WakeUpSource source);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static MeasurementMode NativeGetMeasurementMode();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void NativeSetMeasurementMode(MeasurementMode source);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void NativeSetVoltage(TouchHighVoltage touchHighVoltage, TouchLowVoltage touchLowVoltage, TouchHighVoltageAttenuation touchHighVoltageAttenuation);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void NativeGetVoltage(ref TouchHighVoltage touchHighVoltage, ref TouchLowVoltage touchLowVoltage, ref TouchHighVoltageAttenuation touchHighVoltageAttenuation);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void NativeStartFilter(IPeriodSetting periodSetting);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void NativeStopFilter();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void NativeSetMeasurementTime(ushort sleep, ushort meas);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void NativeGetMeasurementTime(ref ushort sleep, ref ushort meas);

        #endregion
    }
}
