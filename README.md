[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=nanoframework_lib-nanoFramework.Hardware.Esp32&metric=alert_status)](https://sonarcloud.io/dashboard?id=nanoframework_lib-nanoFramework.Hardware.Esp32) [![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=nanoframework_lib-nanoFramework.Hardware.Esp32&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=nanoframework_lib-nanoFramework.Hardware.Esp32) [![NuGet](https://img.shields.io/nuget/dt/nanoFramework.Hardware.Esp32.svg?label=NuGet&style=flat&logo=nuget)]() [![#yourfirstpr](https://img.shields.io/badge/first--timers--only-friendly-blue.svg)](https://github.com/nanoframework/Home/blob/main/CONTRIBUTING.md) [![Discord](https://img.shields.io/discord/478725473862549535.svg?logo=discord&logoColor=white&label=Discord&color=7289DA)](https://discord.gg/gCyBu8T)

![nanoFramework logo](https://raw.githubusercontent.com/nanoframework/Home/main/resources/logo/nanoFramework-repo-logo.png)

-----

### Welcome to the .NET **nanoFramework** nanoFramework.Hardware.Esp32 Library repository

## Build status

| Component | Build Status | NuGet Package |
|:-|---|---|
| nanoFramework.Hardware.Esp32 | [![Build Status](https://dev.azure.com/nanoframework/nanoFramework.Hardware.Esp32/_apis/build/status/nanoFramework.Hardware.Esp32?repoName=nanoframework%2FnanoFramework.Hardware.Esp32&branchName=main)](https://dev.azure.com/nanoframework/nanoFramework.Hardware.Esp32/_build/latest?definitionId=11&repoName=nanoframework%2FnanoFramework.Hardware.Esp32&branchName=main) | [![NuGet](https://img.shields.io/nuget/v/nanoFramework.Hardware.Esp32.svg?label=NuGet&style=flat&logo=nuget)](https://www.nuget.org/packages/nanoFramework.Hardware.Esp32/)  |

## Touch Pad essentials

This section will give you essential elements about how to use Touch Pad pins on ESP32 and ESP32-S2.

### Touch Pad vs GPIO pins

Touch Pad pins numbering is different from GPIO pin. You can check which GPIO pins correspond to which GPIO pin using the following:

```csharp
const int TouchPadNumber = 5;
var pinNum = TouchPad.GetGpioNumberFromTouchNumber(TouchPadNumber);
Console.WriteLine($"Pad {TouchPadNumber} is GPIO{pinNum}");
```

The pin numbering is different on ESP32 and S2. There are 10 valid touch pad on ESP32 (0 to 9) and 13 on S2 (1 to 13).

In this example touch pad 5 will be GPIO 12 on ESP32 and GPIO 5 on S2.

### Basic usage ESP32

On ESP32, if you touch the sensor, the values will be lower, so you have to set a threshold that is lower than the calibration data:

```csharp
TouchPad touchpad = new(TouchPadNumber);
Console.WriteLine($"Calibrating touch pad {touchpad.TouchPadNumber}, DO NOT TOUCH it during the process.");
var calib = touchpad.GetCalibrationData();
Console.WriteLine($"calib: {calib} vs Calibration {touchpad.CalibrationData}");
// On ESP32: Setup a threshold, usually 2/3 or 80% is a good value.
touchpad.Threshold = (uint)(touchpad.CalibrationData * 2 / 3);
touchpad.ValueChanged += TouchpadValueChanged;

Thread.Sleep(Timeout.Infinite);

private static void TouchpadValueChanged(object sender, TouchPadEventArgs e)
{
    Console.WriteLine($"Touchpad {e.PadNumber} is {(e.Touched ? "touched" : "not touched")}");
}
```

### Basic usage S2

On S2, if you touch the sensor, the values will be higher, so you have to set a threshold that is higher than the calibration data and set trigger mode as above:

```csharp
TouchPad touchpad = new(TouchPadNumber);
Console.WriteLine($"Calibrating touch pad {touchpad.TouchPadNumber}, DO NOT TOUCH it during the process.");
var calib = touchpad.GetCalibrationData();
Console.WriteLine($"calib: {calib} vs Calibration {touchpad.CalibrationData}");
// On S2/S3, the actual read values will be higher, so let's use 20% more
TouchPad.TouchTriggerMode = TouchTriggerMode.AboveThreshold;
touchpad.Threshold = (uint)(touchpad.CalibrationData * 1.2);

touchpad.ValueChanged += TouchpadValueChanged;

Thread.Sleep(Timeout.Infinite);

private static void TouchpadValueChanged(object sender, TouchPadEventArgs e)
{
    Console.WriteLine($"Touchpad {e.PadNumber} is {(e.Touched ? "touched" : "not touched")}");
}
```

### Other features

You have quite a lot of other features available, filters, some specific denoising. You can check the sample repository for more details.

## Sleep mode

You can wake up your ESP32 or ESP32-S2 by touch.

### Sleep modes on ESP32

ESP32 can be woke up by 1 or 2 touch pad. Here is how to do it with 1:

```csharp
Sleep.EnableWakeupByTouchPad(PadForSleep1, thresholdCoefficient: 80);
```

And with 2 pads:

```csharp
Sleep.EnableWakeupByTouchPad(PadForSleep1, PadForSleep2);
```

Note that the coefficient can be adjusted by doing couple of tests, there is default value of 80 that seems to work in all cases. The coefficient represent a percentage value.

### Sleep modes on S2

S2 can only be woke up with 1 touch pad. It is recommended to do tests to find the best coefficient:

```csharp
Sleep.EnableWakeupByTouchPad(PadForSleep, thresholdCoefficient: 90);
```

## UART wake up from light sleep mode

It is possible to use light sleep in any supported nanoFramework ESP32 with UART wake up. There are few elements to keep in mind:

* You **must** properly setup your COM port, in the following for COM2:

    ```csharp
    nanoFramework.Hardware.Esp32.Configuration.SetPinFunction(19, nanoFramework.Hardware.Esp32.DeviceFunction.COM2_TX);
    nanoFramework.Hardware.Esp32.Configuration.SetPinFunction(21, nanoFramework.Hardware.Esp32.DeviceFunction.COM2_RX);
    ```

* Only COM1 and COM2 are supported. Note that by default COM1 is used for debug. Except if you've build your own version, you may not necessarily use it are a normal UART. But you can definitely use it to wake up your board. In that case, the pins are the default ones and the previous step is not necessary.
* In order to wake up the board, you need to set a threshold on how many changes in the RX pin (the reception pin of the UART) is necessary. According to [the documentation](https://docs.espressif.com/projects/esp-idf/en/latest/esp32/api-reference/system/sleep_modes.html#uart-wakeup-light-sleep-only), you will lose few characters. So the sender should take this into consideration in the protocol.

Usage is straight forward:

```csharp
EnableWakeupByUart(WakeUpPort.COM2, 5);
StartLightSleep();
```

## Pulse Counter

Pulse counter allows to count pulses without having to setup a GPIO controller and events. It's a fast way to get count during a specific amount of time. This pulse counter allows as well to use 2 different pins and get a pulse count depending on their respective polarities.

### Pulse Counter with 1 pin

The following code illustrate how to setup a counter for 1 pin:

```csharp
Gpio​PulseCounter counter = new Gpio​PulseCounter(26);
counter.Polarity = GpioPulsePolarity.Rising;
counter.FilterPulses = 0;

counter.Start();
int inc = 0;
GpioPulseCount counterCount;
while (inc++ < 100)
{
    counterCount = counter.Read();
    Console.WriteLine($"{counterCount.RelativeTime}: {counterCount.Count}");
    Thread.Sleep(1000);
}

counter.Stop();
counter.Dispose();
```

The counter will always be positive and incremental. You can reset to 0 the count by calling the `Reset` function:

```csharp
GpioPulseCount pulses = counter.Reset();
// pulses.Count contains the actual count, it is then put to 0 once the function is called
```

## Pulse Counter with 2 pins

This is typically a rotary encoder scenario. In this case, you need 2 pins and they'll act like in this graphic:**

![rotary encoder principal](https://github.com/nanoframework/nanoFramework.IoT.Device/blob/develop/devices/RotaryEncoder/encoder.png?raw=true)

You can then use a rotary encoder connected to 2 pins:

![rotary encoder](https://github.com/nanoframework/nanoFramework.IoT.Device/blob/develop/devices/RotaryEncoder/RotaryEncoder.Sample_bb.png?raw=true)

The associated code is the same as for 1 pin except in the constructor:

```csharp
Gpio​PulseCounter encoder = new Gpio​PulseCounter(12, 14);
encoder.Start();
int incEncod = 0;
GpioPulseCount counterCountEncode;
while (incEncod++ < 100)
{
    counterCountEncode = encoder.Read();
    Console.WriteLine($"{counterCountEncode.RelativeTime}: {counterCountEncode.Count}");
    Thread.Sleep(1000);
}

encoder.Stop();
encoder.Dispose();
```

As a result, you'll get positives and negative pulses 

## Feedback and documentation

For documentation, providing feedback, issues and finding out how to contribute please refer to the [Home repo](https://github.com/nanoframework/Home).

Join our Discord community [here](https://discord.gg/gCyBu8T).

## Credits

The list of contributors to this project can be found at [CONTRIBUTORS](https://github.com/nanoframework/Home/blob/main/CONTRIBUTORS.md).

## License

The **nanoFramework** Class Libraries are licensed under the [MIT license](LICENSE.md).

## Code of Conduct

This project has adopted the code of conduct defined by the Contributor Covenant to clarify expected behaviour in our community.
For more information see the [.NET Foundation Code of Conduct](https://dotnetfoundation.org/code-of-conduct).

### .NET Foundation

This project is supported by the [.NET Foundation](https://dotnetfoundation.org).
