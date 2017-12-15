using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UserDatagramProtocol
{
    public class Udp
    {
        const int PORT_NUMBER = 5005;
        Thread t = null;

        public void Start()
        {
            if (t != null)
            {
                throw new Exception("Already listening... stop first");
            }
            
            Console.WriteLine("Started listening...");
            
            StartListening();
        }

        public void Stop()
        {
            try
            {
                udp.Close();
                Console.WriteLine("Stopped listening...");
            }
            catch { /* don't care */ }
        }

        private readonly UdpClient udp = new UdpClient(PORT_NUMBER);
        IAsyncResult ar_ = null;

        private void StartListening()
        {
            ar_ = udp.BeginReceive(Receive, new object());
        }

        private void Receive(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, PORT_NUMBER);
            byte[] bytes = udp.EndReceive(ar, ref ip);
            string message = Encoding.ASCII.GetString(bytes);
            Console.WriteLine("From {0} received: {1} ", ip.Address.ToString(), message);
            StartListening();
        }
        
        public void Send(string message)
        {
            UdpClient client = new UdpClient();
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), PORT_NUMBER);
            byte[] bytes = Encoding.ASCII.GetBytes(message);
            client.Send(bytes, bytes.Length, ip);
            client.Close();
            Console.WriteLine("Sent: {0} ", message);
        }
    }
}
