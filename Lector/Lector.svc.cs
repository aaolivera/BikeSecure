using System.IO.Ports;
using System.Linq;

namespace Lector
{
    public class Lector : ILector
    {
        public string GetData()
        {
            try
            {
                var buffer = new byte[100];
                var port = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                if (port.IsOpen)
                {
                    port.Close();
                }
                port.Open();
                var recv = 0;
                while (recv != 30)
                {
                    recv += port.Read(buffer, recv, 30);
                }
                port.Close();
                var bufferRecortado = buffer.SkipWhile(x => x == 0x02).TakeWhile(x => x != 0x03).ToArray();
                return System.Text.Encoding.Default.GetString(bufferRecortado);
            }
            catch
            {
                return "-1";
            }
        }

    }
}
