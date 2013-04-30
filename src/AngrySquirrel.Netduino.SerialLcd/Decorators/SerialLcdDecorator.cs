namespace AngrySquirrel.Netduino.SerialLcd.Decorators
{
    /// <summary>
    /// Represents a decorator for a Serial LCD implementation
    /// </summary>
    public abstract class SerialLcdDecorator : ISerialLcd
    {
        #region Fields

        /// <summary>
        /// </summary>
        protected readonly ISerialLcd DecoratedSerialLcd;

        #endregion

        #region Constructors and Destructors

        internal SerialLcdDecorator(ISerialLcd serialLcd)
        {
            DecoratedSerialLcd = serialLcd;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Clears this display
        /// </summary>
        public virtual void Clear()
        {
            DecoratedSerialLcd.Clear();
        }

        /// <summary>
        /// Resets the display to default settings
        /// </summary>
        /// <remarks>
        /// This method must be called while the device is displaying the splash screen. After this method is called the device will need to be power cycled.
        /// </remarks>
        public virtual void Reset()
        {
            DecoratedSerialLcd.Reset();
        }

        /// <summary>
        /// Scrolls the display left
        /// </summary>
        public virtual void ScrollLeft()
        {
            DecoratedSerialLcd.ScrollLeft();
        }

        /// <summary>
        /// Scrolls the display right
        /// </summary>
        public virtual void ScrollRight()
        {
            DecoratedSerialLcd.ScrollRight();
        }

        /// <summary>
        /// Sets the current message as the LCD's splash screen
        /// </summary>
        public virtual void SetAsSplashScreen()
        {
            DecoratedSerialLcd.SetAsSplashScreen();
        }

        /// <summary>
        /// Sets the backlight brightness to the given percentage
        /// </summary>
        /// <param name="percentage">
        /// A percentage of maximum brightness to set the backlight
        /// </param>
        public virtual void SetBacklightBrightness(int percentage)
        {
            DecoratedSerialLcd.SetBacklightBrightness(percentage);
        }

        /// <summary>
        /// Sets the backlight brightness to the given level
        /// </summary>
        /// <param name="brightness">
        /// The level to set the backlight brightness
        /// </param>
        public virtual void SetBacklightBrightness(Brightness brightness)
        {
            DecoratedSerialLcd.SetBacklightBrightness(brightness);
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
        public virtual void SetCursorPosition(Position position)
        {
            DecoratedSerialLcd.SetCursorPosition(position);
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
        public virtual void SetCursorPosition(int x, int y)
        {
            DecoratedSerialLcd.SetCursorPosition(x, y);
        }

        /// <summary>
        /// Sets the type of cursor displayed by the LCD
        /// </summary>
        /// <param name="cursorType">
        /// The type of cursor to display
        /// </param>
        public virtual void SetCursorType(CursorTypes cursorType)
        {
            DecoratedSerialLcd.SetCursorType(cursorType);
        }

        /// <summary>
        /// Writes a message to the display
        /// </summary>
        /// <param name="message">
        /// The message to display
        /// </param>
        public virtual void Write(string message)
        {
            DecoratedSerialLcd.Write(message);
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
        public virtual void Write(int x, int y, string message)
        {
            DecoratedSerialLcd.Write(x, y, message);
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
        public virtual void Write(Position position, string message)
        {
            DecoratedSerialLcd.Write(position, message);
        }

        #endregion
    }
}