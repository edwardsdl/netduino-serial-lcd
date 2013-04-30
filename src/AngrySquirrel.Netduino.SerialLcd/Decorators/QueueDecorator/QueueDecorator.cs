using System.Collections;
using System.Threading;

namespace AngrySquirrel.Netduino.SerialLcd.Decorators.QueueDecorator
{
    /// <summary>
    /// Represents an LCD whose messages are displayed for a short duration before being replaced with the next message
    /// </summary>
    public class QueueDecorator : SerialLcdDecorator
    {
        #region Fields

        private readonly int messageDisplayDurationInSeconds;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueDecorator"/> class
        /// </summary>
        /// <param name="serialLcd">
        /// A serial LCD to which queuing will be added
        /// </param>
        /// <param name="messageDisplayDurationInSeconds">
        /// The amount of time in seconds a message should be displayed before being replaced with the next message
        /// </param>
        public QueueDecorator(ISerialLcd serialLcd, int messageDisplayDurationInSeconds = 5)
            : base(serialLcd)
        {
            this.messageDisplayDurationInSeconds = messageDisplayDurationInSeconds;

            WriteQueue = new Queue();

            DoWriteQueueProcessing();
        }

        #endregion

        #region Properties

        private Queue WriteQueue { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Writes a message to the display
        /// </summary>
        /// <param name="message">
        /// The message to display
        /// </param>
        public override void Write(string message)
        {
            WriteQueue.Enqueue((WriteDelegate)(() => DecoratedSerialLcd.Write(message)));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Starts the thread with handles processing of the write queue
        /// </summary>
        private void DoWriteQueueProcessing()
        {
            new Thread(() =>
                {
                    while (true)
                    {
                        if (WriteQueue.Count > 0)
                        {
                            var writeCommand = WriteQueue.Dequeue() as WriteDelegate;
                            if (writeCommand != null)
                            {
                                writeCommand();
                            }
                        }

                        Thread.Sleep(messageDisplayDurationInSeconds * 1000);
                    }
                }).Start();
        }

        #endregion
    }
}