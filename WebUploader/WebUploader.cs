using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebUploader
{
    public static class WebUploader
    {
        public static TcpListener instance = null;

        public static void Main()
        {
            Start();
        }

        public static void Start()
        {

            string ip = "0.0.0.0";
            int port = 5000;
            instance = new TcpListener(IPAddress.Parse(ip), port);
            new Thread(() =>
            {
                instance.Start();
                Console.WriteLine("Server has started on {0}:{1}, Waiting for a connection...", ip, port);
                ConnectToServer();
            }).Start();
            while (true)
            {
                Thread.Sleep(5);
            }
        }


        public static void ConnectToServer()
        {
            TcpClient client = instance.AcceptTcpClient();
            new Thread(() => { ConnectToServer(); }).Start();
            try
            {
                Console.WriteLine(client.Client.RemoteEndPoint.ToString() + " is connected.");
                NetworkStream stream = client.GetStream();

                client.ReceiveTimeout = 0;

                while (client.Connected)
                {
                    try
                    {
                        while (!stream.DataAvailable) ;
                        while (client.Available < 3) ; // match against "get"
                    }
                    catch { continue; }
                    byte[] bytes = new byte[0];
                    try
                    {
                        bytes = new byte[client.Available];
                        stream.Read(bytes, 0, client.Available);
                    }
                    catch { continue; }
                    string s = Encoding.UTF8.GetString(bytes);

                    //
                    // GET Event & check HandShake
                    //
                    if (Regex.IsMatch(s, "^GET", RegexOptions.IgnoreCase))
                    {
                        bool isSended = false;
                        string szPublicDir = "public/";
                        string[] list = File.ReadAllLines("files.list.txt");
                        foreach (var file in list)
                        {
                            if (Regex.IsMatch(s, "^GET /" + file, RegexOptions.IgnoreCase))
                            {
                                if (File.Exists(szPublicDir + file))
                                {
                                    stream.SendMessage_File(szPublicDir + file);
                                    isSended = true;
                                    break;
                                }
                            }
                        }
                        if (!isSended)
                        {
                            stream.SendMessage_HTML("404 not found");
                        }
                    }
                }
            }
            finally
            {
                
                client.Close();
            }
        }

        internal static void SendMessage_HTML(this NetworkStream stream, string message)
        {
            try
            {
                byte[] byteMsg = Encoding.UTF8.GetBytes(message);
                string szBuffer = "HTTP/1.1 200 OK\r\n";
                szBuffer += "Connection: close\r\n";
                szBuffer += "Content-Length: " + byteMsg.Length + "\r\n";
                szBuffer += "Content-type: application/json; charset=utf-8\r\n";
                szBuffer += "Access-Control-Allow-Headers: Origin, X-Requested-With, Content-Type, Accept, Terminal-Type\r\n";
                szBuffer += "Access-Control-Allow-Origin: *\r\n";
                szBuffer += "Access-Control-Allow-Credentials: true\r\n";
                szBuffer += "\r\n" + message;

                stream.SendMessage(szBuffer);
            }
            catch { }
        }

        internal static void SendMessage_File(this NetworkStream stream, string szFile)
        {
            try
            {
                StreamWriter sw = new StreamWriter(stream);
                byte[] fileBytes = File.ReadAllBytes(szFile);
                sw.Write("HTTP/1.0 200 OK\r\n\r\n");
                sw.Flush(); //  <-- HERE
                sw.BaseStream.Write(fileBytes, 0, fileBytes.Length);
                sw.Close();
            }
            catch { Console.WriteLine("File: " + szFile + " not found!"); }
        }

        internal static void SendMessage(this NetworkStream stream, string message)
        {
            byte[] byteMsg = Encoding.UTF8.GetBytes(message);
            stream.ByteMessage(byteMsg);
        }
        internal static void ByteMessage(this NetworkStream stream, byte[] message) => stream.Write(message, 0, message.Length);
        internal static void WriteMessage(this NetworkStream stream, string message)
        {
            byte[] byteMsg = CreateFrame(message);
            stream.ByteMessage(byteMsg);
        }

        internal static byte[] CreateFrame(string message, MessageType messageType = MessageType.Text, bool messageContinues = false)
        {
            byte b1 = 0;
            byte b2 = 0;

            switch (messageType)
            {
                case MessageType.Continuos:
                    b1 = 0;
                    break;
                case MessageType.Text:
                    b1 = 1;
                    break;
                case MessageType.Binary:
                    b1 = 2;
                    break;
                case MessageType.Close:
                    b1 = 8;
                    break;
                case MessageType.Ping:
                    b1 = 9;
                    break;
                case MessageType.Pong:
                    b1 = 10;
                    break;
            }

            b1 = (byte)(b1 + 128); // set FIN bit to 1

            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            if (messageBytes.Length < 126)
            {
                b2 = (byte)messageBytes.Length;
            }
            else
            {
                if (messageBytes.Length < Math.Pow(2, 16) - 1)
                {
                    b2 = 126;

                }
                else
                {
                    b2 = 127;
                }

            }

            byte[] frame = null;

            if (b2 < 126)
            {
                frame = new byte[messageBytes.Length + 2];
                frame[0] = b1;
                frame[1] = b2;
                Array.Copy(messageBytes, 0, frame, 2, messageBytes.Length);
            }
            if (b2 == 126)
            {
                frame = new byte[messageBytes.Length + 4];
                frame[0] = b1;
                frame[1] = b2;
                byte[] lenght = BitConverter.GetBytes(messageBytes.Length);
                frame[2] = lenght[1];
                frame[3] = lenght[0];
                Array.Copy(messageBytes, 0, frame, 4, messageBytes.Length);
            }

            if (b2 == 127)
            {
                frame = new byte[messageBytes.Length + 10];
                frame[0] = b1;
                frame[1] = b2;
                byte[] lenght = BitConverter.GetBytes((long)messageBytes.Length);

                for (int i = 7, j = 2; i >= 0; i--, j++)
                {
                    frame[j] = lenght[i];
                }
            }

            return frame;
        }

    }
}