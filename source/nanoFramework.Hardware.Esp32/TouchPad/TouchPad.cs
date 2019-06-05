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

    public TouchPad(int pinNumber) : base(pinNumber)
    {
			if (!base.TouchPadSetFsmMode(TouchFsmMode.TOUCH_FSM_MODE_TIMER))
				throw new Exception("Failed to set FSM mode.");
		}


  }
}
