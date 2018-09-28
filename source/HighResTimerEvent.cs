//
// Copyright (c) 2018 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;
using nanoFramework.Runtime.Events;


namespace nanoFramework.Hardware.Esp32
{
    [Flags]
    internal enum HighResTimerEventType : byte
    {
        TimerExpired = 101             // HighRes Timer expired event
    }

    internal class HighResTimerEvent : BaseEvent
    {
        public HighResTimerEventType EventType;
        public uint TimerHandle;

    }
}
