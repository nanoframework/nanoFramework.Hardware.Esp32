// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.

using System;

namespace nanoFramework.Hardware.Esp32.Touch
{
    /// <summary>
    /// S2 and S3 filter setting.
    /// </summary>
    public class S2S3FilterSetting : IFilterSetting
    {
        private FilterSettingMode _periodeSettingMode;
        private FilterSettingDebounce _filterSettingDebounce;
        private FilterSettingNoiseThreshold _filterSettingNoiseThreshold;
        private IFilterSetting.FilterType _type = IFilterSetting.FilterType.S2_S3;
        private byte _jitterSize;
        private FilterSettingSmoothMode _filterSettingSmoothMode;

        /// <summary>
        /// Gets or sets the <see cref="FilterSettingMode"/>.
        /// </summary>
        public FilterSettingMode PeriodeSettingMode
        {
            get => _periodeSettingMode;
            set
            {
                _periodeSettingMode = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="FilterSettingDebounce"/>.
        /// </summary>
        public FilterSettingDebounce FilterSettingDebounce
        {
            get => _filterSettingDebounce;
            set
            {
                _filterSettingDebounce = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="FilterSettingNoiseThreshold"/>.
        /// </summary>
        public FilterSettingNoiseThreshold FilterSettingNoiseThreshold
        {
            get => _filterSettingNoiseThreshold;
            set
            {
                _filterSettingNoiseThreshold = value;
            }
        }

        /// <summary>
        /// Gets or sets the jitter speed size, values from 0 to 15.
        /// </summary>
        /// <exception cref="ArgumentException">The value must be between 0 and 15.</exception>
        public byte JitterSize
        {
            get => _jitterSize;
            set
            {
                if (value > 15)
                {
                    throw new ArgumentException();
                }

                _jitterSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="FilterSettingSmoothMode"/>.
        /// </summary>
        public FilterSettingSmoothMode FilterSettingSmoothMode
        {
            get => _filterSettingSmoothMode;
            set
            {
                _filterSettingSmoothMode = value;
            }
        }

        /// <inheritdoc/>
        public IFilterSetting.FilterType Type => _type;
    }
}
