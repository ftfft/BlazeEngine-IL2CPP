using System;
using PhotonClient.API.Response;

namespace PhotonClient.API
{
	public static class Variables
	{
		public static HttpClient.HttpClient HttpClient { get; set; }

		public static string baseAddress = "https://api.vrchat.cloud/api/1/";
		public static UserSelfResponse user { get; set; }

		public static string AuthCookie = "";
	}
}
