//
// Copyright (c) 2018 The nanoFramework project contributors
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
        /// Device function MISI for SPI1 
        /// </summary>
        SPI1_MISI = DeviceTypes.SPI + (1 * ValueTypes.DeviceIndex) + 1,
        /// <summary>
        /// Device function CLOCK for SPI1 
        /// </summary>
        SPI1_CLOCK = DeviceTypes.SPI + (1 * ValueTypes.DeviceIndex) + 2,

        /// <summary>
        /// Device function MOSI for SPI2 
        /// </summary>
        SPI2_MOSI = DeviceTypes.SPI + (2 * ValueTypes.DeviceIndex) + 0,
        /// <summary>
        /// Device function MISI for SPI2 
        /// </summary>
        SPI2_MISI = DeviceTypes.SPI + (2 * ValueTypes.DeviceIndex) + 1,
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
    };
 }
