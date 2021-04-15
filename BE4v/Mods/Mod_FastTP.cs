using BE4v.MenuEdit;
using System;
using UnityEngine;
using VRC;

namespace BE4v.Mods
{
    public static class Mod_FastTP
    {
        public static void Teleport()
        {
            Player player = Player.Instance;
            if (player == null) return;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                player.transform.position = hit.point;
        }
    }
}
