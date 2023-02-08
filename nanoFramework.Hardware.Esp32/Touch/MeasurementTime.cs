// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

using System;

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// Measurement elements.
    /// </summary>
    public class MeasurementTime
    {
        /// <summary>
        /// The timer frequency is RTC_SLOW_CLK (can be 150k or 32k depending on the options), max value is 0xffff.
        /// </summary>
        public ushort SleepCycles { get;set; }

        /// <summary>
        /// The duration of the touch sensor measurement. t_meas = meas_cycle / 8M, the maximum measure time is 0xffff / 8M = 8.19 ms
        /// </summary>
        public TimeSpan MeasurementCycles { get;set; }
    }
}
