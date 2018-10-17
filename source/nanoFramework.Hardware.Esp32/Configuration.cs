//
// Copyright (c) 2018 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;
using Windows.Devices.Gpio;

namespace nanoFramework.Hardware.Esp32
{
    /// <summary>
    /// Change Configuration
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Set the default function for a GPIO pin
        /// </summary>
        /// <remarks>
        /// Allows gpio pins to be assigned a device function.
        /// For example setting the I2C1 data pin to use GPIO pin 17.
        /// </remarks>
        /// <param name="pin"></param>
        /// <param name="value"></param>
        public static void SetPinFunction(int pin, DeviceFunction value)
        {
            GpioPin gpioPin = GpioController.GetDefault().OpenPin(pin);
            gpioPin.SetAlternateFunction((int)value);
            gpioPin.Dispose();
        }
    }
}
