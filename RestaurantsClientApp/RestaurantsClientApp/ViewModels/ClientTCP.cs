﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantsClientApp.ViewModels
{

    public class ClientTCP
    {
        private const int port = 8888;
        private const string server = "127.0.0.1";

        public ClientTCP()
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(server, port);

                byte[] data = new byte[256];
                StringBuilder response = new StringBuilder();
                NetworkStream stream = client.GetStream();

                do
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    response.Append(Encoding.UTF8.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable); // пока данные есть в потоке

                Console.WriteLine(response.ToString());

                // Закрываем потоки
                stream.Close();
                client.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }

            Console.WriteLine("Запрос завершен...");
            Console.Read();
        }
    }
}

       









