using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PhotonClient.API.Response;

namespace PhotonClient.API.Endpoint
{
    public static class Config
	{
        private static string szAPI_KEY = null;
		public static string API_KEY
        {
            get
            {
                if (string.IsNullOrEmpty(szAPI_KEY))
                {
                    var response = Variables.HttpClient.Get("config");

                    if (response.isSuccess && !string.IsNullOrEmpty(response.result))
                    {
                        szAPI_KEY = SerilizerJSON.Serilize_APIKey(response.result);
                        Console.WriteLine("Grabbed config!\nSet APIKey as " + szAPI_KEY);
                    }
                    else
                    {
                        Console.WriteLine($"An Error occurred while logging in!\nError " + response.ex.Message);
                    }
                }
                return szAPI_KEY;
            }
        }

	}
}
