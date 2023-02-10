// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

using System;

namespace nanoFramework.Hardware.Esp32.Touch
{
    public enum FilterSettingSmoothMode
    {
        /// <summary>No filtering of raw data.</summary>
        Off = 0,

        /// <summary>Filter the raw data. The coefficient is 2 (Typical value).</summary>
        Iir2 = 1,

        /// <summary>Filter the raw data. The coefficient is 4.</summary>
        Iir4 = 2,

        /// <summary>Filter the raw data. The coefficient is 8.</summary>
        Iir8 = 3,

    }
}
