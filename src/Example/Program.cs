using System.IO.Ports;
using System.Threading;
using AngrySquirrel.Netduino.SerialLcd;
using SecretLabs.NETMF.Hardware.NetduinoPlus;

namespace Example
{
    /// <summary>
    /// Represents an example project showing how to use the <see cref="SerialLcd" /> library
    /// </summary>
    public class Program
    {
        #region Public Methods and Operators

        /// <summary>
        /// Program entry point
        /// </summary>
        public static void Main()
        {
            var serialLcdOutput = new SerialPort(SerialPorts.COM1, 9600, Parity.None, 8, StopBits.One);
            serialLcdOutput.Open();

            var serialLcd = new SerialLcd(serialLcdOutput);
            serialLcd.Clear();
            serialLcd.SetBacklightBrightness(Brightness.Medium);
            serialLcd.Write("Hello, world!");

            Thread.Sleep(Timeout.Infinite);
        }

        #endregion
    }
}