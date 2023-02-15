// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// Specific to S2/S3, the denoise capacitance used to denoise the touch pad.
    /// </summary>
    public class DenoiseSetting
    {
        private DenoiseCapacitance _denoiseCapacitance;
        private DenoiseRange _denoiseRange;

        /// <summary>
        /// Gets or sets the denoise capacitance.
        /// </summary>
        public DenoiseCapacitance DenoiseCapacitance
        {
            get => _denoiseCapacitance;
            set
            {
                _denoiseCapacitance = value;
            }
        }

        /// <summary>
        /// Gets or sets the denoise range.
        /// </summary>
        public DenoiseRange DenoiseRange
        {
            get => _denoiseRange;
            set
            {
                _denoiseRange = value;
            }
        }
    }
}
