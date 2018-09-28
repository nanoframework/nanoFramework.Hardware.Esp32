//
// Copyright (c) 2018 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;
using nanoFramework.Runtime.Events;

namespace nanoFramework.Hardware.Esp32
{
    /// <summary>
    /// Event raised when a High res timer expires. 
    /// </summary>
    public delegate void HighResTimerExpiredEventHandler(
                            HighResTimer sender,
                            Object e);


    /// <summary>
    /// The class encapsulates the ESP32 High Resolution Timer API.
    /// </summary>
    public class HighResTimer : IDisposable
    {
        internal Int32 _timerHandle;
        internal bool  _disposedValue = false; // To detect redundant calls


        private static HighResEventListener s_eventListener = new HighResEventListener();

        // This is used as the lock object 
        // a lock is required because multiple threads can access the HighResTimer
        private object _syncLock = new object();

        /// <summary>
        /// Event raised when a HighRes timer expires.  
        /// </summary>
        public event HighResTimerExpiredEventHandler OnHighResTimerExpired;


        internal void OnHighResTimerExpiredInternal(object e)
        {
            HighResTimerExpiredEventHandler callbacks = null;

            lock (_syncLock)
            {
                if (!_disposedValue)
                {
                    callbacks = OnHighResTimerExpired;
                }
            }

            callbacks?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Returns the number of micro seconds since boot
        /// </summary>
        /// <returns></returns>
        public static UInt64 GetCurrent()
        {
            return NativeGetCurrent();
        }

        /// <summary>
        /// Create a High Resolution Timer. A maximum of 10 timers can be created.
        /// </summary>
        public HighResTimer()
        {
            _timerHandle = NativeEspTimerCreate();
            s_eventListener.AddHighResTimer(this);
        }


        /// <summary>
        /// Stop the Timer.
        /// </summary>
        public void Stop()
        {
            NativeStop();
        }

        /// <summary>
        /// Start a one shot timer.
        /// Once the timer has expired the timer event will be fired.
        /// </summary>
        /// <param name="timeout_us">Timeout in mirco seconds</param>
        public void StartOneShot(UInt64 timeout_us)
        {
            NativeStartOneShot(timeout_us);
        }

        /// <summary>
        /// Start a periodic timer.
        /// </summary>
        /// <param name="period_us">Period between firing timer events.</param>
        /// <returns></returns>
        public void StartOnePeriodic(UInt64 period_us)
        {
            NativeStartPeriodic(period_us);
        }

        #region IDisposable Support

        /// <summary>
        /// Dispose(bool disposing)
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                s_eventListener.RemoveHighResTimer(this);

                NativeEspTimerDispose();

                _disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~HighResTimer()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        /// <summary>
        /// Dispose HighResTimer
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
        #endregion

        #region Native Calls
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern Int32 NativeEspTimerCreate();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeEspTimerDispose();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern UInt64 NativeGetCurrent();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeStop();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeStartOneShot(UInt64 timeout);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeStartPeriodic(UInt64 period);

        #endregion
    }

}
