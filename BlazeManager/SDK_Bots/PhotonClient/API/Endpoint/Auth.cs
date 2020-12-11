using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PhotonClient.API.Response;

namespace PhotonClient.API.Endpoint
{
    public class Auth
	{
		public string username { get; set; }

		public string password { get; set; }

		public Auth(string username, string password)
		{
			this.username = username;
			this.password = password;
		}

		public UserSelfResponse Login()
		{
			UserSelfResponse result = null;
			var response = Variables.HttpClient.Get("auth/user?apiKey=" + Config.API_KEY);
			if (response.isSuccess)
			{
				result = SerilizerJSON.Serilize_Response<UserSelfResponse>(response.result);
				if (response.cookie != null && string.IsNullOrEmpty(Variables.AuthCookie))
                {
					foreach(var cookie in response.cookie.Split(new char[] { ';', ',' }))
                    {
						if (cookie.StartsWith("auth="))
						{
							Variables.AuthCookie = cookie.Split('=').Last().Trim();
						}
					}
				}
			}
			else
			{
				Console.WriteLine(string.Format("An Error occurred while logging in!\nError {0}", response.ex.Message));
			}
			return result;
		}
	}
}
