using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VRChatAPI.Responses;

namespace VRChatAPI.Endpoints
{
    public class Config
    {
        public async Task<ConfigRES> Get()
        {
            string json = "";
            ConfigRES config = null;

            var response = await Variables.HttpClient.GetAsync($"config");
            json = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                config = JsonConvert.DeserializeObject<ConfigRES>(json);
                Variables.Config = config;
                Console.WriteLine("Grabbed config!");
            }
            else
            {
                Console.WriteLine($"An Error occurred while logging in!\nError {response.StatusCode}\n{json}");
            }

            return config;
        }
    }
}
