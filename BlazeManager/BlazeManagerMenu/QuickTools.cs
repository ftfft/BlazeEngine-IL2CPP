using System;
using UnityEngine;
using VRC.Core;
using CustomQuickMenu;

namespace BlazeManagerMenu
{
    internal static class QuickTools
    {
        internal static void SelectUserAPI(APIUser user)
        {
            QuickMenu.Instance.SelectedUser = user;
            QuickMenu.Instance.SetMenuIndex(3);
        }

        internal static Transform quickTransform { get; set; }
    }
}
