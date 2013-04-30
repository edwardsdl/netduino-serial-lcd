using Microsoft.SPOT;

namespace AngrySquirrel.Netduino.SerialLcd
{
    /// <summary>
    /// Represents a mock LCD whose messages are displayed in the debug console
    /// </summary>
    public class MockSerialLcd : ISerialLcd
    {
        #region Public Methods and Operators

        /// <summary>
        /// Clears this display
        /// </summary>
        public void Clear()
        {
        }

        /// <summary>
        /// Resets the display to default settings
        /// </summary>
        /// <remarks>
        /// This method must be called while the device is displaying the splash screen. After this method is called the device will need to be power cycled.
        /// </remarks>
        public void Reset()
        {
        }

        /// <summary>
        /// Scrolls the display left
        /// </summary>
        public void ScrollLeft()
        {
        }

        /// <summary>
        /// Scrolls the display right
        /// </summary>
        public void ScrollRight()
        {
        }

        /// <summary>
        /// Sets the current message as the LCD's splash screen
        /// </summary>
        public void SetAsSplashScreen()
        {
        }

        /// <summary>
        /// Sets the backlight brightness to the given percentage
        /// </summary>
        /// <param name="percentage">
        /// A percentage of maximum brightness to set the backlight
        /// </param>
        public void SetBacklightBrightness(int percentage)
        {
        }

        /// <summary>
        /// Sets the backlight brightness to the given level
        /// </summary>
        /// <param name="brightness">
        /// The level to set the backlight brightness
        /// </param>
        public void SetBacklightBrightness(Brightness brightness)
        {
        }

        /// <summary>
        /// Sets the position of the cursor
        /// </summary>
        /// <param name="position">
        /// The position where the cursor should be placed
        /// </param>
        /// <remarks>
        /// The origin (0, 0) is at the top left corner of the display
        /// </remarks>
        public void SetCursorPosition(Position position)
        {
        }

        /// <summary>
        /// Sets the position of the cursor
        /// </summary>
        /// <param name="x">
        /// The x component of the position where the cursor should be placed
        /// </param>
        /// <param name="y">
        /// The y component of the position where the cursor should be placed
        /// </param>
        /// <remarks>
        /// The origin (0, 0) is at the top left corner of the display
        /// </remarks>
        public void SetCursorPosition(int x, int y)
        {
        }

        /// <summary>
        /// Sets the type of cursor displayed by the LCD
        /// </summary>
        /// <param name="cursorType">
        /// The type of cursor to display
        /// </param>
        public void SetCursorType(CursorTypes cursorType)
        {
        }

        /// <summary>
        /// Writes a message to the display
        /// </summary>
        /// <param name="message">
        /// The message to display
        /// </param>
        public void Write(string message)
        {
            Debug.Print(message);
        }

        /// <summary>
        /// Writes a message to the display at a specific position
        /// </summary>
        /// <param name="x">
        /// The x component of the position where the message should be placed
        /// </param>
        /// <param name="y">
        /// The y component of the position where the message should be placed
        /// </param>
        /// <param name="message">
        /// The message to display
        /// </param>
        /// <remarks>
        /// The origin (0, 0) is at the top left corner of the display
        /// </remarks>
        public void Write(int x, int y, string message)
        {
            Write(message);
        }

        /// <summary>
        /// Writes a message to the display at a specific position
        /// </summary>
        /// <param name="position">
        /// The position where the message should be placed
        /// </param>
        /// <param name="message">
        /// The message to display
        /// </param>
        /// <remarks>
        /// The origin (0, 0) is at the top left corner of the display
        /// </remarks>
        public void Write(Position position, string message)
        {
            Write(message);
        }

        #endregion
    }
}