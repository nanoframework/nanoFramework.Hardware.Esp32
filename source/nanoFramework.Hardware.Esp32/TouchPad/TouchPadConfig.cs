
namespace nanoFramework.Hardware.Esp32.TouchPad
{
	/// <summary>
	/// Configuration parameters for TouchPad interrupt based class
	/// </summary>
	public class TouchPadConfig : TouchPadBaseConfig
	{
		//the threshold to trigger interrupt when the pad is touched
		public float InterruptThresholdValue { get; set; }

		public TouchPadConfig() : base()
		{
			// Use 2 / 3 of read value as the threshold to trigger interrupt when the pad is touched.
			InterruptThresholdValue = 2 / 3;
		}
	}
}
