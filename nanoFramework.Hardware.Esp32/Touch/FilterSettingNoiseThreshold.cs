// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

using System;

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// Noise threshold coefficient. Higher = More noise resistance. The actual noise should be less than (noise coefficient * touch threshold). Range: 0 ~ 3. The coefficient is 0: 4/8; 1: 3/8; 2: 2/8; 3: 1;
    /// </summary>
    public enum FilterSettingNoiseThreshold
    {
        /// <summary>The coefficient is 0: 4/8.</summary>
        Low = 0,

        /// <summary>The coefficient is 1: 3/8.</summary>
        Mediumlow,

        /// <summary>The coefficient is 2: 2/8.</summary>
        MediumHigh,

        /// <summary>The coefficient is 3: 1.</summary>
        High,
    }
}
