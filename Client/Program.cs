using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ipend = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7171);
            Socket MainSock = new Socket(SocketType.Stream, ProtocolType.Tcp);
            MainSock.Connect(ipend);
            MainSock.Send(Encoding.UTF8.GetBytes("Сообщение!"));
            MainSock.Shutdown(SocketShutdown.Both);
            MainSock.Close();
        }
    }
}
