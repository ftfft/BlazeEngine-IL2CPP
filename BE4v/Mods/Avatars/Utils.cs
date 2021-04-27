using System;
using UnityEngine;
using UnityEngine.UI;

namespace BE4v.Mods.Avatars
{
    public static class Utils
    {
        public static bool IsValidUrl(string url) => !string.IsNullOrEmpty(url) && url.Length < 90 && url.StartsWith("https://api.vrchat.cloud/api/1/file/file_") && url.EndsWith("/file");
        public static void OpenUrlBrowser(string url) => System.Diagnostics.Process.Start(url);
        
        public static UiAvatarList AddNewList(string title, int index)
        {
            UiAvatarList[] uiAvatarLists = Resources.FindObjectsOfTypeAll<UiAvatarList>();

            if (uiAvatarLists.Length == 0)
            {
                "uiAvatarLists == 0!".RedPrefix("[Error]");
                return null;
            }

            UiAvatarList gameFavList = null;
            foreach (UiAvatarList list in uiAvatarLists)
            {
                if (list.name.Contains("Favorite") && !list.name.Contains("Quest"))
                {
                    gameFavList = list;
                    break;
                }
            }

            if (gameFavList == null)
            {
                "gameFavList not found!".RedPrefix("[Error]");
                return null;
            }
            UiAvatarList newList = GameObject.Instantiate<UiAvatarList>(gameFavList, gameFavList.transform.parent);


            newList.GetComponentInChildren<Button>(true).GetComponentInChildren<Text>().text = title;
            newList.gameObject.SetActive(true);

            newList.transform.SetSiblingIndex(index);
            newList.transform.Find("GetMoreFavorites")?.gameObject.SetActive(false);

            newList.category = UiAvatarList.Category.SpecificList;

            return newList;
        }
    }
}
