using System;

namespace nanoFramework.Hardware.Esp32.TouchPad
{
  /// <summary>
  /// TouchPad sensor using polling
  /// </summary>
  public sealed class TouchPadReader : TouchPadBase
  {

    public TouchPadReader(int pinNumber) : base(pinNumber)
    { }


  }
}
