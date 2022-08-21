using UnityEngine;
using VRC;
using BE4v.Mods.Core;
using VRC.SDK3.Dynamics.Contact.Components;

namespace BE4v.Mods.Min
{
    public class SitOnHead : IUpdate
    {
        // Thanks MagnaLuna#7488
        public void Update()
        {
            Player player = Player.Instance;
            if (player == null) return;
            if (selectPlayer == null) return;
            if (player == selectPlayer)
            {
                SelectUser = null;
                return;
            }

            VRCContactSender[] components = selectPlayer.GetComponentsInChildren<VRCContactSender>(true);
            foreach(var component in components)
            {
                if (component.gameObject.name.ToLower().Contains("head"))
                {
                    player.GetComponent<Collider>().enabled = false;
                    offsetBox.transform.position = component.position;
                }
            }
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
