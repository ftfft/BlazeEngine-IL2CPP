using System;
using BE4v.Mods.Avatars;
using BE4v.Utils;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;
using VRC.UI;
using Object = UnityEngine.Object;

namespace BE4v.Mods
{
    public static class Mod_Avatars
    {
        private static void Start()
        {
            if (favList != null)
                return;

            Transform changeButton = null;
            foreach (var p in Resources.FindObjectsOfTypeAll<PageAvatar>())
            {
                if ((changeButton = p.transform.Find("Change Button")) != null)
                {
                    pageAvatar = p;
                    break;
                }
            }
            if (pageAvatar == null) return;
            if (changeButton == null)
            {
                "Fav not found #0".RedPrefix("[Error]");
                return;
            }
            favButton = Object.Instantiate(changeButton, changeButton.parent);
            if (favButton == null)
            {
                "Fav not found #1".RedPrefix("[Error]");
                return;
            }
            favButton.name = "ToggleFavorite";
            favButton.gameObject.SetActive(false);
            favButton.GetComponent<Button>().interactable = false;
            favButton.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            favButton.GetComponent<Button>().onClick.AddListener(onClickFavButton);

            avatarModel = pageAvatar.transform.Find("AvatarPreviewBase");
            if (avatarModel == null)
            {
                "Fav not found #2".RedPrefix("[Error]");
                return;
            }
            baseAvatarModelPosition = avatarModel.localPosition;
            baseButtonFavPosition = changeButton.localPosition;
            favList = Utils.Avatars.AddNewList("Favorite (BlazeEngine)", 1);
            /// FileDebug.debugGameObject("test_PageAvatar_0.txt", favList.gameObject);
            favButton.GetComponent<Button>().interactable = true;

            favButton.gameObject.SetActive(true);
            favButton.localPosition = baseButtonFavPosition + new Vector3(0, 80, 0);
            avatarModel.localPosition = baseAvatarModelPosition + new Vector3(0, 60, 0);
            avatarModel.localScale *= 0.8f;

            string[] avtrs = Client.LoadAvatars();
            foreach (var av in avtrs)
                AddFavorite(av);
        }


        public static void Update()
        {
            if (favList == null)
            {
                Start();
                if (favList == null)
                    return;

                resfresh = 3;
            }

            if (resfresh > 0)
            {
                resfresh--;
                if (resfresh == 1)
                    UpdateAvatarList();
                return;
            }

            ApiAvatar apiAvatar = pageAvatar?.avatar?.apiAvatar;
            if (apiAvatar != null)
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    favButton.GetComponentInChildren<Text>().text = "<color=red>Download .vrca</color>";
                    return;
                }

                if (Base.AvatarId.Contains(apiAvatar.id))
                {
                    if (!apiAvatar.releaseStatus.Equals("public") && apiAvatar.authorId != APIUser.CurrentUser.id)
                        favButton.GetComponentInChildren<Text>().text = "<color=red>Unfavorite</color>";
                    else
                        favButton.GetComponentInChildren<Text>().text = "Unfavorite";
                    return;
                }

                if (apiAvatar.authorId == APIUser.CurrentUser.id)
                {
                    if (apiAvatar.releaseStatus.Equals("public"))
                        favButton.GetComponentInChildren<Text>().text = "Make Private";
                    else
                        favButton.GetComponentInChildren<Text>().text = "Make Public";
                    return;
                }

                favButton.GetComponentInChildren<Text>().text = "Favorite";
            }
        }

        public static void UpdateAvatarList()
        {
            if (favList == null)
                return;

            // favList.specificListValues.Clear();
            favList.specificListIds = Base.AvatarId.ToArray();
            favList.expandedHeight = 850f;
            favList.extendRows = 4;
            // favList.Refresh();
        }

        public static void onClickFavButton()
        {

            ApiAvatar apiAvatar = pageAvatar?.avatar?.apiAvatar;
            if (apiAvatar != null)
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    string url = apiAvatar.assetUrl;
                    if (Utils.Avatars.IsValidUrl(url))
                        Utils.Avatars.OpenUrlBrowser(url);
                    return;
                }

                if (Base.AvatarId.Contains(apiAvatar.id))
                {
                    RemoveFavorite(apiAvatar.id);
                    Client.DelAvatar(apiAvatar.id);
                    return;
                }

                if (apiAvatar.authorId == APIUser.CurrentUser.id)
                {
                    if (apiAvatar.releaseStatus.Equals("public"))
                        apiAvatar.releaseStatus = "private";
                    else
                        apiAvatar.releaseStatus = "public";
                    apiAvatar.SaveReleaseStatus();
                    return;
                }

                AddFavorite(apiAvatar.id);
                Client.AddAvatar(apiAvatar.id);
            }
        }

        public static void AddFavorite(string avatarId)
        {
            if (Base.AvatarId.Contains(avatarId))
                return;

            Base.AvatarId.Insert(0, avatarId);
            UpdateAvatarList();
        }

        public static void RemoveFavorite(string avatarId)
        {
            if (!Base.AvatarId.Contains(avatarId))
                return;

            Base.AvatarId.Remove(avatarId);
            UpdateAvatarList();
        }

        public static int resfresh = 3;

        private static PageAvatar pageAvatar;
        internal static UiAvatarList favList;

        private static Transform avatarModel;
        private static Transform favButton;

        private static Vector3 baseAvatarModelPosition;
        private static Vector3 baseButtonFavPosition;
    }
}
