namespace AngrySquirrel.Netduino.SerialLcd
{
    /// <summary>
    /// Represents a predefined set of backlight brightness levels
    /// </summary>
    public enum Brightness
    {
        /// <summary>
        /// The backlight is off
        /// </summary>
        Off = 0x00, 

        /// <summary>
        /// A low level of brightness
        /// </summary>
        Low = 0x0C, 

        /// <summary>
        /// A medium level of brightness
        /// </summary>
        Medium = 0x16, 

        /// <summary>
        /// A high level of brightness
        /// </summary>
        High = 0x1D
    }
}