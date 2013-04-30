namespace AngrySquirrel.Netduino.SerialLcd
{
    /// <summary>
    /// Represents a set of cursor display types
    /// </summary>
    public enum CursorTypes
    {
        /// <summary>
        /// The cursor should not be displayed
        /// </summary>
        None, 

        /// <summary>
        /// The cursor should be displayed as a blinking underline
        /// </summary>
        Underline, 

        /// <summary>
        /// The cursor should be displayed as a blinking box
        /// </summary>
        Box
    }
}