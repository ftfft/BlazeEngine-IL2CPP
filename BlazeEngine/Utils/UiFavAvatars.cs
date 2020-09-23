/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI;

public class UiFavAvatars
{
    public static void Start()
    {
        if (favList != null)
            return;

        Transform changeButton = null;
        pageAvatar = Resources.FindObjectsOfTypeAll<PageAvatar>().First(p => (changeButton = p.transform.Find("Change Button")) != null);
        //baseChooseEvent = changeButton.GetComponent<Button>().onClick;

        // changeButton.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
        changeButton.GetComponent<Button>().onClick.RemoveAllListeners();
        changeButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            // SelectAvatar(pageAvatar.avatar.apiAvatar.id);
            Console.WriteLine("Tipo change avatar");
        });

        favList = VRUI_Helper.AddNewList("Favorite (BlazeEngine)", 1);

        favButton = GameObject.Instantiate<Transform>(changeButton, changeButton.parent);
        favButton.name = "ToggleFavorite";
        favButton.gameObject.SetActive(false);
        favButton.localPosition = new Vector3(0, 80, 0);
        favButton.GetComponent<Button>().interactable = false;

        favButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            // ToggleAvatar();
            Console.WriteLine("Toggle Avatar");
        });

        avatarModel = pageAvatar.transform.Find("AvatarModel");
        baseAvatarModelPosition = avatarModel.localPosition;
    }


    public static void Update()
    {
        if (favButton == null)
            return;

        if (!favList.gameObject.activeInHierarchy)
        {
            IsAvatarReloadList = false;
            return;
        }

        if (!IsAvatarReloadList)
        {
            IsAvatarReloadList = true;
            UpdateAvatarList();
        }

        favButton.gameObject.SetActive(true);
        avatarModel.localPosition = baseAvatarModelPosition + new Vector3(0, 60, 0);
        /*
        if (UserUtils.Menu_AvatarsList.Contains(pageAvatar.avatar.apiAvatar.id))
        {
            favButton.GetComponentInChildren<Text>().text = "Unfavorite";
            if (!pageAvatar.avatar.apiAvatar.releaseStatus.Equals("public") && pageAvatar.avatar.apiAvatar.authorId != APIUser.CurrentUser.id)
            {
                favButton.GetComponentInChildren<Text>().text = "<color=red>Unfavorite</color>";
            }
            return;
        }

        if (pageAvatar.avatar.apiAvatar.authorId == APIUser.CurrentUser.id)
        {
            if (pageAvatar.avatar.apiAvatar.releaseStatus.Equals("public"))
            {
                favButton.GetComponentInChildren<Text>().text = "Make Private";
                return;
            }
            favButton.GetComponentInChildren<Text>().text = "Make Public";
            return;
        }

        if (!pageAvatar.avatar.apiAvatar.releaseStatus.Equals("public"))
        {
            favButton.gameObject.SetActive(false);
            avatarModel.localPosition = baseAvatarModelPosition;
            return;
        }
        favButton.GetComponentInChildren<Text>().text = "Favorite";
        */
/*    }

    public static void UpdateAvatarList()
    {
        favList.ClearSpecificList();
        favButton.GetComponent<Button>().interactable = true;
        // favList.specificListIds = UserUtils.Menu_AvatarsList.ToArray();
        favList.expandedHeight = 850f;
        favList.extendRows = 4;
        favList.Refresh();
    }

    private static PageAvatar pageAvatar = null;
    private static UiAvatarList favList = null;
    private static Transform favButton = null;

    private static Vector3 baseAvatarModelPosition;
    private static Transform avatarModel;

    private static bool IsAvatarReloadList;
}
*/