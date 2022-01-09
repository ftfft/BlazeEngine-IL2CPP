using BE4v.MenuEdit;
using System;
using UnityEngine;
using VRC;
using VRC.Animation;

namespace BE4v.Mods
{
    public static class Mod_GlowESP
    {
        public static void Toggle()
        {
            Status.isGlowESP = !Status.isGlowESP;
            BE4V_MainMenu.GlowESP.Refresh();
        }
    }
}
