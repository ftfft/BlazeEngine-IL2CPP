using UnityEngine;
using VRC;
using BE4v.Mods.Core;

namespace BE4v.Mods.Min
{
    public class SitOnHead : IUpdate
    {
        // Thanks MagnaLuna#7488
        public void Update()
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
                if (Player.Instance == null) return;
                Transform playerTransform = VRCPlayer.Instance.transform;
                if (value == null)
                {
                    Collider collider = Player.Instance.GetComponent<Collider>();
                    if (collider != null)
                        collider.enabled = true;
                    playerTransform.SetParent(null);
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
                    offsetBox.transform.position = value.transform.position;
                }
                selectPlayer = value;
            }
        }

        private static GameObject offsetBox = null;

        private static VRCPlayer selectPlayer = null;
    }
}
