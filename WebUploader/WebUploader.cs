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
                Thread.Sleep(5000);
            }
        }

        public static void ConnectToServer()
        {
            TcpClient client = null;
            try
            {
                using (client = instance.AcceptTcpClient())
                {
                    new Thread(() => { ConnectToServer(); }).Start();
                    try
                    {
                        using (NetworkStream stream = client.GetStream())
                        {
                            while (client.Connected)
                            {
                                // Console.WriteLine(client.Client.RemoteEndPoint.ToString() + " is connected.");
                                try
                                {
                                    while (!stream.DataAvailable) ;
                                    while (client.Available < 3) ; // match against "get"
                                }
                                catch { break; }
                                byte[] bytes = new byte[0];
                                try
                                {
                                    bytes = new byte[client.Available];
                                    stream.Read(bytes, 0, client.Available);
                                }
                                catch { break; }
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
                                                stream.Send(szPublicDir + file, true);
                                                isSended = true;
                                                break;
                                            }
                                        }
                                    }
                                    if (!isSended)
                                    {
                                        stream.Send("404 not found", false);
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {

                    }
                }
            }
            finally
            {
                try
                {
                    if (client != null)
                    {
                        client.Close();
                    }
                }
                catch { }
            }
        }
    }
}