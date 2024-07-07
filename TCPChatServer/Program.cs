using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace TCPChatServer
{
    internal class Program
    {
        //---port number to use for listening---
        const int portNo = 500;

        static void Main(string[] args)
        {
            System.Net.IPAddress localAdd =
                System.Net.IPAddress.Parse("127.0.0.1");

            //---listen at the local address---
            TcpListener listener =
                new TcpListener(localAdd, portNo);
            listener.Start();

            //---Accepts a pending connection request---
            TcpClient tcpClient = listener.AcceptTcpClient();

            //---use a Network Stream object to send and receive data---
            NetworkStream ns = tcpClient.GetStream();
            byte[] data = new byte[tcpClient.ReceiveBufferSize];

            //---read incoming stream; Read() is a blocking call---
            int numBytesRead = ns.Read(data, 0,
                System.Convert.ToInt32(tcpClient.ReceiveBufferSize));

            //---display data received---
            Console.WriteLine(
                "Received :" + Encoding.ASCII.GetString(data, 0, numBytesRead));

            //---prevent window from closing right away---
            Console.ReadLine();
        }
    }
}
