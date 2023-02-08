// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// High voltage attenuation.
    /// </summary>
    public enum TouchHighVoltageAttenuation
    {
        /// <summary>1.5 Volt.</summary>
        Volt1V5 = 0,

        /// <summary>1.0 Volt.</summary>
        Volt1V0,

        /// <summary>0.5 Volt.</summary>
        Volt0V5,

        /// <summary>0.0 Volt.</summary>
        Volt0V0,
    }
}
