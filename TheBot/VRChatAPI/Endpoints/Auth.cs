using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VRChatAPI.Responses;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace VRChatAPI.Endpoints
{
    public class Auth
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Auth(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public async Task<UserSelfRES> Login()
        {
            string json = "";
            UserSelfRES currentUser = null;

            var response = await Variables.HttpClient.GetAsync($"auth/user?apiKey={Variables.APIKey}");
            json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                currentUser = JsonConvert.DeserializeObject<UserSelfRES>(json);
                Console.WriteLine($"Logged in as {currentUser.displayName}");
                foreach (var cookie in Variables.CookieContainer.GetCookies(new Uri(Variables.BaseAddress)).Cast<Cookie>())
                    if (cookie.Name == "auth")
                        Variables.AuthCookie = cookie.Value;
            }
            else
            {
                Console.WriteLine($"An Error occurred while logging in!\nError {response.StatusCode}\n{json}");
            }

            return currentUser;
        }
    }
}
