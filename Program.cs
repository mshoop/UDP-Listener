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
    public class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            Udp udp = new Udp();
            udp.Start();
            do
            {
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);

                    switch (cki.KeyChar)
                    {
                        case 's':
                            udp.Send(new Random().Next().ToString());
                            break;

                        case 'x':
                            udp.Stop();
                            return;
                    }
                }
                Thread.Sleep(10);
            } while (true);
        }
    }
}
