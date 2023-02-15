// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

using System;

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// Set debounce count, such as n. If the measured values continue to exceed the threshold for n+1 times, the touch sensor state changes. Range: 0 ~ 7
    /// </summary>
    public enum FilterSettingDebounce
    {
        /// <summary>No debounce</summary>
        NoDebounce = 0,

        /// <summary>1 period.</summary>
        One,

        /// <summary>2 periods.</summary>
        Two,

        /// <summary>3 periods.</summary>
        Three,

        /// <summary>4 periods.</summary>
        Four,

        /// <summary>5 periods.</summary>
        Five,

        /// <summary>6 periods.</summary>
        Six,

        /// <summary>7 periods.</summary>
        Seven,
    }
}
