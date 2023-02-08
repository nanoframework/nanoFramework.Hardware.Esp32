// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

using nanoFramework.Runtime.Events;
using System;

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// Touch pad event arguments.
    /// </summary>
    public class TouchPadEventArgs: BaseEvent
    {
        /// <summary>
        /// Creates a <see cref="TouchPadEventArgs"/>.
        /// </summary>
        /// <param name="padNumber">The touch pad number.</param>
        /// <param name="touched">True if touched, false is not, so if released.</param>
        public TouchPadEventArgs(int padNumber, bool touched)
        {
            PadNumber = padNumber;
            Touched = touched;
        }

        /// <summary>
        /// Gets the touch pad number.
        /// </summary>
        public int PadNumber { get; }

        /// <summary>
        /// Gets the touch state. True if touched, false is not, so if released.
        /// </summary>
        public bool Touched { get; }
    }
}
