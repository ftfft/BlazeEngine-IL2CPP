using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotonClient.API.Response;

namespace PhotonClient.API.Endpoint
{
    public static class SerilizerJSON
    {
        public static string Serilize_APIKey(string json)
        {
            return FastFind(json, "apiKey");
        }

        public static T Serilize_Response<T>(string json) where T : ApiContainer
        {
            T result = null;
            if (typeof(T) == typeof(UserSelfResponse) || typeof(T) == typeof(UserResponse))
            {
                UserSelfResponse data = new UserSelfResponse();
                data.username = FastFind(json, "username");
                data.displayName = FastFind(json, "displayName");
                data.currentAvatarImageUrl = FastFind(json, "currentAvatarImageUrl");
                data.currentAvatarThumbnailImageUrl = FastFind(json, "currentAvatarThumbnailImageUrl");
                data.tags = new List<string>();
                foreach (var tag in json.Remove(0, json.IndexOf("\"tags\":\"") + 1).Split(new char[] { '[' }, 2)[1].Split(new char[] { ']' }, 2)[0].Split(new char[] { '\"' }))
                {
                    string szTemp = tag.Replace(",", string.Empty);
                    if (!string.IsNullOrEmpty(szTemp))
                        data.tags.Add(szTemp);
                }
                data.developerType = FastFind(json, "developerType");
                data.last_login = FastFind(json, "last_login");
                // result.allowAvatarCopying = FastFind(json, "allowAvatarCopying");
                data.friendKey = FastFind(json, "friendKey");
                // result.location = FastFind(json, "location");
                result = (T)(object)data;
            }
            else if (typeof(T) == typeof(WorldResponse))
            {
                WorldResponse data = new WorldResponse();
                data.name = FastFind(json, "name");
                data.capacity = FastFind_int(json, "capacity");
                // result.location = FastFind(json, "location");
                result = (T)(object)data;
            }
            if (result != null)
                result.id = FastFind(json, "id");

            return result;
        }

        private static string FastFind(string json, string type)
        {
            return json.Remove(0, json.IndexOf($"\"{type}\":\"") + 1).Split(new char[] { '\"' })[2];
        }
        private static int FastFind_int(string json, string type)
        {
            return Convert.ToInt32(json.Remove(0, json.IndexOf($"\"{type}\":") + 1).Split(new char[] { '\"', ':', ',' })[2]);
        }
    }
}
