//
// Copyright (c) 2018 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;

namespace nanoFramework.Hardware.Esp32
{
    /// <summary>
    /// Controls the logging output.
    /// By default the logging is LOG_LEVEL_NONE as the same port is used for the Visual Studio debug connection when connected via serial port.
    /// </summary>
    class Logging
    {
        /// <summary>
        /// Enumeration of Log levels
        /// </summary>
        public enum LogLevel
        {
            /// <summary>
            /// No log output 
            /// </summary>
            LOG_LEVEL_NONE,
            /// <summary>
            /// Critical errors, software module can not recover on its own 
            /// </summary>
            LOG_LEVEL_ERROR,
            /// <summary>
            /// Error conditions from which recovery measures have been taken 
            /// </summary>
            LOG_LEVEL_WARN,
            /// <summary>
            /// Information messages which describe normal flow of events 
            /// </summary>
            LOG_LEVEL_INFO,
            /// <summary>
            /// Extra information which is not necessary for normal use (values, pointers, sizes, etc). 
            /// </summary>
            LOG_LEVEL_DEBUG,
            /// <summary>
            /// Bigger chunks of debugging information, or frequent messages which can potentially flood the output. 
            /// </summary>
            LOG_LEVEL_VERBOSE
        }

        /// <summary>
        /// Set overall logging level.
        /// </summary>
        /// <param name="level"></param>
        public static void SetLogLevel(LogLevel level)
        {
            SetLogLevel( "*", level);
        }

        /// <summary>
        ///  Set overall logging level for specific tag, tag "*" equals all tags.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="level"></param>
        public static void SetLogLevel(string tag, LogLevel level)
        {
            NativeSetLogLevel(tag, (int)level);
        }

        #region native calls

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern void NativeSetLogLevel(string tag, int level);

        #endregion

    }
}
