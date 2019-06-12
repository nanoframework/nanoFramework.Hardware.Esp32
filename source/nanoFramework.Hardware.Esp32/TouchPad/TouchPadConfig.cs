//
// Copyright (c) 2018 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Hardware.Esp32.TouchPad
{
	/// <summary>
	/// Configuration parameters for TouchPad interrupt based class
	/// </summary>
	public class TouchPadConfig : TouchPadBaseConfig
	{
		/// <summary>
		/// The threshold to trigger interrupt when the pad is touched
		/// </summary>
		public float InterruptThresholdValue { get; set; }

		/// <summary>
		/// Default constructor
		/// </summary>
		public TouchPadConfig() : base()
		{
			// By default, use 2/3 of read value as the threshold to trigger interrupt when the pad is touched.
			InterruptThresholdValue = (float)2 / 3;
		}
	}
}
