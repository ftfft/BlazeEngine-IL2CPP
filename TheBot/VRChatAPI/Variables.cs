using System.Net.Http;
using System.Net;
using VRChatAPI.Responses;

namespace VRChatAPI
{
    public static class Variables
    {
        public static HttpClient HttpClient { get; set; }
        public static HttpClientHandler HttpClientHandler { get; set; }
        public static CookieContainer CookieContainer { get; set; }
        public static ConfigRES Config { get; set; }
        public static UserSelfRES UserSelfRES { get; set; }
        public static string BaseAddress = "https://api.vrchat.cloud/api/1/";
        public static string APIKey = "";
        public static string AuthCookie = "";
    }
}
