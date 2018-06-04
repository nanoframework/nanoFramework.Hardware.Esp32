using System;
using System.Runtime.CompilerServices;

namespace nanoFramework.Hardware.Esp32
{
    /// <summary>
    /// Encapsulates ESP32 sleep functions
    /// </summary>
    public class Sleep
    {
        /// <summary>
        /// Wakup modeused by EnableWakeupByMultiPins
        /// </summary>
        public enum WakupMode
        {
            /// <summary>
            /// Wakup when all pins are low
            /// </summary>
            WakeUpAllLow = 0,

            /// <summary>
            /// Wakeup when any pin is high
            /// </summary>
            WakupUpAnyHigh = 1
        };

        /// <summary>
        /// Sleep wakeup cause
        /// </summary>
        public enum WakeupCause
        {
            /// <summary>
            /// Wakeup not caused from exit from sleep
            /// </summary>
            ESP_SLEEP_WAKEUP_UNDEFINED = 0,
            /// <summary>
            /// Wakeup caused by external signal using RTC_IO
            /// </summary>
            ESP_SLEEP_WAKEUP_EXT0,         
            /// <summary>
            /// Wakeup caused by external signal using RTC_CNTL
            /// </summary>
            ESP_SLEEP_WAKEUP_EXT1,       
            /// <summary>
            /// Wakeup caused by timer
            /// </summary>
            ESP_SLEEP_WAKEUP_TIMER,        
            /// <summary>
            ///  Wakeup caused by touchpad
            /// </summary>
            ESP_SLEEP_WAKEUP_TOUCHPAD,     
            /// <summary>
            ///  Wakeup caused by ULP program
            /// </summary>
            ESP_SLEEP_WAKEUP_ULP           
        };


    /// <summary>
    /// Gpio pins that can be used for wakeup
    /// </summary>
    [Flags]
        public enum WakeupGpioPin : UInt64
        {
            /// <summary>
            /// No wake up pin
            /// </summary>
            none  = 0,
            /// <summary>
            /// Gpio Pin 1 used for wakeup
            /// </summary>
            pin0  = 1,
            /// <summary>
            /// Gpio Pin 2 used for wakeup
            /// </summary>
            pin2 = 1 << 2,
            /// <summary>
            /// Gpio Pin 4 used for wakeup
            /// </summary>
            pin4 = 1 << 4,
            /// <summary>
            /// Gpio Pin 12 used for wakeup
            /// </summary>
            pin12 = 1 << 12,
            /// <summary>
            /// Gpio Pin 13 used for wakeup
            /// </summary>
            pin13 = 1 << 13,
            /// <summary>
            /// Gpio Pin 14 used for wakeup
            /// </summary>
            pin14 = 1 << 14,
            /// <summary>
            /// Gpio Pin 15 used for wakeup
            /// </summary>
            pin15 = 1 << 15,
            /// <summary>
            /// Gpio Pin 25 used for wakeup
            /// </summary>
            pin25 = 1 << 25,
            /// <summary>
            /// Gpio Pin 26 used for wakeup
            /// </summary>
            pin26 = 1 << 26,
            /// <summary>
            /// Gpio Pin 27 used for wakeup
            /// </summary>
            pin27 = 1 << 27,
            /// <summary>
            /// Gpio Pin 32 used for wakeup
            /// </summary>
            pin32 = 1 << 32,
            /// <summary>
            /// Gpio Pin 33 used for wakeup
            /// </summary>
            pin33 = 1 << 33,
            /// <summary>
            /// Gpio Pin 34 used for wakeup
            /// </summary>
            pin34 = 1 << 34,
            /// <summary>
            /// Gpio Pin 35 used for wakeup
            /// </summary>
            pin35 = 1 << 35,
            /// <summary>
            /// Gpio Pin 36 used for wakeup
            /// </summary>
            pin36 = 1 << 36,
            /// <summary>
            /// Gpio Pin 37 used for wakeup
            /// </summary>
            pin37 = 1 << 37,
            /// <summary>
            /// Gpio Pin 38 used for wakeup
            /// </summary>
            pin38 = 1 << 38,
            /// <summary>
            /// Gpio Pin 39 used for wakeup
            /// </summary>
            pin39 = 1 << 39
        };

        /// <summary>
        /// Enumeration of Touch pad numbers
        /// </summary>
        public enum  TouchPad
        {
            /// <summary>
            ///  Touch pad channel 0 is GPIO4
            /// </summary>
            TOUCH_PAD_NUM0 = 0,
            /// <summary>
            /// Touch pad channel 1 is GPIO0
            /// </summary>
            TOUCH_PAD_NUM1,
            /// <summary>
            /// Touch pad channel 2 is GPIO2
            /// </summary>
            TOUCH_PAD_NUM2,
            /// <summary>
            /// Touch pad channel 3 is GPIO15
            /// </summary>
            TOUCH_PAD_NUM3,
            /// <summary>
            /// Touch pad channel 4 is GPIO13
            /// </summary>
            TOUCH_PAD_NUM4,
            /// <summary>
            /// Touch pad channel 5 is GPIO12
            /// </summary>
            TOUCH_PAD_NUM5,
            /// <summary>
            /// Touch pad channel 6 is GPIO14
            /// </summary>
            TOUCH_PAD_NUM6,
            /// <summary>
            /// Touch pad channel 7 is GPIO27
            /// </summary>
            TOUCH_PAD_NUM7,
            /// <summary>
            /// Touch pad channel 8 is GPIO33
            /// </summary>
            TOUCH_PAD_NUM8,
            /// <summary>
            /// Touch pad channel 9 is GPIO32
            /// </summary>
            TOUCH_PAD_NUM9,     
            /// <summary>
            /// Number returned when no touch pad used on wakeup 
            /// </summary>
            TOUCH_PAD_NONE,
        };

        /// <summary>
        /// Enable Wakeup by Timer
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static Errors.Esp EnableWakupByTimer(TimeSpan time)
        {
            UInt64 time_us = (UInt64)time.Ticks / 10;

            return (Errors.Esp)NativeEnableWakupByTimer(time_us);
        }

        /// <summary>
        /// Enable wakeup using a gpio pin
        /// </summary>
        /// <param name="pin">GPIO number used as wakeup source.  Only pins that have RTC functionality can be used.
        /// 0,2,4,12->15,25->27,32->39</param>
        /// <param name="level"></param>
        /// <returns></returns>
        public static Errors.Esp EnableWakupByPin(WakeupGpioPin pin, int level)
        {
            return NativeEnableWakupByPin(pin, level);
        }

        /// <summary>
        /// Enable Wkaup using multiple pins.
        /// </summary>
        /// <remarks>
        /// Only pins that are RTC connected. 
        /// </remarks>
        /// <param name="pins"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static Errors.Esp EnableWakeupByMultiPins(WakeupGpioPin pins, WakupMode mode)
        {
            return NativeEnableWakeupByMultiPins( pins, mode);
        }


        /// <summary>
        /// Enable wakeup by Touchpad
        /// </summary>
        /// <returns></returns>
        public static Errors.Esp EnableWakeupByTouchPad()
        {
            return NativeEnableWakeupByTouchPad();
        }

        /// <summary>
        /// Enter light sleep with the configured wakeup options. 
        /// </summary>
        /// <returns>Return ESP_ERR_INVALID_STATE if Wifi or BT not stopped.</returns>
        public static Errors.Esp StartLightSleep()
        {
            return NativeStartLightSleep();
        }

        /// <summary>
        /// Enter deep sleep using configured wakeup sources. 
        /// </summary>
        /// <remarks>
        /// If no sources configured then it will be a indefinate sleep.</remarks>
        /// <returns>ESP_OK if ok</returns>
        public static Errors.Esp StartDeepSleep()
        {
            return NativeStartDeepSleep();
        }

        /// <summary>
        /// Get the cause for waking up
        /// </summary>
        /// <returns>Return the Wakeup cause.</returns>
        public static WakeupCause GetWakeupCause()
        {
            return NativeGetWakeupCause();
        }

        /// <summary>
        /// Returns a bit mask of pins taht caused the wakeup
        /// </summary>
        /// <returns></returns>
        public static WakeupGpioPin GetWakeupGpioPin()
        {
            return NativeGetWakeupGpioPin();
        }

        /// <summary>
        /// Get the touch pad which caused wakeup. 
        /// </summary>
        /// <returns>Return TouchPad number or None</returns>
        public static TouchPad GetWakeupTouchpad()
        {

            return NativeGetWakeupTouchpad();
        }

        #region extenal calls to native implementations

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern Errors.Esp NativeEnableWakupByTimer(UInt64 time_us);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern Errors.Esp NativeEnableWakupByPin(WakeupGpioPin pin, int level);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern Errors.Esp NativeEnableWakeupByMultiPins(WakeupGpioPin pins, WakupMode mode);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern Errors.Esp NativeEnableWakeupByTouchPad();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern Errors.Esp NativeStartLightSleep();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern Errors.Esp NativeStartDeepSleep();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern WakeupCause NativeGetWakeupCause();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern WakeupGpioPin NativeGetWakeupGpioPin();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern TouchPad NativeGetWakeupTouchpad();
 
        #endregion

    }
}
