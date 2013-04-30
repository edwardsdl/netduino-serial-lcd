namespace AngrySquirrel.Netduino.SerialLcd
{
    /// <summary>
    /// Represents a cursor's position
    /// </summary>
    public class Position
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Position" /> class
        /// </summary>
        public Position()
            : this(0, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class
        /// </summary>
        /// <param name="x">
        /// The x component of the position
        /// </param>
        /// <param name="y">
        /// The y component of the position
        /// </param>
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the x component of the position
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Gets the y component of the position
        /// </summary>
        public int Y { get; private set; }

        #endregion
    }
}