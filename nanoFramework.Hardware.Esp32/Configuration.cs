//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;

namespace nanoFramework.Hardware.Esp32
{
    /// <summary>
    /// Change Configuration
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Set the default function for a GPIO pin.
        /// </summary>
        /// <remarks>
        /// Allows gpio pins to be assigned a device function.
        /// For example setting the I2C1 data pin to use GPIO pin 17.
        /// </remarks>
        /// <param name="pin">The pin number to set against function.</param>
        /// <param name="value">The device function to be assigned the pin.</param>
        public static void SetPinFunction(int pin, DeviceFunction value)
        {
            NativeSetPinFunction(pin, (int)value);
        }

        /// <summary>
        /// Returns the current pin number used by a device function.
        /// </summary>
        /// <param name="function"></param>
        /// <returns>The pin number used by device function. If value is -1 then pins is not assigned.</returns>
        public static int GetFunctionPin(DeviceFunction function)
        {
 
            return NativeGetPinFunction((int)function); ;
        }

        #region Native Calls
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static void NativeSetPinFunction(int pin, int function);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static int NativeGetPinFunction(int function);
        #endregion
    }
}
