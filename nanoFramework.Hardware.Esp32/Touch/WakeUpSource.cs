// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// Wake up source.
    /// </summary>
    public enum WakeUpSource
    {
        /// <summary>
        /// Both set 1 and set 2.
        /// </summary>
        BothSet1AndSet2 = 0,

        /// <summary>
        /// Only set 1.
        /// </summary>
        OnlySet1,
    }
}
