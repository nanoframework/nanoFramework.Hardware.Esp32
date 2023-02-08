// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

using nanoFramework.Runtime.Events;
using System;
using System.Collections;

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// Event handler to redistribute the coming internal events.
    /// </summary>
    internal class TouchPadEventHandler : IEventProcessor, IEventListener
    {
        // Needed to find the proper TouchPad
        private readonly ArrayList _pinMap = new ArrayList();

        public TouchPadEventHandler()
        {
            EventSink.AddEventProcessor(EventCategory.Touch, this);
            EventSink.AddEventListener(EventCategory.Touch, this);
        }

        public void InitializeForEventSource()
        {
        }

        public bool OnEvent(BaseEvent ev)
        {
            var pinEvent = (TouchPadEvent)ev;
            TouchPad padNumber = null;

            lock (_pinMap.SyncRoot)
            {
                padNumber = FindGpioPin(pinEvent.TouchPadNumber);
            }

            // Avoid calling this under a lock to prevent a potential lock inversion.
            if (padNumber != null)
            {
                padNumber.OnPinChangedInternal(pinEvent.Touched);
            }

            return true;
        }

        public BaseEvent ProcessEvent(uint data1, uint data2, DateTime time)
        {
            return new TouchPadEvent
            {
                TouchPadNumber = (int)(data1 >> 16),
                Touched = data2 == 1
            };
        }

        public void AddPin(TouchPad touchPad)
        {
            lock (_pinMap.SyncRoot)
            {
                _pinMap.Add(touchPad);
            }
        }

        public void RemovePin(int padNumber)
        {
            lock (_pinMap.SyncRoot)
            {
                var pin = FindGpioPin(padNumber);

                if (pin != null)
                {
                    _pinMap.Remove(pin);
                }
            }
        }

        private TouchPad FindGpioPin(int padNumber)
        {
            for (int i = 0; i < _pinMap.Count; i++)
            {
                if (((TouchPad)_pinMap[i]).TouchPadNumber == padNumber)
                {
                    return (TouchPad)_pinMap[i];
                }
            }

            return null;
        }
    }
}
