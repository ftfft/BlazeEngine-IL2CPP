using System;
using UnityEngine;
using UnityEngine.UI;
using CustomQuickMenu;
using VRC.Core;

public class Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5
{
    /*
        * :: QuickMenu List ::
        * -> ShortcutMenu
        * -> UserInteractMenu
        * -> UIElementsMenu
        */
    public static void \u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5()
    {
        BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5").GetField("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5").SetValue(null, null);
        new QMSingleButton("ShortcutMenu", 5, 2, "Select\nyourself", delegate ()
        {
            QuickMenu.Instance.SelectedUser = APIUser.CurrentUser;
            QuickMenu.Instance.SetMenuIndex(3);
        }, "Select yourself.");

        BlazeEngineAssembly.assembly.GetType("CustomQuickMenu.QuickMenuStuff").GetMethod("CreateCustomMenu").Invoke(null, new object[] { "UIElementsMenu2" });
        BlazeEngineAssembly.assembly.GetType("CustomQuickMenu.QuickMenuStuff").GetMethod("CreateCustomMenu").Invoke(null, new object[] { "UIElementsMenu3" });
        BlazeEngineAssembly.assembly.GetType("CustomQuickMenu.QuickMenuStuff").GetMethod("CreateCustomMenu").Invoke(null, new object[] { "UIElementsMenu4" });

        #region CreateArray_UIElementsMenu
        // -------------------------------------------------------------------
        #region UIEM1_Buttons
        QMSingleButton UIEM1_Up = new QMSingleButton("UIElementsMenu", 5, 0, " ", delegate () { BlazeEngineAssembly.assembly.GetType("CustomQuickMenu.QuickMenuStuff").GetMethod("ShowQuickmenuPage").Invoke(null, new object[] { "UIElementsMenu4" }); }, "Go to prev page");

        UIEM1_Up.getGameObject().GetComponentInChildren<Image>().sprite = QuickMenu.Instance.transform.Find("EmojiMenu/PageUp").GetComponentInChildren<UnityEngine.UI.Image>().sprite;
        UIEM1_Up.getGameObject().GetComponentInChildren<Image>().material = QuickMenu.Instance.transform.Find("EmojiMenu/PageUp").GetComponentInChildren<UnityEngine.UI.Image>().material;

        QMSingleButton UIEM1_Down = new QMSingleButton("UIElementsMenu", 5, 1, " ", delegate () { BlazeEngineAssembly.assembly.GetType("CustomQuickMenu.QuickMenuStuff").GetMethod("ShowQuickmenuPage").Invoke(null, new object[] { "UIElementsMenu2" }); }, "Go to next page");

        UIEM1_Down.getGameObject().GetComponentInChildren<Image>().sprite = QuickMenu.Instance.transform.Find("EmojiMenu/PageDown").GetComponentInChildren<UnityEngine.UI.Image>().sprite;
        UIEM1_Down.getGameObject().GetComponentInChildren<Image>().material = QuickMenu.Instance.transform.Find("EmojiMenu/PageDown").GetComponentInChildren<UnityEngine.UI.Image>().material;

        Transform button = QuickMenu.Instance.transform.Find("UIElementsMenu/BackButton");
        button.GetComponentInChildren<Text>().text = "Back\n(1 of 4)";
        button.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (420 * 1);
        button.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 * 0);
        #endregion
        // -------------------------------------------------------------------
        #region UIEM2_Buttons
        QMSingleButton UIEM2_Up = new QMSingleButton("UIElementsMenu2", 5, 0, " ", delegate () { BlazeEngineAssembly.assembly.GetType("CustomQuickMenu.QuickMenuStuff").GetMethod("ShowQuickmenuPage").Invoke(null, new object[] { "UIElementsMenu" }); }, "Go to prev page");

        UIEM2_Up.getGameObject().GetComponentInChildren<Image>().sprite = QuickMenu.Instance.transform.Find("EmojiMenu/PageUp").GetComponentInChildren<UnityEngine.UI.Image>().sprite;
        UIEM2_Up.getGameObject().GetComponentInChildren<Image>().material = QuickMenu.Instance.transform.Find("EmojiMenu/PageUp").GetComponentInChildren<UnityEngine.UI.Image>().material;

        QMSingleButton UIEM2_Down = new QMSingleButton("UIElementsMenu2", 5, 1, " ", delegate () { BlazeEngineAssembly.assembly.GetType("CustomQuickMenu.QuickMenuStuff").GetMethod("ShowQuickmenuPage").Invoke(null, new object[] { "UIElementsMenu3" }); }, "Go to next page");

        UIEM2_Down.getGameObject().GetComponentInChildren<Image>().sprite = QuickMenu.Instance.transform.Find("EmojiMenu/PageDown").GetComponentInChildren<UnityEngine.UI.Image>().sprite;
        UIEM2_Down.getGameObject().GetComponentInChildren<Image>().material = QuickMenu.Instance.transform.Find("EmojiMenu/PageDown").GetComponentInChildren<UnityEngine.UI.Image>().material;

        GameObject UIEM2_Back = UnityEngine.Object.Instantiate<GameObject>(button.gameObject, QuickMenu.Instance.transform.Find("UIElementsMenu2"), true);
        UIEM2_Back.GetComponentInChildren<Text>().text = "Back\n(2 of 4)";
        UIEM2_Back.GetComponent<Button>().onClick.AddListener(ButtonAction_Back);
        #endregion
        // -------------------------------------------------------------------
        #region UIEM3_Buttons
        QMSingleButton UIEM3_Up = new QMSingleButton("UIElementsMenu3", 5, 0, " ", delegate () { BlazeEngineAssembly.assembly.GetType("CustomQuickMenu.QuickMenuStuff").GetMethod("ShowQuickmenuPage").Invoke(null, new object[] { "UIElementsMenu2" }); }, "Go to prev page");

        UIEM3_Up.getGameObject().GetComponentInChildren<Image>().sprite = QuickMenu.Instance.transform.Find("EmojiMenu/PageUp").GetComponentInChildren<UnityEngine.UI.Image>().sprite;
        UIEM3_Up.getGameObject().GetComponentInChildren<Image>().material = QuickMenu.Instance.transform.Find("EmojiMenu/PageUp").GetComponentInChildren<UnityEngine.UI.Image>().material;

        QMSingleButton UIEM3_Down = new QMSingleButton("UIElementsMenu3", 5, 1, " ", delegate () { BlazeEngineAssembly.assembly.GetType("CustomQuickMenu.QuickMenuStuff").GetMethod("ShowQuickmenuPage").Invoke(null, new object[] { "UIElementsMenu4" }); }, "Go to next page");

        UIEM3_Down.getGameObject().GetComponentInChildren<Image>().sprite = QuickMenu.Instance.transform.Find("EmojiMenu/PageDown").GetComponentInChildren<UnityEngine.UI.Image>().sprite;
        UIEM3_Down.getGameObject().GetComponentInChildren<Image>().material = QuickMenu.Instance.transform.Find("EmojiMenu/PageDown").GetComponentInChildren<UnityEngine.UI.Image>().material;

        GameObject UIEM3_Back = UnityEngine.Object.Instantiate<GameObject>(button.gameObject, QuickMenu.Instance.transform.Find("UIElementsMenu3"), true);
        UIEM3_Back.GetComponentInChildren<Text>().text = "Back\n(3 of 4)";
        UIEM3_Back.GetComponent<Button>().onClick.AddListener(ButtonAction_Back);
        #endregion
        // -------------------------------------------------------------------
        #region UIEM4_Buttons
        QMSingleButton UIEM4_Up = new QMSingleButton("UIElementsMenu4", 5, 0, " ", delegate () { BlazeEngineAssembly.assembly.GetType("CustomQuickMenu.QuickMenuStuff").GetMethod("ShowQuickmenuPage").Invoke(null, new object[] { "UIElementsMenu3" }); }, "Go to prev page");

        UIEM4_Up.getGameObject().GetComponentInChildren<Image>().sprite = QuickMenu.Instance.transform.Find("EmojiMenu/PageUp").GetComponentInChildren<UnityEngine.UI.Image>().sprite;
        UIEM4_Up.getGameObject().GetComponentInChildren<Image>().material = QuickMenu.Instance.transform.Find("EmojiMenu/PageUp").GetComponentInChildren<UnityEngine.UI.Image>().material;

        QMSingleButton UIEM4_Down = new QMSingleButton("UIElementsMenu4", 5, 1, " ", delegate () { BlazeEngineAssembly.assembly.GetType("CustomQuickMenu.QuickMenuStuff").GetMethod("ShowQuickmenuPage").Invoke(null, new object[] { "UIElementsMenu" }); }, "Go to next page");

        UIEM4_Down.getGameObject().GetComponentInChildren<Image>().sprite = QuickMenu.Instance.transform.Find("EmojiMenu/PageDown").GetComponentInChildren<UnityEngine.UI.Image>().sprite;
        UIEM4_Down.getGameObject().GetComponentInChildren<Image>().material = QuickMenu.Instance.transform.Find("EmojiMenu/PageDown").GetComponentInChildren<UnityEngine.UI.Image>().material;

        GameObject UIEM4_Back = UnityEngine.Object.Instantiate<GameObject>(button.gameObject, QuickMenu.Instance.transform.Find("UIElementsMenu4"), true);
        UIEM4_Back.GetComponentInChildren<Text>().text = "Back\n(4 of 4)";
        UIEM4_Back.GetComponent<Button>().onClick.AddListener(ButtonAction_Back);
        #endregion

        #endregion

        BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5").SetValue(null, new QMToggleButton("UIElementsMenu", 4, 0, "Fly on", delegate () { BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5").GetMethod("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5").Invoke(null, new object[0]); }, "Fly off", "Toggle: Fly mode"));
        BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").SetValue(null, new QMToggleButton("UIElementsMenu", 4, 1, "Fly:\nDirectional", delegate() { BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5").GetMethod("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5").Invoke(null, new object[0]); }, "Fly: Default", "Toggle: NoClip / Fly"));

        BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5").SetValue(null, new QMToggleButton("UIElementsMenu4", 2, 0, "BunnyHop ON", delegate () { BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5").GetMethod("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5").Invoke(null, new object[0]); }, "BunnyHop OFF", "Toggle: BunnyHop"));

        BlazeEngineAssembly.assembly.GetType("CustomQuickMenu.QuickMenuStuff").GetMethod("ChangeColorMenu").Invoke(null, new object[] { Color.green, Color.white });
        BlazeEngineAssembly.assembly.GetType("CustomQuickMenu.QuickMenuStuff").GetMethod("ChangeColorButtons").Invoke(null, new object[] { Color.green, Color.green });
    }

    public static void ButtonAction_Back()
    {
        QuickMenu.Instance.SetMenuIndex(0);
    }

    // flyToggler
    public static object \u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5;
    // noClipToggler
    public static object \u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5;
    // bhop
    public static object \u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5;
}