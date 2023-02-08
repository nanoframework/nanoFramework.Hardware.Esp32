using nanoFramework.Hardware.Esp32.Touch;
using System;
using System.Diagnostics;
using System.Threading;

namespace TestTouchApp
{
    public class Program
    {
        public static void Main()
        {
            const int TouchPadNumber = 0;
            Debug.WriteLine("Hello touch pad on ESP32!");

            // On a normal ESP32, Touch Pad 0 is GPIO4
            var pinNum = TouchPad.GetGpioNumberFromTouchNumber(TouchPadNumber);
            Console.WriteLine($"Pad 0 is GPIO{pinNum}");

            TouchPad touchpad = new(TouchPadNumber);
            Debug.WriteLine("Initialized!");

            //// Changing voltage
            //Console.WriteLine($"Initial Voltage: {touchpad.TouchHighVoltage} {touchpad.TouchLowVoltage} {touchpad.TouchHighVoltageAttenuation}");
            //Console.WriteLine($"Setting Voltage: {TouchHighVoltage.Volt2V7} {TouchLowVoltage.Volt0V6} {TouchHighVoltageAttenuation.Volt1V0}");
            //TouchPad.SetVoltage(TouchHighVoltage.Volt2V7, TouchLowVoltage.Volt0V6, TouchHighVoltageAttenuation.Volt1V0);
            //Console.WriteLine($"New set Voltage: {touchpad.TouchHighVoltage} {touchpad.TouchLowVoltage} {touchpad.TouchHighVoltageAttenuation}");

            //// Changing threashold
            //Console.WriteLine($"Initial Threshold: {touchpad.Threshold}");
            //Console.WriteLine("Setting new Threshold: 42");
            //touchpad.Threshold = 42;
            //Console.WriteLine($"New Threshold is: {touchpad.Threshold}");
            //Console.WriteLine("Setting new Threshold: 0");
            //touchpad.Threshold = 0;
            //Console.WriteLine($"New Threshold is: {touchpad.Threshold}");

            //// static trigger mode
            //Console.WriteLine($"Initial trigger mode: {TouchPad.TouchTriggerMode}");
            //TouchPad.TouchTriggerMode = TouchTriggerMode.AboveThreshold;
            //Console.WriteLine($"New trigger mode: {TouchPad.TouchTriggerMode}");
            //Console.WriteLine($"Setting new triggermode: {TouchTriggerMode.BellowThreshold}");
            //TouchPad.TouchTriggerMode = TouchTriggerMode.BellowThreshold;
            //Console.WriteLine($"New trigger mode: {TouchPad.TouchTriggerMode}");

            //// Static wakeup source
            //Console.WriteLine($"Initial wakeup source: {TouchPad.WakeUpSource}");
            //TouchPad.WakeUpSource = WakeUpSource.OnlySet1;
            //Console.WriteLine($"New wakeup source: {TouchPad.WakeUpSource}");
            //Console.WriteLine($"Setting new wakeup source: {WakeUpSource.BothSet1AndSet2}");
            //TouchPad.WakeUpSource = WakeUpSource.BothSet1AndSet2;
            //Console.WriteLine($"New wakeup source: {TouchPad.WakeUpSource}");

            //// Charge speed
            //var chargeSpeed = touchpad.GetChargeSpeed();
            //Console.WriteLine($"Initial speed: {chargeSpeed.Speed} charge {chargeSpeed.Charge}");
            //chargeSpeed.Speed = TouchChargeSpeed.ChargeSpeed.Speed3;
            //chargeSpeed.Charge = TouchChargeSpeed.InitialCharge.High;
            //Console.WriteLine($"Set speed: {chargeSpeed.Speed} charge {chargeSpeed.Charge}");
            //touchpad.SetChargeSpeed(chargeSpeed);
            //chargeSpeed = touchpad.GetChargeSpeed();
            //Console.WriteLine($"New speed: {chargeSpeed.Speed} charge {chargeSpeed.Charge}");
            //chargeSpeed.Speed = TouchChargeSpeed.ChargeSpeed.Speed4;
            //chargeSpeed.Charge = TouchChargeSpeed.InitialCharge.Low;
            //touchpad.SetChargeSpeed(chargeSpeed);

            var meas = TouchPad.GetMeasurementTime();
            Console.WriteLine($"Cycles speed: {meas.SleepCycles} meas {meas.MeasurementCycles.TotalMilliseconds} ms");

            // Get the calibraiton data
            TouchPad.MeasurementMode = MeasurementMode.Software;
            var calib = touchpad.GetCalibrationData();
            Console.WriteLine($"calib: {calib} vs Calibration {touchpad.CalibrationData}");

            Console.WriteLine("Testing timer mode for 20 seconds");
            TouchPad.MeasurementMode = MeasurementMode.Timer;
            TouchPad.SetVoltage(TouchHighVoltage.Volt2V7, TouchLowVoltage.Volt0V5, TouchHighVoltageAttenuation.Volt1V0);
            touchpad.Threshold = (ushort)(touchpad.CalibrationData * 2 / 3);
            //TouchPad.StartFilter(TimeSpan.FromMilliseconds(10));
            touchpad.ValueChanged += TouchpadValueChanged;
            Thread.Sleep(20_000);

            Console.WriteLine("Testing manual mode");
            TouchPad.MeasurementMode = MeasurementMode.Software;
            while (true)
            {
                var val = touchpad.Read();
                Console.WriteLine($"Val: {val}");
                Thread.Sleep(1000);
            }

            Thread.Sleep(Timeout.Infinite);
        }

        private static void TouchpadValueChanged(object sender, TouchPadEventArgs e)
        {
            Console.WriteLine($"Touchpad {e.PadNumber} is {(e.Touched ? "touched" : "not touched")}");
        }
    }
}
