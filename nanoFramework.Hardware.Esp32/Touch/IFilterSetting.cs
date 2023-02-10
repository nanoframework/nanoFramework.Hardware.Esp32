// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

using System;

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// Interface for the filtering configuration, they are different on the ESP32 and the S2/S3 series.
    /// </summary>
    public interface IFilterSetting
    {
        /// <summary>
        /// The configuration type
        /// </summary>
        public enum FilterType
        {
            Esp32 = 0,
            S2_S3
        }

        /// <summary>
        /// The configuration type.
        /// </summary>
        public FilterType Type { get; }
    }
}
