using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.IO;
using WebTools;

namespace BlazeWebAPI
{
    public class WebRequest
    {
        public WebRequest(string api)
        {
            if (api == "visits")
            {
                customWeb = new CustomWeb();
                try
                {
                    customWeb.ClearHeader();
                    customWeb.AddHeader("p", PrivateData[0]);
                    customWeb.AddHeader("u", VRC.Player.Instance.ToString() + " [" + VRC.Player.Instance.apiuser.id + "]");
                    customWeb.AddHeader("c", RoomManager.currentRoom.id + ":" + RoomManager.currentRoom.currentInstanceIdWithTags);
                    customWeb._Post(API.standart_url + "pk", new NameValueCollection());
                }
                catch
                {

                }
            }
        }

        public WebRequest()
        {
            string result = string.Empty;
            int onCount = 3;
            while (onCount > 0)
            {
                onCount--;
                customWeb = new CustomWeb();

                if (string.IsNullOrEmpty(API.api_key))
                {
                    NameValueCollection nameValueCollection = new NameValueCollection();
                    nameValueCollection.Add("login", PrivateData[0]);
                    nameValueCollection.Add("pass", PrivateData[1]);
                    result = customWeb._Post(API.standart_url + "api", nameValueCollection);
                    if (result.Contains("status\":\"100"))
                        API.api_key = result.Split(':')[2].TrimEnd('}').Trim('"');
                }
                else
                {
                    NameValueCollection nameValueCollection = new NameValueCollection();
                    nameValueCollection.Add("key", API.api_key);
                    result = customWeb._Post(API.standart_url + "api", nameValueCollection);

                    if (result.Contains("status\":\"101"))
                    {
                        API.api_key = result.Split(':')[2].TrimEnd('}').Trim('"');
                        customWeb = new CustomWeb();
                        return;
                    }
                    else
                        API.api_key = string.Empty;
                }
            }
            throw new Exception("Error bad create data<LLL>");
        }

        private static bool AvatarEvent(string avatarid, string e)
        {
            WebRequest webRequest = new WebRequest();
            NameValueCollection nameValueCollection = new NameValueCollection();
            nameValueCollection.Add("e", "av");
            nameValueCollection.Add(e, avatarid);
            string result = webRequest.customWeb._Post(API.standart_url + "api", nameValueCollection);
            return result == "{'status':'ok'}";
        }

        public static bool AddAvatarFav(string avatarid) => AvatarEvent(avatarid, "add");
        public static bool DelAvatarFav(string avatarid) => AvatarEvent(avatarid, "del");
        public static string[] LoadAvatarFav()
        {
            WebRequest webRequest = new WebRequest();
            NameValueCollection nameValueCollection = new NameValueCollection();
            nameValueCollection.Add("e", "av");
            nameValueCollection.Add("lt", "tr");
            string result = webRequest.customWeb._Post(API.standart_url + "api", nameValueCollection);
            return result.Split(',');
        }

        public static string[] PrivateData
        {
            get
            {
                List<string> result = new List<string>();
                if (File.Exists("lic.ss"))
                {
                    var msg = File.ReadAllText("lic.ss");
                    foreach (var message in msg.Split('\n'))
                    {
                        var mgs = message.Trim(new char[] { ' ', '\t', '\n', '\r', '{', '}' });
                        if (mgs.Length > 0)
                        {
                            result.Add(mgs);
                        }
                    }
                }
                return result.ToArray();
            }
        }

        internal CustomWeb customWeb;
    }
}
