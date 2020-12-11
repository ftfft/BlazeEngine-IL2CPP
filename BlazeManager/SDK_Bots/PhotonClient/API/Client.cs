using System;
using System.IO;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using PhotonClient.API.Response;
using PhotonClient.API.Endpoint;

namespace PhotonClient.API
{
    public class Client
	{
		public Auth Auth { get; set; }

		// public Users Users { get; set; }

		private string szMac = null;
		public string Mac
		{
			get
			{

				if (string.IsNullOrEmpty(szMac))
				{
					string src = Path.Combine(Environment.CurrentDirectory, "BlazeEngine");
					src += "\\spoof-id-photonBot.json";
					if (File.Exists(src))
					{
						szMac = File.ReadAllText(src);
					}
					if (string.IsNullOrWhiteSpace(szMac))
					{
						szMac = Addons.Patch.patch_Spoofer.CalculateHash<SHA1>(Guid.NewGuid().ToString());
						File.WriteAllText(src, szMac, Encoding.UTF8);
					}
				}
				return szMac;
			}
		}
		public Client(string username, string password)
		{
			Auth = new Auth(username, password);
			if (Variables.HttpClient == null)
			{
				// Variables.CookieContainer = new CookieContainer();
				Variables.HttpClient = new HttpClient.HttpClient(Variables.baseAddress);
			}
			if (string.IsNullOrEmpty(Config.API_KEY))
				return;

			goto IL_START;
			IL_START:
			Variables.HttpClient.ClearHeader();
			if (!string.IsNullOrEmpty(Variables.AuthCookie))
				Variables.HttpClient.AddHeader_Cookie($"auth=" + Variables.AuthCookie);
			else
				Variables.HttpClient.AddHeader("authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));
			Variables.HttpClient.AddHeader("X-MacAddress", Mac);
			Variables.HttpClient.AddHeader("X-Client-Version", "VRCApplication");
			Variables.HttpClient.AddHeader("Origin", "vrchat.com");
			Variables.HttpClient.AddHeader("X-Platform", "standalonewindows");
			var result = Auth.Login();
			if (result == null && !string.IsNullOrEmpty(Variables.AuthCookie))
            {
				Variables.AuthCookie = "";
				goto IL_START;
			}
			Variables.user = result;
			Console.WriteLine("Set AuthCookie as " + Variables.AuthCookie);
			Console.WriteLine("Set UserId as " + Variables.user.id);
		}
	}
}
