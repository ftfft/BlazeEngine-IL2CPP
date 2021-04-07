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
                    switch(transform1.gameObject.name)
                    {
                        case "EmoteButton": goto case "be4v_destroy";
                        case "UserIconButton": goto case "be4v_destroy";
                        case "UserIconCameraButton": goto case "be4v_destroy";
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
                    }
                }
            }
            "QuickMenu element's".RedPrefix("Destroy");
        }

        public static void Start()
        {

        }
    }
}
