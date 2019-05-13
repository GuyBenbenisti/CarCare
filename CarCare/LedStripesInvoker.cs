using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventuz.OSC;

namespace CarCare
{
    internal class LedStripesInvoker
    {
        UdpWriter udpWriter;

        internal LedStripesInvoker(string ipAddress, int port)
        {
            udpWriter = new Ventuz.OSC.UdpWriter(ipAddress, port);            
        }

        internal void SendSignalLeftToRight()
        {
            udpWriter.Send(new OscElement("/left"));
        }

        internal void SendSignalRightToLeft()
        {
            udpWriter.Send(new OscElement("/right"));
        }

        internal void StopSignal()
        {
            udpWriter.Send(new OscElement("/stop", 0));
        }
    }
}
