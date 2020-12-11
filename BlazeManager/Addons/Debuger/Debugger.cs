using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Addons.Mods.UI;

namespace Addons.Debuger
{
    public static class Debugger
    {
        public static void AddMessage(string message)
        {
            if (messages.Count > 200)
            {
                messages.RemoveAt(messages.Count - 1);
            }
            messages.Insert(0, message);
            RefreshDebugger();
        }
        public static void ClearMessages()
        {
            messages.Clear();
            RefreshDebugger();
        }

        public static void RefreshDebugger()
        {
            if (Debug.Instance == null)
                return;

            string message = string.Empty;
            foreach(var m in messages)
            {
                message += m;
            }
            Debug.SetMessage(message);
        }


        public static void Enable()
        {
            if (Debug.Instance == null)
                return;
            new Debug().Show();
            RefreshDebugger();
        }

        private readonly static List<string> messages = new List<string>();
    }
}
