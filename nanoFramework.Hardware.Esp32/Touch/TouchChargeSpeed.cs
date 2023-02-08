// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

using System;

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// Charge and discharge speed settings.
    /// </summary>
    public struct TouchChargeSpeed
    {
        /// <summary>
        /// The initial charge
        /// </summary>
        public enum InitialCharge
        {
            /// <summary>Starts low.</summary>
            Low = 0,

            /// <summary>Starts high.</summary>
            High,
        }

        /// <summary>
        /// The charge speed, 7 different positions.
        /// </summary>
        public enum ChargeSpeed
        {
            /// <summary>No charge, values will always be zero.</summary>
            Zero = 0,

            /// <summary>Minimum charge</summary>
            Slowest,

            /// <summary>Speed 2.</summary>
            Speed2,

            /// <summary>Speed 3.</summary>
            Speed3,

            /// <summary>Speed 4.</summary>
            Speed4,

            /// <summary>Speed 5.</summary>
            Speed5,

            /// <summary>Speed 6.</summary>
            Speed6,

            /// <summary>Fastest speed.</summary>
            Fastest,
        }

        /// <summary>Charge speed.</summary>
        public ChargeSpeed Speed { get; set; }

        /// <summary>Initial charge.</summary>
        public InitialCharge Charge { get; set; }
    }
}
