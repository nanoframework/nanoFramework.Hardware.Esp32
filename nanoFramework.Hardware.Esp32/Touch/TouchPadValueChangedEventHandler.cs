// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

using System;

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// Delegate function for the event handler.
    /// </summary>
    /// <param name="sender">The sender <see cref="TouchPad"/>.</param>
    /// <param name="e">The touch arguments.</param>
    public delegate void TouchPadValueChangedEventHandler(
        object sender,
        TouchPadEventArgs e);
}
