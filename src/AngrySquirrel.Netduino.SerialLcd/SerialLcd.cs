using System;
using System.Collections;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace AngrySquirrel.Netduino.SerialLcd
{
    /// <summary>
    /// Represents the 16x2 Serial LCD
    /// </summary>
    public class SerialLcd : ISerialLcd
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SerialLcd"/> class
        /// </summary>
        /// <param name="serialPort">
        /// The serial port to which the LCD is attached
        /// </param>
        /// <seealso cref="DoSendQueueProcessing"/>
        public SerialLcd(SerialPort serialPort)
        {
            SerialPort = serialPort;

            SendQueue = new Queue();

            DoSendQueueProcessing();
        }

        #endregion

        #region Properties

        private Queue SendQueue { get; set; }

        private SerialPort SerialPort { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Clears this display
        /// </summary>
        public void Clear()
        {
            SendCommand(CursorCommands.ClearDisplay);
        }

        /// <summary>
        /// Resets the display to default settings
        /// </summary>
        /// <remarks>
        /// This method must be called while the device is displaying the splash screen. After this method is called the device will need to be power cycled.
        /// </remarks>
        public void Reset()
        {
            SerialPort.WriteByte(0x12);
        }

        /// <summary>
        /// Scrolls the display left
        /// </summary>
        public void ScrollLeft()
        {
            SendCommand(CursorCommands.ScrollLeft);
        }

        /// <summary>
        /// Scrolls the display right
        /// </summary>
        public void ScrollRight()
        {
            SendCommand(CursorCommands.ScrollRight);
        }

        /// <summary>
        /// Sets the current message as the LCD's splash screen
        /// </summary>
        public void SetAsSplashScreen()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the backlight brightness to the given percentage
        /// </summary>
        /// <param name="percentage">
        /// A percentage of maximum brightness to set the backlight
        /// </param>
        public void SetBacklightBrightness(int percentage)
        {
            if (percentage > 100)
            {
                throw new ArgumentException("The percentage must not exceed 100%.");
            }

            if (percentage < 0)
            {
                throw new ArgumentException("The percentage must not be less than 0%.");
            }

            // The brightness value must be converted to a value between 0 and 29 before
            // being sent to the LCD.
            var convertedBrightnessValue = Math.Ceiling(29.0 * percentage / 100.0);

            SendCommand(Commands.SetBacklightBrightness, (byte)convertedBrightnessValue);
        }

        /// <summary>
        /// Sets the backlight brightness to the given level
        /// </summary>
        /// <param name="brightness">
        /// The level to set the backlight brightness
        /// </param>
        public void SetBacklightBrightness(Brightness brightness)
        {
            SendCommand(Commands.SetBacklightBrightness, (byte)brightness);
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
            SetCursorPosition(position.X, position.Y);
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
            if (x < 0)
            {
                throw new ArgumentException("The x component of the position must not be less than 0.");
            }

            // The y component will need to include an offset for any row other
            // than the first. This adds the appropriate offset. For more information
            // see the SerLCD v2.5 datasheet.
            switch (y)
            {
                case 0:
                    y = 0x0;
                    break;
                case 1:
                    y = 0x40;
                    break;
                case 2:
                    y = 0x10;
                    break;
                case 3:
                    y = 0x30;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("y");
            }

            SendCommand(CursorCommands.SetCursorPosition, y + x);
        }

        /// <summary>
        /// Sets the type of cursor displayed by the LCD
        /// </summary>
        /// <param name="cursorType">
        /// The type of cursor to display
        /// </param>
        public void SetCursorType(CursorTypes cursorType)
        {
            switch (cursorType)
            {
                case CursorTypes.None:
                    SendCommand(CursorCommands.DisableCursor);
                    break;
                case CursorTypes.Underline:
                    SendCommand(CursorCommands.EnableUnderlineCursor);
                    break;
                case CursorTypes.Box:
                    SendCommand(CursorCommands.EnableBlinkingBoxCursor);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("cursorType");
            }
        }

        /// <summary>
        /// Writes a message to the display
        /// </summary>
        /// <param name="message">
        /// The message to display
        /// </param>
        public virtual void Write(string message)
        {
            var buffer = Encoding.UTF8.GetBytes(message);

            Send(buffer);
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
            SetCursorPosition(x, y);

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
        public virtual void Write(Position position, string message)
        {
            Write(position.X, position.Y, message);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Starts the thread with handles processing of the send queue
        /// </summary>
        /// <remarks>
        /// The LCD will freeze if information is sent too quickly. In order to deal with this send requests are placed into a queue and executed in short intervals. The queue processing is handled on a separate thread so that the Netduino isn't frozen between send executions.
        /// </remarks>
        private void DoSendQueueProcessing()
        {
            new Thread(
                () =>
                    {
                        while (true)
                        {
                            if (SendQueue.Count > 0)
                            {
                                var sendCommand = SendQueue.Dequeue() as SendDelegate;
                                if (sendCommand != null)
                                {
                                    sendCommand();
                                }
                            }

                            Thread.Sleep(10);
                        }
                    }).Start();
        }

        /// <summary>
        /// Sends data the display
        /// </summary>
        /// <param name="buffer">
        /// A buffer containing information to send to the display
        /// </param>
        /// <see cref="DoSendQueueProcessing"/>
        private void Send(byte[] buffer)
        {
            SendQueue.Enqueue((SendDelegate)(() => SerialPort.Write(buffer, 0, buffer.Length)));
        }

        /// <summary>
        /// Sends a command to the display which will modify the cursor in some way
        /// </summary>
        /// <param name="command">
        /// The command to send to the display
        /// </param>
        /// <param name="modifier">
        /// An modifier which provides additional information about the command
        /// </param>
        private void SendCommand(CursorCommands command, int modifier = 0x0)
        {
            Send(new byte[] {0xFE, (byte)(command + modifier)});
        }

        /// <summary>
        /// Sends a command to the display with the given argument
        /// </summary>
        /// <param name="command">
        /// The command to send to the display
        /// </param>
        /// <param name="modifier">
        /// An modifier which provides additional information about the command
        /// </param>
        private void SendCommand(Commands command, int modifier = 0x0)
        {
            Send(new byte[] {0x7C, (byte)(command + modifier)});
        }

        #endregion
    }
}