// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

using System;

namespace nanoFramework.Hardware.Esp32.Touch
{
    public class S2S3PeriodSetting : IPeriodSetting
    {
        private PeriodeSettingMode _periodeSettingMode;

        public PeriodeSettingMode PeriodeSettingMode
        {
            get => _periodeSettingMode;
            set
            {
                _periodeSettingMode = value;
            }
        }
    }
}
