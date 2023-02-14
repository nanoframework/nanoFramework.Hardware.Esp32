// Copyright(c).NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// Specific to S2/S3, the denoise range used to denoise the touch pad.
    /// </summary>
    public enum DenoiseRange
    {
        /// <summary>Denoise range is 12bit.</summary>
        Bit12 = 0,

        /// <summary>Denoise range is 10bit.</summary>
        Bit10 = 1,

        /// <summary>Denoise range is 8bit.</summary>
        Bit8 = 2,

        /// <summary>Denoise range is 4bit.</summary>
        Bit4 = 3,

    }
}
