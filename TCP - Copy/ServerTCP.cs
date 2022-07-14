using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsClientApp.ViewModels
{

    public class ServerTCP
    {
        const int port = 8888; // port to listen for connections
        public string MyIp;


    public  ServerTCP()
        {
            TcpListener server = null;
            //Get current ip - address Xamarin.Forms(Cross Platform)

            var IpAddress = Dns.GetHostAddresses(Dns.GetHostName());

            if (IpAddress != null)
            {
                IpAddress.ToString();
            }

            try
            {
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);
                // start the listener
                server.Start();

                while (true)
                {
                    Console.WriteLine("Waiting for connections... ");

                    // get an incoming connection
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Client connected. Executing request...");

                    // get a network stream for reading and writing
                    NetworkStream stream = client.GetStream();

                    // message to send to the client
                    string response = "Hello World";
                    // convert message to byte array
                    byte[] data = Encoding.UTF8.GetBytes(response);
                    // send message
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Message sent: {0}", response);
                    // close the stream
                    stream.Close();
                    // close the connection
                    client.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (server != null)
                    server.Stop();
            }
        }
    }


}

       









