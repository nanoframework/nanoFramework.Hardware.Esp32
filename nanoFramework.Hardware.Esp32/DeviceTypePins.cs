//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;

namespace nanoFramework.Hardware.Esp32
{
    internal enum ValueTypes
    {
        Index = 0,
        DeviceIndex = 0x00000100,
        DeviceType  = 0x00010000,
    }

    /// <summary>
    /// Device Types
    /// </summary>
    public enum DeviceTypes
    {
        /// <summary>
        /// GPIO Device type
        /// </summary>
        GPIO   = 0 * ValueTypes.DeviceType,

        /// <summary>
        /// SPI Device type
        /// </summary>
        SPI = 1 * ValueTypes.DeviceType,

        /// <summary>
        /// I2C Device type
        /// </summary>
        I2C = 2 * ValueTypes.DeviceType,

        /// <summary>
        /// SERIAL Device type
        /// </summary>
        SERIAL = 3 * ValueTypes.DeviceType,

        /// <summary>
        /// PWM Device type
        /// </summary>
        PWM = 4 * ValueTypes.DeviceType,

        /// <summary>
        /// ADC Device type
        /// </summary>
        ADC = 5 * ValueTypes.DeviceType,

        /// <summary>
        /// I2S Device type
        /// </summary>
        I2S = 6 * ValueTypes.DeviceType,

        /// <summary>
        /// SDMMC SD card pins
        /// </summary>
        SDMMC = 8 * ValueTypes.DeviceType
    };

    /// <summary>
    /// Defines values used to change pin configuration via the GPIO alternate 
    /// drivemode interface.
    /// </summary>
    public enum DeviceFunction
    {
        /// <summary>
        /// Device function MOSI for SPI1 
        /// </summary>
        SPI1_MOSI = DeviceTypes.SPI + (1 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function MISO for SPI1 
        /// </summary>
        SPI1_MISO = DeviceTypes.SPI + (1 * ValueTypes.DeviceIndex) + 1,
        /// <summary>
        /// Device function CLOCK for SPI1 
        /// </summary>
        SPI1_CLOCK = DeviceTypes.SPI + (1 * ValueTypes.DeviceIndex) + 2,

        /// <summary>
        /// Device function MOSI for SPI2 
        /// </summary>
        SPI2_MOSI = DeviceTypes.SPI + (2 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function MISO for SPI2 
        /// </summary>
        SPI2_MISO = DeviceTypes.SPI + (2 * ValueTypes.DeviceIndex) + 1,
        /// <summary>
        /// Device function CLOCK for SPI2 
        /// </summary>
        SPI2_CLOCK = DeviceTypes.SPI + (2 * ValueTypes.DeviceIndex) + 2,

        /// <summary>
        /// Device function DATA for I2C1 
        /// </summary>
        I2C1_DATA = DeviceTypes.I2C + (1 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function CLOCK for I2C1 
        /// </summary>
        I2C1_CLOCK = DeviceTypes.I2C + (1 * ValueTypes.DeviceIndex) + 1,

        /// <summary>
        /// Device function DATA for I2C2 
        /// </summary>
        I2C2_DATA = DeviceTypes.I2C + (2 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function CLOCK for I2C2 
        /// </summary>
        I2C2_CLOCK = DeviceTypes.I2C + (2 * ValueTypes.DeviceIndex) + 1,

        /// <summary>
        /// Device function TX data for COM1 
        /// </summary>
        COM1_TX  = DeviceTypes.SERIAL + (1 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function RX data for COM1 
        /// </summary>
        COM1_RX = DeviceTypes.SERIAL + (1 * ValueTypes.DeviceIndex) + 1,
        /// <summary>
        /// Device function Request to Send(RTS) for COM1 
        /// </summary>
        COM1_RTS = DeviceTypes.SERIAL + (1 * ValueTypes.DeviceIndex) + 2,
        /// <summary>
        /// Device function Clear to Send(CTS) for COM1 
        /// </summary>
        COM1_CTS = DeviceTypes.SERIAL + (1 * ValueTypes.DeviceIndex) + 3,

        /// <summary>
        /// Device function TX data for COM2 
        /// </summary>
        COM2_TX = DeviceTypes.SERIAL + (2 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function RX data for COM2 
        /// </summary>
        COM2_RX = DeviceTypes.SERIAL + (2 * ValueTypes.DeviceIndex) + 1,
        /// <summary>
        /// Device function Request to Send(RTS) for COM2 
        /// </summary>
        COM2_RTS = DeviceTypes.SERIAL + (2 * ValueTypes.DeviceIndex) + 2,
        /// <summary>
        /// Device function Clear to Send(CTS) for COM2 
        /// </summary>
        COM2_CTS = DeviceTypes.SERIAL + (2 * ValueTypes.DeviceIndex) + 3,

        /// <summary>
        /// Device function TX data for COM3 
        /// </summary>
        COM3_TX = DeviceTypes.SERIAL + (3 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function RX data for COM3 
        /// </summary>
        COM3_RX = DeviceTypes.SERIAL + (3 * ValueTypes.DeviceIndex) + 1,
        /// <summary>
        /// Device function Request to Send(RTS) for COM3 
        /// </summary>
        COM3_RTS = DeviceTypes.SERIAL + (3 * ValueTypes.DeviceIndex) + 2,
        /// <summary>
        /// Device function Clear to Send(CTS) for COM3 
        /// </summary>
        COM3_CTS = DeviceTypes.SERIAL + (3 * ValueTypes.DeviceIndex) + 3,

        /// <summary>
        /// Device function TX data for COM4 
        /// </summary>
        COM4_TX = DeviceTypes.SERIAL + (4 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function RX data for COM4 
        /// </summary>
        COM4_RX = DeviceTypes.SERIAL + (4 * ValueTypes.DeviceIndex) + 1,
        /// <summary>
        /// Device function Request to Send(RTS) for COM4
        /// </summary>
        COM4_RTS = DeviceTypes.SERIAL + (4 * ValueTypes.DeviceIndex) + 2,
        /// <summary>
        /// Device function Clear to Send(CTS) for COM4
        /// </summary>
        COM4_CTS = DeviceTypes.SERIAL + (4 * ValueTypes.DeviceIndex) + 3,

        /// <summary>
        /// Device function PWM1 
        /// </summary>
        PWM1 =  DeviceTypes.PWM + (1 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function PWM2 
        /// </summary>
        PWM2 =  DeviceTypes.PWM + (2 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function PWM3 
        /// </summary>
        PWM3 =  DeviceTypes.PWM + (3 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function PWM4 
        /// </summary>
        PWM4 =  DeviceTypes.PWM + (4 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function PWM5 
        /// </summary>
        PWM5 =  DeviceTypes.PWM + (5 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function PWM6 
        /// </summary>
        PWM6 =  DeviceTypes.PWM + (6 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function PWM7 
        /// </summary>
        PWM7 =  DeviceTypes.PWM + (7 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function PWM8 
        /// </summary>
        PWM8 =  DeviceTypes.PWM + (8 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function PWM9
        /// </summary>
        PWM9 =  DeviceTypes.PWM + (9 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function PWM10 
        /// </summary>
        PWM10 = DeviceTypes.PWM + (10 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function PWM11 
        /// </summary>
        PWM11 = DeviceTypes.PWM + (11 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function PWM12 
        /// </summary>
        PWM12 = DeviceTypes.PWM + (12 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function PWM13 
        /// </summary>
        PWM13 = DeviceTypes.PWM + (13 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function PWM14 
        /// </summary>
        PWM14 = DeviceTypes.PWM + (14 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function PWM15 
        /// </summary>
        PWM15 = DeviceTypes.PWM + (15 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function PWM16 
        /// </summary>
        PWM16 = DeviceTypes.PWM + (16 * ValueTypes.DeviceIndex) + 0,

        /// <summary>
        /// ADC1 channel 0
        /// </summary>
        ADC1_CH0 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// ADC1 channel 1
        /// </summary>
        ADC1_CH1 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 1,
        /// <summary>
        /// ADC1 channel 2
        /// </summary>
        ADC1_CH2 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 2,
        /// <summary>
        /// ADC1 channel 3
        /// </summary>
        ADC1_CH3 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 3,
        /// <summary>
        /// ADC1 channel 4
        /// </summary>
        ADC1_CH4 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 4,
        /// <summary>
        /// ADC1 channel 5 
        /// </summary>
        ADC1_CH5 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 5,
        /// <summary>
        /// ADC1 channel 6
        /// </summary>
        ADC1_CH6 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 6,
        /// <summary>
        /// ADC1 channel 7
        /// </summary>
        ADC1_CH7 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 7,

        /// <summary>
        /// ADC1 channel 8
        /// Internal Temperture sensor (VP)
        /// </summary>
        ADC1_CH8 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 8,
        /// <summary>
        /// ADC1 channel 9
        /// Internal Hall Sensor (VN)
        /// </summary>
        ADC1_CH9 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 9,
        /// <summary>
        /// ADC1 channel 10
        /// Internally ESP32 Adc2 channel 10
        /// </summary>
        ADC1_CH10 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 10,
        /// <summary>
        /// ADC1 channel 11
        /// Internally ESP32 Adc2 channel 11
        /// </summary>
        ADC1_CH11 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 11,
        /// <summary>
        /// ADC1 channel 12
        /// Internally ESP32 Adc2 channel 12
        /// </summary>
        ADC1_CH12 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 12,
        /// <summary>
        /// ADC1 channel 13 
        /// Internally ESP32 Adc2 channel 13
        /// </summary>
        ADC1_CH13 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 13,
        /// <summary>
        /// ADC1 channel 14
        /// Internally ESP32 Adc2 channel 14
        /// </summary>
        ADC1_CH14 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 14,
        /// <summary>
        /// ADC1 channel 15
        /// Internally ESP32 Adc2 channel 15
        /// </summary>
        ADC1_CH15 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 15,
        /// <summary>
        /// ADC1 channel 16
        /// Internally ESP32 Adc2 channel 16
        /// </summary>
        ADC1_CH16 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 16,
        /// <summary>
        /// ADC1 channel 17
        /// Internally ESP32 Adc2 channel 17
        /// </summary>
        ADC1_CH17 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 17,
        /// <summary>
        /// ADC1 channel 18
        /// Internally ESP32 Adc2 channel 18
        /// </summary>
        ADC1_CH18 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 18,
        /// <summary>
        /// ADC1 channel 19
        /// Internally ESP32 Adc2 channel 19
        /// </summary>
        ADC1_CH19 = DeviceTypes.ADC + (1 * ValueTypes.DeviceIndex) + 19,

        /// <summary>
        /// I2S1 function Master Clock.
        /// Used only in master mode.
        /// </summary>
        I2S1_MCK = DeviceTypes.I2S + (1 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// I2S1 function Bit Clock.
        /// Used for general purpose read and write on the I2S bus.
        /// </summary>
        I2S1_BCK = DeviceTypes.I2S + (1 * ValueTypes.DeviceIndex) + 1,
        /// <summary>
        /// I2S1 function WS.
        /// Used if your have stereo.
        /// </summary>
        I2S1_WS = DeviceTypes.I2S + (1 * ValueTypes.DeviceIndex) + 2,
        /// <summary>
        /// I2S1 function DATA_OUT.
        /// Used for output data typically on a speaker.
        /// </summary>
        I2S1_DATA_OUT = DeviceTypes.I2S + (1 * ValueTypes.DeviceIndex) + 3,
        /// <summary>
        /// I2S1 function MDATA_IN.
        /// Used for input data typically from a microphone.
        /// </summary>
        I2S1_MDATA_IN = DeviceTypes.I2S + (1 * ValueTypes.DeviceIndex) + 4,

        /// <summary>
        /// I2S2 function Master Clock.
        /// Used only in master mode.
        /// </summary>
        I2S2_MCK = DeviceTypes.I2S + (2 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// I2S2 function Bit Clock.
        /// Used for general purpose read and write on the I2S bus.
        /// </summary>
        I2S2_BCK = DeviceTypes.I2S + (2 * ValueTypes.DeviceIndex) + 1,
        /// <summary>
        /// I2S2 function WS.
        /// Used if your have stereo.
        /// </summary>
        I2S2_WS = DeviceTypes.I2S + (2 * ValueTypes.DeviceIndex) + 2,
        /// <summary>
        /// I2S2 function DATA_OUT.
        /// Used for output data typically on a speaker.
        /// </summary>
        I2S2_DATA_OUT = DeviceTypes.I2S + (2 * ValueTypes.DeviceIndex) + 3,
        /// <summary>
        /// I2S2 function MDATA_IN.
        /// Used for input data typically from a microphone.
        /// </summary>
        I2S2_MDATA_IN = DeviceTypes.I2S + (2 * ValueTypes.DeviceIndex) + 4,

        /// <summary>
        /// SDMMC clock pin.
        /// </summary>
        SDMMC1_CLOCK = DeviceTypes.SDMMC + (1 * ValueTypes.DeviceIndex) + 0,

        /// <summary>
        /// SDMMC1 command pin
        /// </summary>
        SDMMC1_COMMAND = DeviceTypes.SDMMC + (1 * ValueTypes.DeviceIndex) + 1,

        /// <summary>
        /// SDMMC1 data pin D0
        /// </summary>
        SDMMC1_D0 = DeviceTypes.SDMMC + (1 * ValueTypes.DeviceIndex) + 2,

        /// <summary>
        /// SDMMC1 data pin D1
        /// </summary>
        SDMMC1_D1 = DeviceTypes.SDMMC + (1 * ValueTypes.DeviceIndex) + 3,

        /// <summary>
        /// SDMMC1 data pin D2
        /// </summary>
        SDMMC1_D2 = DeviceTypes.SDMMC + (1 * ValueTypes.DeviceIndex) + 4,

        /// <summary>
        /// SDMMC1 data pin D3
        /// </summary>
        SDMMC1_D3 = DeviceTypes.SDMMC + (1 * ValueTypes.DeviceIndex) + 5,

        /// <summary>
        /// SDMMC2 clock pin.
        /// </summary>
        SDMMC2_CLOCK = DeviceTypes.SDMMC + (2 * ValueTypes.DeviceIndex) + 0,

        /// <summary>
        /// SDMMC2 command pin
        /// </summary>
        SDMMC2_COMMAND = DeviceTypes.SDMMC + (2 * ValueTypes.DeviceIndex) + 1,

        /// <summary>
        /// SDMMC2 data pin D0
        /// </summary>
        SDMMC2_D0 = DeviceTypes.SDMMC + (2 * ValueTypes.DeviceIndex) + 2,

        /// <summary>
        /// SDMMC2 data pin D1
        /// </summary>
        SDMMC2_D1 = DeviceTypes.SDMMC + (2 * ValueTypes.DeviceIndex) + 3,

        /// <summary>
        /// SDMMC2 data pin D2
        /// </summary>
        SDMMC2_D2 = DeviceTypes.SDMMC + (2 * ValueTypes.DeviceIndex) + 4,

        /// <summary>
        /// SDMMC2 data pin D3
        /// </summary>
        SDMMC2_D3 = DeviceTypes.SDMMC + (2 * ValueTypes.DeviceIndex) + 5
    };
 }
