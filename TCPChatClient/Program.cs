using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace TCPChatClient
{
    internal class Program
    {
        const int portNo = 500;

        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient();

            //---connect to the server---
            tcpClient.Connect("127.0.0.1", portNo);

            //---use a NetworkStream object to send and receive data---
            NetworkStream ns = tcpClient.GetStream();
            byte[] data = Encoding.ASCII.GetBytes("Hello");

            //---send the text---
            ns.Write(data, 0, data.Length);
        }
    }
}
