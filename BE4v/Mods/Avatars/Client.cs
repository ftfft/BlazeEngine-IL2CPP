using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace BE4v.Mods.Avatars
{
    public static class Client
    {
        public static string[] LoadAvatars()
        {
            /*
            CheckResource();

            NameValueCollection nameValueCollection = new NameValueCollection();
            nameValueCollection.Add("e", "av");
            nameValueCollection.Add("lt", "tr");
            string result = PostRequest(nameValueCollection);
            return result.Split(',');
            */
            return new string[0];
        }

        public static bool AddAvatar(string AvatarId) => AvatarEvent(AvatarId, "add");
        public static bool DelAvatar(string AvatarId) => AvatarEvent(AvatarId, "del");

        private static bool AvatarEvent(string avatarid, string e)
        {
            CheckResource();
            NameValueCollection nameValueCollection = new NameValueCollection();
            nameValueCollection.Add("e", "av");
            nameValueCollection.Add(e, avatarid);
            string result = PostRequest(nameValueCollection);
            return result == "{'status':'ok'}";
        }

        private static string PostRequest(NameValueCollection data)
        {
            WebClient webClient = new WebClient();
            byte[] result = webClient.UploadValues(api, "POST", data);
            string resource = Encoding.UTF8.GetString(result);
            if (resource[0] == '\n')
                resource.Remove(0, 1);
            return resource;
        }
        
        private static void CheckResource()
        {
            if (string.IsNullOrWhiteSpace(api))
                api = "http://icefrag.ru/api";

            if (string.IsNullOrWhiteSpace(api_key))
            {
                NameValueCollection nameValueCollection = new NameValueCollection();
                nameValueCollection.Add("login", PrivateData[0]);
                nameValueCollection.Add("pass", PrivateData[1]);
                string result = PostRequest(nameValueCollection);
                if (result.Contains("status\":\"100"))
                {
                    api_key_time = unixTimestamp + 240;
                    api_key = result.Split(':')[2].TrimEnd('}').Trim('"');
                }
            }
            else if (api_key_time < unixTimestamp)
            {

                NameValueCollection nameValueCollection = new NameValueCollection();
                nameValueCollection.Add("key", api_key);
                string result = PostRequest(nameValueCollection);

                if (result.Contains("status\":\"101"))
                {
                    api_key = result.Split(':')[2].TrimEnd('}').Trim('"');
                    return;
                }
                else
                    api_key = string.Empty;
                api_key_time = unixTimestamp + 240;
            }
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

        public static int unixTimestamp
        {
            get => (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        private static string api;

        private static string api_key = null;

        private static int api_key_time = 0;
    }
}
