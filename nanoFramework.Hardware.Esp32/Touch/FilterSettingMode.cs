// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

using System;

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// Infinite impulse response (IIR) filter mode
    /// </summary>
    public enum FilterSettingMode
    {
        /// <summary>
        /// The filter mode is first-order IIR filter.The coefficient is 4.
        /// </summary>
        Iir4 = 0,

        /// <summary>
        /// The filter mode is first-order IIR filter.The coefficient is 8.
        /// </summary>
        Iir8,

        /// <summary>
        /// The filter mode is first-order IIR filter.The coefficient is 16 (Typical value).
        /// </summary>
        Iir16,

        /// <summary>
        /// The filter mode is first-order IIR filter.The coefficient is 32.
        /// </summary>
        Iir32,

        /// <summary>
        /// The filter mode is first-order IIR filter.The coefficient is 64.
        /// </summary>
        Iir64,

        /// <summary>
        /// The filter mode is first-order IIR filter.The coefficient is 128.
        /// </summary>
        Iir128,

        /// <summary>
        /// The filter mode is first-order IIR filter.The coefficient is 256.
        /// </summary>
        Iir256,

        /// <summary>
        /// The filter mode is jitter filter
        /// </summary>
        IirJitter,
    }
}
