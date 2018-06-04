using System;

namespace nanoFramework.Hardware.Esp32
{
    /// <summary>
    /// Encapsulates the ESP32 native errors
    /// </summary>
    public class Errors
    {
        // <summary>
        // Espressif error codes
        // </summary>
        public enum Esp : Int32
        {
            /// <summary>
            /// No error
            /// </summary>
            ESP_OK = 0,
            /// <summary>
            /// The function failed
            /// </summary>
            ESP_FAIL = -1,

            /// <summary>
            /// Memory allocation failed error
            /// </summary>
            ESP_ERR_NO_MEM = 0x101,
 
            /// <summary>
            /// Invalid argument error
            /// </summary>
            ESP_ERR_INVALID_ARG = 0x102,
            
            /// <summary>
            /// Invalid state error
            /// </summary>
            ESP_ERR_INVALID_STATE = 0x103,
            
            /// <summary>
            /// Invalid size error
            /// </summary>
            ESP_ERR_INVALID_SIZE = 0x104,
            
            /// <summary>
            /// The function failed
            /// </summary>
            ESP_ERR_NOT_FOUND = 0x105,
            
            /// <summary>
            /// Function not supported error 
            /// </summary>
            ESP_ERR_NOT_SUPPORTED = 0x106,
            
            /// <summary>
            /// Timeout error
            /// </summary>
            ESP_ERR_TIMEOUT = 0x107,
            
            /// <summary>
            /// Invalid response
            /// </summary>
            ESP_ERR_INVALID_RESPONSE = 0x108,
            
            /// <summary>
            /// CRC error
            /// </summary>
            ESP_ERR_INVALID_CRC = 0x109,
            
            /// <summary>
            /// Invalid version
            /// </summary>
            ESP_ERR_INVALID_VERSION = 0x10A,
            
            /// <summary>
            /// Invalid MAC address
            /// </summary>
            ESP_ERR_INVALID_MAC = 0x10B,

            /// <summary>
            /// Base of WiFi errors
            /// </summary>
            ESP_ERR_WIFI_BASE = 0x3000
        }


    }
}
