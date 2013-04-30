namespace AngrySquirrel.Netduino.SerialLcd
{
    /// <summary>
    /// Represents a set of instructions for controlling the LCD
    /// </summary>
    /// <remarks>
    /// These values are specified in the SerLCD v2.5 datasheet
    /// </remarks>
    public enum Commands
    {
        /// <summary>
        /// Instructs the LCD to disable the display
        /// </summary>
        DisableDisplay = 0x08, 

        /// <summary>
        /// Instructs the LCD to modify the backlight brightness
        /// </summary>
        /// <remarks>
        /// This value represents the lowest possible backlight brightness (off). In order to specify another brightness level, send this command added with a value between 0x01 and 0x1D (maximum brightness).
        /// </remarks>
        SetBacklightBrightness = 0x80, 

        /// <summary>
        /// Instructs the LCD to display the current output as the splash screen
        /// </summary>
        SetSplashScreen = 0x0A, 

        /// <summary>
        /// Instructs the LCD to toggle display of the splash screen
        /// </summary>
        ToggleSplashScreen = 0x09, 
    }
}