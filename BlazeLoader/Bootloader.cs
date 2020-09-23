using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using BlazeSDK;

public class Bootloader
{
    public static void Init()
    {
        Bootloader bootloader = new Bootloader();

        string fileSrc = Environment.CurrentDirectory + "\\BlazeEngine\\QHash.key";
        if (File.Exists(fileSrc))
            File.ReadAllText(fileSrc).ToCharArray().ToList().ForEach(x => {
                string y = ((int)x).ToString();
                while(y.Length < 4)
                    y = "0" + y;

                bootloader.PrivateKey += y;
            });

        bootloader.connect();
    }
    
    public void connect()
    {
        byte[] obj;
        obj = (byte[])IL2URL_Reader("/connect?hash=INBUS-2048");
        obj = (byte[])IL2URL_Reader("/client?x=iDiosafjIUAJUIFFIJEOJio");
        Main.LoadModule(obj, "BlazeManager", "Start");
    }

    public object IL2URL_Reader(string uri, string file = null)
    {
        object result = default;
        Uri newURI = new Uri(httpRequestBase, uri);

        ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(MyRemoteCertificateValidationCallback);
        using (WebClient webClient = new WebClient())
        {
            webClient.Headers.Add(HttpRequestHeader.UserAgent, "BlazeLoader");
            webClient.Headers.Add("OS", Environment.OSVersion.Platform.ToString());
            webClient.Headers.Add("Version", Environment.OSVersion.Version.Major.ToString());
            webClient.Headers.Add("username", username);
            webClient.Headers.Add("PrivateKey", PrivateKey);

            if (string.IsNullOrEmpty(file))
            {
                try
                {
                    result = webClient.DownloadData(newURI);
                }
                catch
                {
                    result = "{\"Error\":\"499 Closed Request\"}";
                }
            }
            else
            {
                try
                {
                    webClient.DownloadFile(newURI, file);
                    result = "{\"Success\":\"200 File load\"}";
                }
                catch
                {
                    result = "{\"Error\":\"499 Closed Request\"}";
                }
            }
        }
        return result;
    }

    static bool MyRemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        if (sslPolicyErrors > SslPolicyErrors.None)
        {
            for (int i = 0; i < chain.ChainStatus.Length; i++)
            {
                if (chain.ChainStatus[i].Status == X509ChainStatusFlags.RevocationStatusUnknown)
                    continue;

                chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                if (!chain.Build((X509Certificate2)certificate))
                    return false;
            }
        }
        return true;
    }

    private static Uri httpRequestBase = new Uri("http://icefrag.ru");

    internal string url = Path.GetTempPath();

    internal string username = "";
    internal string PrivateKey = "";
}