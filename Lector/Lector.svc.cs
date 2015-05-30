using System.IO.Ports;
using System.Linq;

namespace Lector
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Lector : ILector
    {

        public string GetData()
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

    }
}
