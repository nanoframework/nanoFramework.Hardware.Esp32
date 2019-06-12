//
// Copyright (c) 2018 The nanoFramework project contributors
// See LICENSE file in the project root for full license information.
//

namespace nanoFramework.Hardware.Esp32.TouchPad
{
	/// <summary>
	/// TouchPad sensor using polling
	/// </summary>
	public sealed class TouchPadReader : TouchPadBase
	{

		public TouchPadReader(int pinNumber) : this(pinNumber, new TouchPadReaderConfig())
		{ }

		public TouchPadReader(int pinNumber, TouchPadReaderConfig config) : base(pinNumber, config)
		{ }

		public ushort Read()
		{
			//todo: add config option to Read vs ReadFiltered
			return TouchPadReadFiltered(_touchPadIndex);
		}

	}
}
