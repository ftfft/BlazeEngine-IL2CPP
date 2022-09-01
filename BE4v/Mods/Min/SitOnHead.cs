using UnityEngine;
using VRC;
using BE4v.Mods.Core;
using VRC.SDK3.Dynamics.Contact.Components;
using CustomQuickMenu.Menus;

namespace BE4v.Mods.Min
{
    public class SitOnHead : IUpdate
    {
        // Thanks MagnaLuna#7488
        public void Update()
        {
            if (selectPlayer == null) return;
            VRCPlayer player = VRCPlayer.Instance;
            if (player == null) return;
            if (player == selectPlayer)
            {
                SelectUser = null;
                return;
            }
            if (selectPlayer.gameObject == null)
            {
                SelectUser = null;
                return;
            }
            player.GetComponent<Collider>().enabled = false;
            offsetBox.transform.position = selectPlayer.avatarAnimator.GetBoneTransform(HumanBodyBones.Head).position;
        }

        public static VRCPlayer SelectUser
        {
            get
            {
                return selectPlayer;
            }
            set
            {
                if (VRCPlayer.Instance == null) return;
                Transform playerTransform = VRCPlayer.Instance.transform;
                if (value == null)
                {
                    Collider collider = VRCPlayer.Instance.GetComponent<Collider>();
                    if (collider != null)
                        collider.enabled = true;
                    if (SelectedMenu.SitOnHeadToggle.button != null)
                        SelectedMenu.SitOnHeadToggle.button._Text = "Sit on";
                }
                else
                {
                    if (offsetBox?.gameObject == null)
                    {
                        offsetBox = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        offsetBox.GetComponent<Collider>()?.Destroy();
                        offsetBox.GetComponent<Renderer>()?.Destroy();
                        UnityEngine.Object.DontDestroyOnLoad(offsetBox);
                    }
                    playerTransform.position = offsetBox.transform.position;
                    playerTransform.SetParent(offsetBox.transform);
                    offsetBox.transform.position = value.avatarAnimator.GetBoneTransform(HumanBodyBones.Head).position;
                    if (SelectedMenu.SitOnHeadToggle.button != null)
                        SelectedMenu.SitOnHeadToggle.button._Text = "Get up";
                }
                selectPlayer = value;
            }
        }

        private static GameObject offsetBox = null;

        private static VRCPlayer selectPlayer = null;
    }
}
