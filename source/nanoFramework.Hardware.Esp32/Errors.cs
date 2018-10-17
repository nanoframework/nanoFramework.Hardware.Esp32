//
// Copyright (c) 2018 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.Hardware.Esp32
{
    /// <summary>
    /// Encapsulates the ESP32 native errors
    /// </summary>
    public enum EspNativeError : Int32
    {
        /// <summary>
        /// No error
        /// </summary>
        OK = 0,
        /// <summary>
        /// The function failed
        /// </summary>
        FAIL = -1,

        /// <summary>
        /// Memory allocation failed error
        /// </summary>
        NO_MEM = 0x101,

        /// <summary>
        /// Invalid argument error
        /// </summary>
        INVALID_ARG = 0x102,

        /// <summary>
        /// Invalid state error
        /// </summary>
        INVALID_STATE = 0x103,

        /// <summary>
        /// Invalid size error
        /// </summary>
        INVALID_SIZE = 0x104,

        /// <summary>
        /// The function failed
        /// </summary>
        NOT_FOUND = 0x105,

        /// <summary>
        /// Function not supported error 
        /// </summary>
        NOT_SUPPORTED = 0x106,

        /// <summary>
        /// Timeout error
        /// </summary>
        TIMEOUT = 0x107,

        /// <summary>
        /// Invalid response
        /// </summary>
        INVALID_RESPONSE = 0x108,

        /// <summary>
        /// CRC error
        /// </summary>
        INVALID_CRC = 0x109,

        /// <summary>
        /// Invalid version
        /// </summary>
        INVALID_VERSION = 0x10A,

        /// <summary>
        /// Invalid MAC address
        /// </summary>
        INVALID_MAC = 0x10B,

        /// <summary>
        /// Base of WiFi errors
        /// </summary>
        WIFI_BASE = 0x3000
    }
}
