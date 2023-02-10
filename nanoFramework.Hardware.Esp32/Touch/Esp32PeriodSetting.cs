// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

using System;

namespace nanoFramework.Hardware.Esp32.Touch
{
    public class Esp32PeriodSetting : IPeriodSetting
    {
        private uint _period;
        public uint Period
        {
            get => _period;
            set
            {
                _period = value;
            }
        }
    }
}
