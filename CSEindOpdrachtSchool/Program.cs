using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CSEindOpdrachtSchool
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter your Username.");
            string userName = Console.ReadLine();

            Console.WriteLine("Username is: " + userName);


            Console.ReadKey();


            Console.WriteLine("Please enter a server IP.");
            string DynamicIP = Console.ReadLine();

            ExecuteClient();
            Console.ReadKey();

            Console.WriteLine("Welcome to Laurens Console.");
            Console.WriteLine("Press any key to start the program.");
            Console.ReadKey();

            Console.Clear();

            


        }

        static void ExecuteClient()
        {

            try
            {

                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);

                Socket sender = new Socket(ipAddr.AddressFamily,
                           SocketType.Stream, ProtocolType.Tcp);

                try
                {

                    sender.Connect(localEndPoint);

                    Console.WriteLine("Socket connected to -> {0} ",
                                  sender.RemoteEndPoint.ToString());

                    byte[] messageSent = Encoding.ASCII.GetBytes("Test Client<EOF>");
                    int byteSent = sender.Send(messageSent);

                    byte[] messageReceived = new byte[1024];

                    int byteRecv = sender.Receive(messageReceived);
                    Console.WriteLine("Message from Server -> {0}",
                          Encoding.ASCII.GetString(messageReceived,
                                                     0, byteRecv));

                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }

                catch (ArgumentNullException ane)
                {

                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }

                catch (SocketException se)
                {

                    Console.WriteLine("SocketException : {0}", se.ToString());
                }

                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }

            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
        }
    }
}
