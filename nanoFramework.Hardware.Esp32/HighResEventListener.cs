//
// Copyright (c) 2018 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Collections;
using nanoFramework.Runtime.Events;

namespace nanoFramework.Hardware.Esp32
{
    internal class HighResEventListener : IEventProcessor, IEventListener
    {
        System.Collections.ArrayList HighResTimers = new ArrayList();


        public HighResEventListener()
        {
            EventSink.AddEventProcessor(EventCategory.Custom, this);
            EventSink.AddEventListener(EventCategory.Custom, this);
        }

        public void InitializeForEventSource()
        {
        }

        /// <summary>
        /// Fire event on correct timer
        /// </summary>
        /// <param name="ev"></param>
        /// <returns></returns>
        public bool OnEvent(BaseEvent ev)
        {
            if ( ev is HighResTimerEvent)
            {
                foreach (object obj in HighResTimers)
                {
                    HighResTimer timer = obj as HighResTimer;
                    if (timer._timerHandle == ((HighResTimerEvent)ev).TimerHandle)
                    {
                        timer.OnHighResTimerExpiredInternal((HighResTimerEvent)ev);
                        break;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Process an event
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public BaseEvent ProcessEvent(uint data1, uint data2, DateTime time)
        {
            HighResTimerEventType eventType = (HighResTimerEventType)(data1 & 0xFF);
            
            if (eventType >= HighResTimerEventType.TimerExpired)
            {
                HighResTimerEvent timerEvent = new HighResTimerEvent();
                timerEvent.EventType = eventType;
                timerEvent.TimerHandle = data2;

                return timerEvent;
            }
            return null;
        }


        internal void AddHighResTimer(HighResTimer timer)
        {
            HighResTimers.Add(timer);
        }

        internal void RemoveHighResTimer(HighResTimer timer)
        {
            HighResTimers.Remove(timer);
        }
    }
}
