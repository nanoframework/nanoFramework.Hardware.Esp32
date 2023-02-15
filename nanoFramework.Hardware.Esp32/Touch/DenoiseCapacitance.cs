// Copyright(c).NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// Specific to S2/S3, the denoise capacitance used to denoise the touch pad.
    /// </summary>
    public enum DenoiseCapacitance
    {
        /// <summary>Denoise channel internal reference capacitance is 5pf.</summary>
        Cap5pf = 0,

        /// <summary>Denoise channel internal reference capacitance is 6.4pf.</summary>
        Cap6pf4 = 1,

        /// <summary>Denoise channel internal reference capacitance is 7.8pf.</summary>
        Cap7pf8 = 2,

        /// <summary>Denoise channel internal reference capacitance is 9.2pf.</summary>
        Cap9pf2 = 3,

        /// <summary>Denoise channel internal reference capacitance is 10.6pf.</summary>
        Cap10pf6 = 4,

        /// <summary>Denoise channel internal reference capacitance is 12.0pf.</summary>
        Cap12pf0 = 5,

        /// <summary>Denoise channel internal reference capacitance is 13.4pf.</summary>
        Cap13pf4 = 6,

        /// <summary>Denoise channel internal reference capacitance is 14.8pf.</summary>
        Cap14pf8 = 7,
    }
}
