using System;
using System.Text;
using System.Collections.Generic;
using PhotonClient.API.Endpoint;

namespace PhotonClient.API.Response
{
	public class ApiJoinResponse : ApiContainer
	{
		public static ApiJoinResponse GetInfo(string roomId)
		{
			ApiJoinResponse result = null;

			Variables.HttpClient.ClearHeader();
			if (!string.IsNullOrEmpty(Variables.AuthCookie))
			{
				Variables.HttpClient.AddHeader_Cookie($"auth=" + Variables.AuthCookie);
				Variables.HttpClient.AddHeader("X-MacAddress", PhotonNetwork.ApiClient.Mac);
				Variables.HttpClient.AddHeader("X-Client-Version", "VRCApplication");
				Variables.HttpClient.AddHeader("Origin", "vrchat.com");
				Variables.HttpClient.AddHeader("X-Platform", "standalonewindows");

				var response = Variables.HttpClient.Get($"instances/{roomId}/join?apiKey=" + Config.API_KEY);
				if (response.isSuccess)
				{
					result = SerilizerJSON.Serilize_Response<ApiJoinResponse>(response.result);
				}
				else
				{
					Console.WriteLine(string.Format("An Error occurred while join in!\nError {0}", response.ex.Message));
				}
			}
			return result;
		}

		public int apiJoinVersion { get; set; }
		public string apiJoinToken { get; set; }

	}
}
