// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

using nanoFramework.Runtime.Events;
using System;

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// Touch pad event.
    /// </summary>
    internal class TouchPadEvent : BaseEvent
    {
        /// <summary>
        /// The touch pad number.
        /// </summary>
        public int TouchPadNumber;

        /// <summary>
        /// True if touched, false is not, so if released.
        /// </summary>
        public bool Touched;
    }
}
