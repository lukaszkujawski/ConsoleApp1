using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApp1Client
{
    class WysylkaTCP
    {
        TcpClient tcpClient;
        byte[] wysylaneBajty;

        public WysylkaTCP()
        {
            wysylaneBajty = new byte[50];
            tcpClient = new TcpClient();
            Console.WriteLine("Łączenie");
            try
            {
                tcpClient.Connect("127.0.0.1", 3021);
            }
            catch (Exception e)
            {
                Console.WriteLine("Nie mozna sie polaczyc... " + e.Message);
                Console.ReadKey();
                Environment.Exit(e.GetHashCode());
            }
            Console.WriteLine("Polaczono");
            WysylanieTekstu();

        }

        public void WysylanieTekstu()
        {
            String wysylanyTekst = Console.ReadLine();
            Stream stream = tcpClient.GetStream();

            ASCIIEncoding asciiEncoding = new ASCIIEncoding();
            wysylaneBajty = asciiEncoding.GetBytes(wysylanyTekst);
            Console.WriteLine("Wysylanie");
            stream.Write(wysylaneBajty, 0, wysylaneBajty.Length);

            Console.WriteLine("Wyslano");
            tcpClient.Close();
            Console.ReadKey();
        }
    }
}
