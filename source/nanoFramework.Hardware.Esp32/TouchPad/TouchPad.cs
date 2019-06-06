using System;

namespace nanoFramework.Hardware.Esp32.TouchPad
{
/// <summary>
/// TouchPad sensor using interrupts
/// </summary>
  public sealed class TouchPad : TouchPadBase
  {
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
		/// The default FSM mode is ‘TOUCH_FSM_MODE_SW’. If you want to use interrupt trigger mode, 
		/// then set it to ‘TOUCH_FSM_MODE_TIMER’ after calling init function.
		/// </summary>
		protected override void SetFsmMode()
		{
			if (!base.TouchPadSetFsmMode(TouchFsmMode.TOUCH_FSM_MODE_TIMER))
				throw new Exception("Failed to set FSM mode.");
		}

		private void SetTouchPadTriggerThreshold(float interruptThreshold)
		{
			ushort touchPadValue = TouchPadReadFiltered(_touchPadIndex);
			if (!TouchPadSetThresh(_touchPadIndex, (ushort)(touchPadValue * interruptThreshold)))
				throw new Exception($"Setting interrupt threshold on pin {_pinNumber} failed."); ;
		}

	}
}
