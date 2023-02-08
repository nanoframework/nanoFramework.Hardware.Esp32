// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// Touch trigger mode.
    /// </summary>
    public enum TouchTriggerMode
    {
        /// <summary>
        /// Bellow threshold which is the default value.
        /// </summary>
        BellowThreshold = 0,

        /// <summary>
        /// Above threshold.
        /// </summary>
        AboveThreshold,
    }
}
