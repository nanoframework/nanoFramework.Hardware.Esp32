// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

namespace System.Device.Gpio
{
    /// <summary>
    /// Represents a near-simultaneous sampling of the number of times a pin has changed value, and the time at which this count was sampled.
    /// This structure can be used to determine the number of pin value changes over a period of time.
    /// </summary>
    public struct GpioPulseCount
    {
        // NOTE: This structure is used by the native code, so it must be kept in sync with the native code.
        // So no auto property used as not supported by nanoCLR. For simplicity, no backing field either.
        /// <summary>
        /// The number of times the transition of polarity specified by <see cref="GpioPulsePolarity"/> occured on the pin.
        /// </summary>
        public long Count;

        /// <summary>
        /// The time at which this count was sampled. The time is sampled close to (but not simultaneously with) the count.
        /// This timestamp can be used to determine the elapsed time between two GpioChangeCount records.
        /// It does not correspond to any absolute or system time.
        /// </summary>
        public TimeSpan RelativeTime;
    }
}
