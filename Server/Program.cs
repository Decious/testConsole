using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static void Main(string[] args)
        {
            //TODO: Check for Exceptions
            string ip = "127.0.0.1";
            int port = 7171;
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("\n[1]Start TCP\n[2]Settings\n[3]Exit");
                var choic = int.Parse(Console.ReadLine());
                switch (choic)
                {
                    case 1:
                        repeat = false;
                        break;
                    case 2:
                        Console.WriteLine("\n[1]IP\n[2]PORT\n[3]Cancel");
                        var choice2 = int.Parse(Console.ReadLine());
                        switch (choice2)
                        {
                            case 1:
                                Regex ipReg = new Regex("^(?:[0-9]{1,3}\\.){3}[0-9]{1,3}$");
                                Console.WriteLine("\nIP-Address: ");
                                ip = Console.ReadLine();
                                while (!ipReg.IsMatch(ip))
                                {
                                    Console.WriteLine("Incorrect Ip-address!");
                                    ip = Console.ReadLine();
                                }
                                Console.WriteLine($"Server is set to {ip}");
                                break;
                            case 2:
                                Regex portReg = new Regex("^([0-9]{1,4}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-5])$");
                                Console.WriteLine("\nPort: ");
                                port = int.Parse(Console.ReadLine());
                                while (!portReg.IsMatch(port.ToString()))
                                {
                                    Console.WriteLine("Incorrect port!");
                                    port = int.Parse(Console.ReadLine());
                                }
                                Console.WriteLine($"Server will be listening to {port}");
                                break;
                            case 3:
                            default:
                                break;
                        }
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Nope. Try again!");
                        break;
                }
            }
            Console.WriteLine($"Attempting to create a server on {ip}:{port}");
            IPEndPoint IPend = new IPEndPoint(IPAddress.Parse(ip), port);
            sock.Bind(IPend);
            sock.Listen(5);
            AcceptingClientsAsync();
            Console.WriteLine($"Listening on {port}...\nTo terminate server press 0 and Enter.");
            int choice = 1;
            bool alive = true;
            while (alive)
            {
                choice = int.Parse(Console.ReadLine());
                if (choice == 0)
                {
                    sock.Shutdown(SocketShutdown.Both);
                    sock.Close();
                    alive = false;
                }
            }
            Console.WriteLine("Server closed... Press any key to continue...");
            Console.ReadLine();
        }

        static private async Task AcceptClientAsync(Socket client)
        {
                StringBuilder data = new StringBuilder();
                await Task.Run(() => {
                    do
                    {
                        byte[] buffer = new byte[256];
                        int size = client.Receive(buffer);
                        data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                    } while (client.Available > 0);
                });
                Console.WriteLine(data);
        }
        static private async Task AcceptingClientsAsync()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    Socket client = sock.Accept();
                    Console.WriteLine($"User Connected!");
                    AcceptClientAsync(client);
                }
            });
        }
    }
}
