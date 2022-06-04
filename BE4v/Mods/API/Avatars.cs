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
        public static List<string> AvatarId = new List<string>();

        public static void LoadAvatars()
        {
            try
            {
                AvatarId = Core.Request("api/license/avatarlist").Split(',').ToList();
                ("Loaded is " + AvatarId.Count() + " avatars").GreenPrefix("BE4v Avatars");
            }
            catch { "Failed! Load avatar from API.".RedPrefix("Be4v API"); }
        }

        public static void Add(string avatarId)
        {
            try
            {
                NameValueCollection collection = new NameValueCollection()
                {
                    { "if-avatar", avatarId },
                };
                Core.Request("api/license/avatar/add", collection);
            }
            catch { "Failed! Load avatar from API.".RedPrefix("Be4v API"); }
        }
        
        public static void Remove(string avatarId)
        {
            try
            {
                NameValueCollection collection = new NameValueCollection()
                {
                    { "if-avatar", avatarId },
                };
                Core.Request("api/license/avatar/remove", collection);
            }
            catch { "Failed! Load avatar from API.".RedPrefix("Be4v API"); }
        }
    }
}
