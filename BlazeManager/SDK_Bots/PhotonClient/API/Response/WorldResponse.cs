using System;
using System.Text;
using System.Collections.Generic;
using PhotonClient.API.Endpoint;

namespace PhotonClient.API.Response
{
	public class WorldResponse : ApiContainer
	{
		public static WorldResponse GetInfo(string worldId)
		{
			WorldResponse result = null;
			var world = worldId.Split(new char[] { ':' })[0];

			Variables.HttpClient.ClearHeader();
			if (!string.IsNullOrEmpty(Variables.AuthCookie))
            {
				Variables.HttpClient.AddHeader_Cookie($"auth=" + Variables.AuthCookie);
				Variables.HttpClient.AddHeader("X-MacAddress", PhotonNetwork.ApiClient.Mac);
				Variables.HttpClient.AddHeader("X-Client-Version", "VRCApplication");
				Variables.HttpClient.AddHeader("Origin", "vrchat.com");
				Variables.HttpClient.AddHeader("X-Platform", "standalonewindows");

				var response = Variables.HttpClient.Get($"worlds/{world}?apiKey=" + Config.API_KEY);
				if (response.isSuccess)
				{
					result = SerilizerJSON.Serilize_Response<WorldResponse>(response.result);
				}
				else
				{
					Console.WriteLine(string.Format("An Error occurred while logging in!\nError {0}", response.ex.Message));
				}
			}
			return result;
		}

		public string name { get; set; }

		// MaxPlayers
		public int capacity { get; set; }
	}
}
