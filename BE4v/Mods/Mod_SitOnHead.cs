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
            if (player == selectPlayer)
            {
                SelectUser = null;
                return;
            }
            Transform boneTransform = selectPlayer.avatarAnimator?.GetBoneTransform(HumanBodyBones.Head);
            if (boneTransform == null) return;
            player.GetComponent<Collider>().enabled = false;
            offsetBox.transform.position = boneTransform.position;
        }

        public static VRCPlayer SelectUser
        {
            get
            {
                return selectPlayer;
            }
            set
            {
                if (value == null && Player.Instance != null)
                {
                    Player.Instance.GetComponent<Collider>().enabled = true;
                }
                if (offsetBox?.transform == null)
                    offsetBox = null;
                if (offsetBox?.gameObject == null && value != null)
                {
                    offsetBox = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    offsetBox.GetComponent<Collider>()?.Destroy();
                    offsetBox.GetComponent<Renderer>()?.Destroy();
                }
                if (value == null)
                {
                    VRCPlayer.Instance.transform.SetParent(null);
                }
                else
                {
                    VRCPlayer.Instance.transform.position = offsetBox.transform.position;
                    VRCPlayer.Instance.transform.SetParent(offsetBox.transform);
                    offsetBox.transform.position = value.transform.position;
                }
                selectPlayer = value;
            }
        }

        private static GameObject offsetBox = null;

        private static VRCPlayer selectPlayer = null;
    }
}
