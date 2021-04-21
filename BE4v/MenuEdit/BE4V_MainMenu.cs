using BE4v.MenuEdit.Construct;
using System;
using UnityEngine;

namespace BE4v.MenuEdit
{
    public static class BE4V_MainMenu
    {
        public static void Delete()
        {

            foreach (Transform transform in QuickMenu.Instance.transform)
            {
                switch (transform.gameObject.name)
                {
                    case "EmoteMenu": goto case "be4v_destroy";
                    case "ModerationMenu": goto case "be4v_destroy";
                    case "UserIconMenu": goto case "be4v_destroy";
                    case "UserIconCameraMenu": goto case "be4v_destroy";
                    case "be4v_destroy":
                        {
                            UnityEngine.Object.Destroy(transform.gameObject);
                            break;
                        }
                }
                foreach (Transform transform1 in transform)
                {
                    switch (transform1.gameObject.name)
                    {
                        case "EmoteButton": goto case "be4v_destroy";
                        case "UserIconButton": goto case "be4v_destroy";
                        case "UserIconCameraButton": goto case "be4v_destroy";
                        case "CustomizeNameplateButton": goto case "be4v_destroy";
                        case "HeaderContainer":
                            {
                                foreach (Transform transform2 in transform1)
                                {
                                    if (transform2.gameObject.name == "VRCPlusBanner")
                                        UnityEngine.Object.Destroy(transform2.gameObject);
                                }
                                break;
                            }
                        case "VRCPlusThankYou": goto case "be4v_destroy";
                        case "VRCPlusMiniBanner": goto case "be4v_destroy";
                        case "ReportWorldButton": goto case "be4v_destroy";
                        case "DevToolsButton": goto case "be4v_destroy";
                        case "be4v_destroy":
                            {
                                UnityEngine.Object.Destroy(transform1.gameObject);
                                break;
                            }
                        case "SitButton":
                            {
                                QuickToggler quickToggler = new QuickToggler(transform1.gameObject);
                                quickToggler.MoveLocation(1, 0);
                                break;
                            }
                        case "SettingsButton":
                            {
                                QuickButton quickButton = new QuickButton(transform1.gameObject);
                                quickButton.MoveLocation(-1, 0);
                                break;
                            }
                        case "EmojiButton":
                            {
                                QuickButton quickButton = new QuickButton(transform1.gameObject);
                                quickButton.MoveLocation(-1, 0);
                                break;
                            }
                        case "QMInfoToggle":
                            {
                                QuickToggler quickToggler = new QuickToggler(transform1.gameObject);
                                quickToggler.MoveLocation(-2, 1);
                                break;
                            }
                        case "Toggle_States_ShowTrustRank_Colors":
                            {
                                QuickToggler quickToggler = new QuickToggler(transform1.gameObject);
                                quickToggler.MoveLocation(-1, 0);
                                break;
                            }
                    }
                }
            }
            "QuickMenu element's".RedPrefix("Destroy");
            Start();
        }

        public static void Start()
        {
            new QuickButton("ShortcutMenu", -1, 0, "Remove\nCreated\nObjects", UserUtils.RemoveInstiatorObjects, "Clear all portals, created object's on map");
            BE4V_QuickUIMenu.Start();
        }
    }
}
