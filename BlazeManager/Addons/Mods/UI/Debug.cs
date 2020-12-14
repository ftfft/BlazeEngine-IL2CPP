using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace Addons.Mods.UI
{
    public static class Debug
    {
        public static void ShowMenu()
        {
            Rect rect = new Rect(Screen.width - 450, Screen.height - 410, 400f, 400f);
            GUI.Box(rect, "<b><color=red>~~~ DEBUG ~~~</color></b>");
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);
            for (int i = 0; i < Messages.Count; i++)
            {
                string log = Messages[i];
                GUI.contentColor = Color.white;
                GUILayout.Label(log);
                scrollPosition.y = Mathf.Infinity;
            }
            GUILayout.EndScrollView();
            GUI.contentColor = Color.white;
            GUILayout.BeginHorizontal();
            GUILayout.EndHorizontal();
        }

        public static void addDebug(string msg)
        {
            try
            {
                if (Messages.Count > 29)
                {
                    Messages.RemoveAt(30);
                }
                Messages.Add("<b>[" + DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "] " + msg + "</b>");
            }
            catch (Exception)
            {

            }
        }

        public static Vector2 scrollPosition;

        private static IList<string> Messages;
    }
}
