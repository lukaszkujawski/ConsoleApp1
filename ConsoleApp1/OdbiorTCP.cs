using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApp1
{
    public class OdbiorTCP
    {
        IPAddress ipAdress;
        TcpListener tcpListener;
        private int _port;
        byte[] odebraneBajty;

        public OdbiorTCP()
        {
            _port = 3021;

            ipAdress = IPAddress.Parse("127.0.0.1");
            tcpListener = new TcpListener(ipAdress, _port);
            odebraneBajty = new byte[5];
            TurnOnServer();
        }

        public void TurnOnServer()
        {
            tcpListener.Start();
            Console.WriteLine("Serwer ruszył, oto lokalny endpoint {0}", tcpListener.LocalEndpoint);
            Socket socket = tcpListener.AcceptSocket();
            Console.WriteLine("Podlaczono z {0}", socket.RemoteEndPoint);
            int iloscOdebranychBajtow = socket.Receive(odebraneBajty);
            Console.WriteLine("Odebrano");
            for (int i = 0; i < iloscOdebranychBajtow; i++)
                Console.Write(Convert.ToChar(odebraneBajty[i]));

            Console.WriteLine("\nOdebrano dane");

            socket.Close();
            tcpListener.Stop();
            Console.ReadKey();
        }
    }
}
