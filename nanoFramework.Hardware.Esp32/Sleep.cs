//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;

namespace nanoFramework.Hardware.Esp32
{
    /// <summary>
    /// Encapsulates ESP32 sleep functions.
    /// </summary>
    public class Sleep
    {
        /// <summary>
        /// Wakeup mode used by <see cref="EnableWakeupByMultiPins"/>.
        /// </summary>
        public enum WakeupMode
        {
            /// <summary>
            /// Wakeup when all pins are low.
            /// </summary>
            AllLow = 0,

            /// <summary>
            /// Wakeup when any pin is high.
            /// </summary>
            AnyHigh = 1
        }

        /// <summary>
        /// Sleep wakeup cause.
        /// </summary>
        public enum WakeupCause
        {
            /// <summary>
            /// In case of deep sleep, reset was not caused by exit from deep sleep.
            /// </summary>
            Undefined = 0,

            /// <summary>
            /// Wakeup caused by external signal using RTC_IO.
            /// </summary>
            Ext0 = 2,

            /// <summary>
            /// Wakeup caused by external signal using RTC_CNTL.
            /// </summary>
            Ext1,

            /// <summary>
            /// Wakeup caused by timer.
            /// </summary>
            Timer,

            /// <summary>
            ///  Wakeup caused by Touchpad.
            /// </summary>
            TouchPad,

            /// <summary>
            ///  Wakeup caused by ULP program.
            /// </summary>
            Ulp,

            /// <summary>
            /// Wakeup caused by GPIO (light sleep only).
            /// </summary>
            Gpio,

            /// <summary>
            /// Wakeup caused by UART (light sleep only).
            /// </summary>
            Uart
        }

        /// <summary>
        /// Gpio pins that can be used for wakeup.
        ///
        /// ESP32:    0, 2, 4, 12-15, 25-27, 32-39
        /// ESP32-S2: 0-21
        /// ESP32-S3: 0-21
        /// ESP32-C6: 0-7
        /// ESP32-H2: 7-14
        /// </summary>
        [Flags]
        public enum WakeupGpioPin : UInt64
        {
            /// <summary>
            /// No wake up pin.
            /// </summary>
            None = 0,

            /// <summary>
            /// Gpio Pin 1 used for wakeup.
            /// ESP32, ESP32_S2, ESP32_S3, ESP32-C6 only
            /// </summary>
            Pin0 = 1,

            /// <summary>
            /// Gpio Pin 2 used for wakeup.
            /// ESP32_S2, ESP32_S3, ESP32-C6 only
            /// </summary>
            Pin1 = (UInt64)1 << 1,

            /// <summary>
            /// Gpio Pin 2 used for wakeup.
            /// ESP32, ESP32_S2, ESP32_S3, ESP32-C6 only
            /// </summary>
            Pin2 = (UInt64)1 << 2,

            /// <summary>
            /// Gpio Pin 3 used for wakeup.
            /// ESP32_S2, ESP32_S3, ESP32-C6 only
            /// </summary>
            Pin3 = (UInt64)1 << 3,

            /// <summary>
            /// Gpio Pin 4 used for wakeup.
            /// ESP32, ESP32_S2, ESP32_S3, ESP32-C6 only
            /// </summary>
            Pin4 = (UInt64)1 << 4,

            /// <summary>
            /// Gpio Pin 5 used for wakeup.
            /// ESP32_S2, ESP32_S3, ESP32-C6 only
            /// </summary>
            Pin5 = (UInt64)1 << 5,

            /// <summary>
            /// Gpio Pin 6 used for wakeup.
            /// ESP32_S2, ESP32_S3, ESP32-C6 only
            /// </summary>
            Pin6 = (UInt64)1 << 6,

            /// <summary>
            /// Gpio Pin 7 used for wakeup.
            /// ESP32_S2, ESP32_S3, ESP32-C6, ESP32_H2 only
            /// </summary>
            Pin7 = (UInt64)1 << 7,

            /// <summary>
            /// Gpio Pin 8 used for wakeup.
            /// ESP32_S2, ESP32_S3, ESP32_H2 only
            /// </summary>
            Pin8 = (UInt64)1 << 8,

            /// <summary>
            /// Gpio Pin 9 used for wakeup.
            /// ESP32_S2, ESP32_S3, ESP32_H2 only
            /// </summary>
            Pin9 = (UInt64)1 << 9,

            /// <summary>
            /// Gpio Pin 10 used for wakeup.
            /// ESP32_S2, ESP32_S3, ESP32_H2 only
            /// </summary>
            Pin10 = (UInt64)1 << 10,

            /// <summary>
            /// Gpio Pin 11 used for wakeup.
            /// ESP32_S2, ESP32_S3, ESP32_H2 only
            /// </summary>
            Pin11 = (UInt64)1 << 11,

            /// <summary>
            /// Gpio Pin 12 used for wakeup.
            /// ESP32, ESP32_S2, ESP32_S3, ESP32_H2 only
            /// </summary>
            Pin12 = (UInt64)1 << 12,

            /// <summary>
            /// Gpio Pin 13 used for wakeup.
            /// ESP32, ESP32_S2, ESP32_S3, ESP32_H2 only
            /// </summary>
            Pin13 = (UInt64)1 << 13,

            /// <summary>
            /// Gpio Pin 14 used for wakeup.
            /// ESP32, ESP32_S2, ESP32_S3, ESP32_H2 only
            /// </summary>
            Pin14 = (UInt64)1 << 14,

            /// <summary>
            /// Gpio Pin 15 used for wakeup.
            /// ESP32, ESP32_S2, ESP32_S3 only
            /// </summary>
            Pin15 = (UInt64)1 << 15,

            /// <summary>
            /// Gpio Pin 16 used for wakeup.
            /// ESP32_S2, ESP32_S3 only
            /// </summary>
            Pin16 = (UInt64)1 << 16,

            /// <summary>
            /// Gpio Pin 17 used for wakeup.
            /// ESP32_S2, ESP32_S3 only
            /// </summary>
            Pin17 = (UInt64)1 << 17,

            /// <summary>
            /// Gpio Pin 18 used for wakeup.
            /// ESP32_S2, ESP32_S3 only
            /// </summary>
            Pin18 = (UInt64)1 << 18,

            /// <summary>
            /// Gpio Pin 19 used for wakeup.
            /// ESP32_S2, ESP32_S3 only
            /// </summary>
            Pin19 = (UInt64)1 << 19,

            /// <summary>
            /// Gpio Pin 20 used for wakeup.
            /// ESP32_S2, ESP32_S3 only
            /// </summary>
            Pin20 = (UInt64)1 << 20,

            /// <summary>
            /// Gpio Pin 21 used for wakeup.
            /// ESP32_S2, ESP32_S3 only
            /// </summary>
            Pin21 = (UInt64)1 << 21,

            /// <summary>
            /// Gpio Pin 25 used for wakeup.
            /// ESP32 only
            /// </summary>
            Pin25 = (UInt64)1 << 25,

            /// <summary>
            /// Gpio Pin 26 used for wakeup.
            /// ESP32 only
            /// </summary>
            Pin26 = (UInt64)1 << 26,

            /// <summary>
            /// Gpio Pin 27 used for wakeup.
            /// ESP32 only
            /// </summary>
            Pin27 = (UInt64)1 << 27,

            /// <summary>
            /// Gpio Pin 32 used for wakeup.
            /// ESP32 only
            /// </summary>
            Pin32 = (UInt64)1 << 32,

            /// <summary>
            /// Gpio Pin 33 used for wakeup.
            /// ESP32 only
            /// </summary>
            Pin33 = (UInt64)1 << 33,

            /// <summary>
            /// Gpio Pin 34 used for wakeup.
            /// ESP32 only
            /// </summary>
            Pin34 = (UInt64)1 << 34,

            /// <summary>
            /// Gpio Pin 35 used for wakeup.
            /// ESP32 only
            /// </summary>
            Pin35 = (UInt64)1 << 35,

            /// <summary>
            /// Gpio Pin 36 used for wakeup.
            /// ESP32 only
            /// </summary>
            Pin36 = (UInt64)1 << 36,

            /// <summary>
            /// Gpio Pin 37 used for wakeup.
            /// ESP32 only
            /// </summary>
            Pin37 = (UInt64)1 << 37,

            /// <summary>
            /// Gpio Pin 38 used for wakeup.
            /// ESP32 only
            /// </summary>
            Pin38 = (UInt64)1 << 38,

            /// <summary>
            /// Gpio Pin 39 used for wakeup.
            /// ESP32 only
            /// </summary>
            Pin39 = (UInt64)1 << 39
        }

        /// <summary>
        /// UART port used for wakeup.
        /// </summary>
        public enum WakeUpPort
        {
            /// <summary>
            /// COM1 port.
            /// </summary>
            COM1 = 0,

            /// <summary>
            /// COM2 port.
            /// </summary>
            COM2 = 1,
        }

        /// <summary>
        /// Enable Wakeup by Timer.
        /// </summary>
        /// <param name="time">Period after which wakeup occurs.</param>
        /// <returns>returns ESP32 native error enumeration.</returns>
        public static EspNativeError EnableWakeupByTimer(TimeSpan time)
        {
            UInt64 time_us = (UInt64)time.Ticks / 10;

            return (EspNativeError)NativeEnableWakeupByTimer(time_us);
        }

        /// <summary>
        /// Enable wakeup using a gpio pin.
        /// </summary>
        /// <param name="pin">GPIO number used as wakeup source. Only pins that have RTC functionality can be used.
        /// 0,2,4,12->15,25->27,32->39</param>
        /// <param name="level">Analog threshold at or above which pin causes wake up, or zero if pin is not active for wakeup.</param>
        /// <returns>Returns ESP32 native error enumeration.</returns>
        public static EspNativeError EnableWakeupByPin(WakeupGpioPin pin, int level)
        {
            return NativeEnableWakeupByPin(pin, level);
        }

        /// <summary>
        /// Enable wakeup using multiple pins.
        /// </summary>
        /// <remarks>
        /// Only pins that are RTC connected. 
        /// </remarks>
        /// <param name="pins">Combination of pins that are enabled for wakeup.</param>
        /// <param name="mode">Logical mode used for wakeup to occur.</param>
        /// <returns>Returns ESP32 native error enumeration.</returns>
        public static EspNativeError EnableWakeupByMultiPins(WakeupGpioPin pins, WakeupMode mode)
        {
            return NativeEnableWakeupByMultiPins(pins, mode);
        }

        /// <summary>
        /// Enable wakeup by Touchpad.
        /// </summary>
        /// <param name="padNumber1">A valid pad number to wake up the device.</param>
        /// <param name="padNumber2">If a valid pad number, will be used in comibation of the first pad number.</param>
        /// <param name="thresholdCoefficient">Threshold coefficient for automatic calibration. Percentage from 0 to 100. Default value is 80% seems to work in most cases.</param>
        /// <remarks>See <see cref="Touch.TouchPad.GetGpioNumberFromTouchNumber(int)"/> to understand which GPIO maps with which pad.</remarks>
        /// <returns>Returns ESP32 native error enumeration.</returns>
        public static EspNativeError EnableWakeupByTouchPad(int padNumber1, int padNumber2 = -1, byte thresholdCoefficient = 80)
        {
            return NativeEnableWakeupByTouchPad(padNumber1, padNumber2, thresholdCoefficient);
        }

        /// <summary>
        /// Enable wakeup by UART.
        /// </summary>
        /// <param name="portNumber">The port to use, only COM1 and COM2 are supported. Pins MUST be properly configured for COM2 for this to work.</param>
        /// <param name="edgeCount">The number of changes in the RX pin to wakeup the ESP.</param>
        /// <returns>Returns ESP32 native error enumeration.</returns>
        public static EspNativeError EnableWakeupByUart(WakeUpPort portNumber, int edgeCount)
        {
            return NativeEnableWakeupByUart(portNumber, edgeCount);
        }

        /// <summary>
        /// Enter light sleep with the configured wakeup options. 
        /// </summary>
        /// <returns>Returns ESP32 native error enumeration, ESP_ERR_INVALID_STATE if Wifi or BT is not stopped.</returns>
        public static EspNativeError StartLightSleep()
        {
            return NativeStartLightSleep();
        }

        /// <summary>
        /// Enter deep sleep using configured wakeup sources. 
        /// </summary>
        /// <remarks>
        /// After a call to this method the device enters deep sleep, a wakeup source will wake the device and the execution will start as if it was a reset.
        /// After this occurs the cause can be queried using <see cref="GetWakeupCause"/>.
        /// Keep in mind that the execution WILL NOT continue after the call to this method.
        /// This call never returns.
        /// If no wakeup sources are configured then the device enters an indefinite sleep.
        /// </remarks>
        /// <seealso cref="EnableWakeupByMultiPins(WakeupGpioPin, WakeupMode)"/>
        /// <seealso cref="EnableWakeupByPin(WakeupGpioPin, int)"/>
        /// <seealso cref="EnableWakeupByTimer(TimeSpan)"/>
        /// <seealso cref="EnableWakeupByTouchPad"/>
        public static void StartDeepSleep()
        {
            NativeStartDeepSleep();

            // force an infinite sleep to allow execution engine to exit this thread and pick the reboot flags set on the call above
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }

        /// <summary>
        /// Get the cause for waking up.
        /// </summary>
        /// <returns>Returns the wakeup cause.</returns>
        public static WakeupCause GetWakeupCause()
        {
            return NativeGetWakeupCause();
        }

        /// <summary>
        /// Returns a combination of pins that caused the wakeup.
        /// </summary>
        /// <returns>Returns a combination of the pins that caused the wakeup.</returns>
        public static WakeupGpioPin GetWakeupGpioPin()
        {
            return NativeGetWakeupGpioPin();
        }

        /// <summary>
        /// Get the Touchpad which caused the wakeup. 
        /// </summary>
        /// <returns>Returns TouchPad number which caused the wakeup, else <see cref="WakeupGpioPin.None"/>.</returns>
        public static int GetWakeupTouchpad()
        {
            return NativeGetWakeupTouchpad();
        }

        #region extenal calls to native implementations

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern EspNativeError NativeEnableWakeupByTimer(UInt64 time_us);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern EspNativeError NativeEnableWakeupByPin(WakeupGpioPin pin, int level);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern EspNativeError NativeEnableWakeupByMultiPins(WakeupGpioPin pins, WakeupMode mode);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern EspNativeError NativeEnableWakeupByTouchPad(int padNumber1, int padNumber2, byte thresholdCoefficient);
        
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern EspNativeError NativeEnableWakeupByUart(WakeUpPort padNumber1, int edgeCount);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern EspNativeError NativeStartLightSleep();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern EspNativeError NativeStartDeepSleep();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern WakeupCause NativeGetWakeupCause();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern WakeupGpioPin NativeGetWakeupGpioPin();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern int NativeGetWakeupTouchpad();

        #endregion
    }
}
