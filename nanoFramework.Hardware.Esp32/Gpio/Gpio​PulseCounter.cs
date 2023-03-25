// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;

namespace System.Device.Gpio
{
    /// <summary>
    /// Counts changes of a specified polarity on a general-purpose I/O (GPIO) pin.
    /// </summary>
    /// <remarks>
    /// <para>
    /// When the pin is an input, interrupts are used to detect pin changes unless the MCU supports a counter in hardware. 
    /// Changes of the pin are enabled for the specified polarity, and the count is incremented when a change occurs.
    /// </para>
    /// <para>
    /// When the pin is an output, the count will increment whenever the specified transition occurs on the pin. 
    /// For example, if the pin is configured as an output and counting is enabled for rising edges, writing a 0 and then a 1 will cause the count to be incremented.
    /// </para>
    /// </remarks>
    public sealed class Gpio​PulseCounter : IDisposable
    {
        // property backing fields
        private readonly int _pinNumberA;
        private readonly int _pinNumberB;
        private GpioPulsePolarity _polarity = GpioPulsePolarity.Falling;
        private bool _countActive = false;
        private ushort _filter;

        // this is used as the lock object 
        // a lock is required because multiple threads can access the Gpio​Change​Counter
        private readonly object _syncLock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="Gpio​PulseCounter"/> class associated with the specified pin.
        /// Only a single <see cref="Gpio​PulseCounter"/> may be associated with a pin at any given time.
        /// </summary>
        /// <param name="pinNumberA">The first pin on which to count changes.</param>
        /// <param name="pinNumberB">The second pin which can be used to control how the count are done on the first pin. If no use, leave at at -1.</param>
        /// <exception cref="ArgumentException">TThe pin is already associated with a change counter.That change counter must be disposed before the pin can be associated with a new change counter.</exception>
        public Gpio​PulseCounter(int pinNumberA, int pinNumberB = -1)
        {
            if (pinNumberA < 0)
            {
                throw new ArgumentException();
            }

            _pinNumberA = pinNumberA;
            _pinNumberB = pinNumberB;

            NativeInit();
        }

        /// <summary>
        /// Gets whether pin change counting is currently active.
        /// </summary>
        /// <returns><c>TRUE</c> if this pin change counting is active and <c>FALSE</c> otherwise.</returns>
        public bool IsStarted => _countActive;

        /// <summary>
        /// Gets or sets the polarity of transitions that will be counted. The polarity may only be changed when pin counting is not started.
        /// </summary>
        /// <remarks><para>The default polarity value is Falling. See <see cref="GpioPulsePolarity"></see> for more information on polarity values. Counting a single edge can be considerably more efficient than counting both edges.</para>
        /// </remarks>
        /// <exception cref="InvalidOperationException">Change counting is currently active. Polarity can only be set before calling Start() or after calling Stop().</exception>        
        public GpioPulsePolarity Polarity
        {
            get => _polarity;

            set
            {
                CheckIfActive(true);

                _polarity = value;
            }
        }

        /// <summary>
        /// Gets or sets the signal filter value in microseconds. The filter value may only be changed when pin counting is not started.
        /// Valid values from 0 to 1023. The clock used is 80 MHz, filter is a multiple of the period of the clock.
        /// </summary>
        /// <exception cref="ArgumentException">Value must be between 0 and 1023.</exception>
        public ushort FilterPulses
        {
            get => _filter;

            set
            {
                // filter_val is a 10-bit value, so the maximum filter_val should be limited to 1023.
                // PCNT signal filter value, counter in APB_CLK cycles
                // APB_CLK = 80 MHz
                if (value > 1023)
                {
                    throw new ArgumentException();
                }

                _filter = value;
            }
        }

        /// <summary>
        /// Reads the current count of polarity changes. Before counting has been started, this will return 0.
        /// </summary>
        /// <returns>A <see cref="GpioPulseCount" /> structure containing a count and an associated timestamp.</returns>
        /// <exception cref="ObjectDisposedException">The change counter or the associated pin has been disposed.</exception>        
        public GpioPulseCount Read()
        {
            return ReadInternal(false);
        }

        internal GpioPulseCount ReadInternal(bool reset)
        {
            GpioPulseCount changeCount;

            lock (_syncLock)
            {
                if (_disposedValue) { throw new ObjectDisposedException(); }

                changeCount = NativeRead(reset);
            }
            return changeCount;
        }

        /// <summary>
        /// Resets the count to 0 and returns the previous count.
        /// </summary>
        /// <returns>A <see cref="GpioPulseCount" /> structure containing a count and an associated timestamp.</returns>
        /// <exception cref="ObjectDisposedException">The change counter or the associated pin has been disposed.</exception>
        public GpioPulseCount Reset()
        {
            return ReadInternal(true);
        }

        /// <summary>
        /// Starts counting changes in pin polarity. This method may only be called when change counting is not already active.
        /// </summary>
        /// <remarks>
        /// <para>Calling Start() may enable or reconfigure interrupts for the pin.</para>
        /// <para>The following exceptions can be thrown by this method:</para>
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The change counter or the associated pin has been disposed.</exception>
        /// <exception cref="InvalidOperationException">Change counting has already been started.</exception>
        public void Start()
        {
            lock (_syncLock)
            {
                if (_disposedValue) { throw new ObjectDisposedException(); }

                CheckIfActive(true);

                _countActive = true;

                NativeStart();
            }
        }

        /// <summary>
        /// Stop counting changes in pin polarity. This method may only be called when change counting is currently active.
        /// </summary>
        /// <remarks>
        /// <para>Calling Stop() may enable or reconfigure interrupts for the pin.</para>
        /// <para>The following exceptions can be thrown by this method:</para>
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The change counter or the associated pin has been disposed.</exception>
        /// <exception cref="InvalidOperationException">Change counting has not been started.</exception>
        public void Stop()
        {
            lock (_syncLock)
            {
                if (_disposedValue) { throw new ObjectDisposedException(); }

                CheckIfActive(false);

                _countActive = false;

                NativeStop();
            }
        }


        private void CheckIfActive(bool state)
        {
            if (_countActive == state)
            {
                throw (new InvalidOperationException());
            }
        }


        #region IDisposable Support

        private bool _disposedValue = false;

        void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // No managed object to dispose.
                }

                NativeDispose();

                _disposedValue = true;
            }
        }

#pragma warning disable 1591
        ~Gpio​PulseCounter()
        {
            Dispose(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            lock (_syncLock)
            {
                Dispose(true);

                GC.SuppressFinalize(this);
            }
        }
        #endregion


        #region Native
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeInit();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern GpioPulseCount NativeRead(bool Reset);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeStart();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeStop();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern void NativeDispose();
        #endregion
    }
}
