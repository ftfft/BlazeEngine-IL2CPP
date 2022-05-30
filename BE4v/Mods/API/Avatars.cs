using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Threading;
using System.Net;

namespace BE4v.Mods.API
{
    public static class Avatars
    {
        public static void Add(string avatarId)
        {
            if (!License.IsLicense)
                License.Connect();

            new Thread(() =>
            {
                try
                {
                    NameValueCollection nameValueCollection = new NameValueCollection();
                    nameValueCollection.Add("be4v", License.GetLicense);
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.BaseAddress = License._api_url;
                        webClient.UploadValues("/api/avatar/add", nameValueCollection);
                    }
                }
                catch (Exception ex)
                {
                    ("Ex: " + ex.ToString()).RedPrefix("Avatars::Web::Add");
                }
            }).Start();
        }
        
        public static void Remove(string avatarId)
        {
            if (!License.IsLicense)
                License.Connect();

            new Thread(() =>
            {
                try
                {
                    NameValueCollection nameValueCollection = new NameValueCollection();
                    nameValueCollection.Add("be4v", License.GetLicense);
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.BaseAddress = License._api_url;
                        webClient.UploadValues("/api/avatar/remove", nameValueCollection);
                    }
                }
                catch (Exception ex)
                {
                    ("Ex: " + ex.ToString()).RedPrefix("Avatars::Web::Remove");
                }
            }).Start();
        }
    }
}
