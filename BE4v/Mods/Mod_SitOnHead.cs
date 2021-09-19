using BE4v.MenuEdit;
using System;
using UnityEngine;
using VRC;
using VRC.Animation;

namespace BE4v.Mods
{
    public static class Mod_SitOnHead
    {
        // Thanks MagnaLuna#7488
        public static void Update()
        {
            Player player = Player.Instance;
            if (player == null) return;
            if (selectPlayer == null || selectPlayer.avatarAnimator == null) return;
            Transform boneTransform = selectPlayer.avatarAnimator?.GetBoneTransform(HumanBodyBones.Head);
            if (boneTransform == null) return;
            player.transform.position = boneTransform.position;
        }

        public static VRCPlayer selectPlayer = null;
    }
}
