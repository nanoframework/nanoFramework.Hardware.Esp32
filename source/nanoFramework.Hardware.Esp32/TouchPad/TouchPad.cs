//
// Copyright (c) 2018 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.Hardware.Esp32.TouchPad
{
	/// <summary>
	/// TouchPad sensor using interrupts
	/// </summary>
	public sealed class TouchPad : TouchPadBase
	{
		/// <summary>
		/// Event raised when touch is detected.
		/// </summary>
		/// <param name="sender"></param>
		//todo: add a new enumerable to EventCategory in lib-nanoFramework.Runtime.Events.
		public delegate void TouchPadValueChangedEventHandler(
				Object sender);
		//TouchPadValueChangedEventArgs e);


		/// <summary>
		/// Simplified constructor which use default settings
		/// </summary>
		/// <param name="pinNumber">Valid touch pads pin number</param>
		public TouchPad(int pinNumber) : this(pinNumber, new TouchPadConfig())
		{
		}

		/// <summary>
		/// Constructor that allow fine tuning of pit settings
		/// </summary>
		/// <param name="pinNumber">Valid touch pads pin number</param>
		/// <param name="config">Configuration settings</param>
		public TouchPad(int pinNumber, TouchPadConfig config) : base(pinNumber, config)
		{
			SetTouchPadTriggerThreshold(config.InterruptThresholdValue);
		}

		/// <summary>
		/// Set touch sensor FSM mode for interrupt trigger mode.
		/// </summary>
		/// <exception cref="Exception">Native call returned not OK return value.</exception>
		protected override void SetFsmMode()
		{
			if (!base.TouchPadSetFsmMode(TouchFsmMode.Timer))
				throw new Exception();
		}

		/// <summary>
		/// Sets touch pad interrupt threshold.
		/// </summary>throw new Exception($"Setting voltage on pin {_pinNumber} failed.");
		/// <exception cref="Exception">Native call returned not OK return value.</exception>
		private void SetTouchPadTriggerThreshold(float interruptThreshold)
		{
			ushort touchPadValue = TouchPadReadFiltered(_touchPadIndex);
			if (!TouchPadSetThresh(_touchPadIndex, (ushort)(touchPadValue * interruptThreshold)))
				throw new Exception(); ;
		}

	}
}
