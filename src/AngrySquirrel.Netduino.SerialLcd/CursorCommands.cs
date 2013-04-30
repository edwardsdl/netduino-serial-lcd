namespace AngrySquirrel.Netduino.SerialLcd
{
    /// <summary>
    /// Represents a set of instructions for controlling the LCDs cursor
    /// </summary>
    /// <remarks>
    /// These values are specified in the SerLCD v2.5 datasheet
    /// </remarks>
    public enum CursorCommands
    {
        /// <summary>
        /// Instructs the LCD to clear the display
        /// </summary>
        ClearDisplay = 0x01, 

        /// <summary>
        /// Instructs the LCD to disable the cursor
        /// </summary>
        DisableCursor = 0x0C, 

        /// <summary>
        /// Instructs the LCD to enable the blinking box cursor type
        /// </summary>
        EnableBlinkingBoxCursor = 0x0D, 

        /// <summary>
        /// Instructs the LCD to enable the underline cursor type
        /// </summary>
        EnableUnderlineCursor = 0x0E, 

        /// <summary>
        /// Instructs the LCD to move the cursor right one position
        /// </summary>
        MoveCursorLeft = 0x10, 

        /// <summary>
        /// Instructs the LCD to move the cursor left one position
        /// </summary>
        MoveCursorRight = 0x14, 

        /// <summary>
        /// Instructs the LCD to scroll left
        /// </summary>
        ScrollLeft = 0x18, 

        /// <summary>
        /// Instructs the LCD to move the cursor right one position
        /// </summary>
        ScrollRight = 0x1C, 

        /// <summary>
        /// Instructs the LCD to set the cursor to a new position
        /// </summary>
        /// <remarks>
        /// This value represents the cursor position in the first column of the first row. In order to specify another position,
        /// send this command added to the value corresponding to the row and column to which you want to move the cursor: 
        /// 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F
        /// 0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F
        /// See the SerLCD v2.5 datasheet for more information.
        /// </remarks>
        SetCursorPosition = 0x80, 
    }
}