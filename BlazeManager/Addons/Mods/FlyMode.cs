using System;
using UnityEngine;
using VRC;

namespace Addons.Mods
{
    public static class FlyMode
    {
        public static void Toggle_Enable()
        {
            bool toggle = !BlazeManager.GetForPlayer<bool>("Fly Enable");
            BlazeManager.SetForPlayer("Fly Enable", toggle);
            RefreshStatus();
            Player.Instance.GetComponent<Collider>().enabled = !toggle;
            Physics.gravity = toggle ? Vector3.zero : new Vector3(0, -9.5f, 0);
        }
        public static void Toggle_Mode()
        {
            bool toggle = !BlazeManager.GetForPlayer<bool>("Fly Type");
            BlazeManager.SetForPlayer("Fly Type", toggle);
            RefreshStatus();
        }

        public static void RefreshStatus()
        {
            bool toggle1 = BlazeManager.GetForPlayer<bool>("Fly Enable");
            BlazeManagerMenu.Main.togglerList["Fly Enabled"].btnOn.SetActive(toggle1);
            BlazeManagerMenu.Main.togglerList["Fly Enabled"].btnOff.SetActive(!toggle1);

            bool toggle2 = BlazeManager.GetForPlayer<bool>("Fly Type");
            BlazeManagerMenu.Main.togglerList["Fly Mode"].btnOn.SetActive(toggle2);
            BlazeManagerMenu.Main.togglerList["Fly Mode"].btnOff.SetActive(!toggle2);
        }

        public static void Update()
        {
            if (!BlazeManager.GetForPlayer<bool>("Fly Enable")) return;
            Player player = Player.Instance;
            if (player == null) return;
            if (BlazeManager.GetForPlayer<bool>("Fly Type"))
            {
                Transform transform = Camera.main.transform;
                player.GetComponent<Collider>().enabled = false;
                float MultiSpeed = Input.GetKey(KeyCode.LeftShift) ? 2.5F : 1F;
                float calcTimes = MultiSpeed * Time.deltaTime * fNoClipSpeed;
                Vector3 moveControl = Player.Instance.transform.position;
                Vector3 moveControl2 = moveControl;
                // NoClipMode
                if (Input.GetKey(KeyCode.E))
                {
                    moveControl += Vector3.up * calcTimes;
                }
                else if (Input.GetKey(KeyCode.Q))
                {
                    moveControl -= Vector3.up * calcTimes;
                }

                #region Vertical
                float fVertical = Input.GetAxis("Vertical");
                if (Math.Abs(fVertical) > 0f) moveControl += calcTimes * transform.forward * fVertical;
                #endregion
                #region Horizontal
                float fHorizontal = Input.GetAxis("Horizontal");
                if (Math.Abs(fHorizontal) > 0f) moveControl += calcTimes * transform.right * fHorizontal;
                #endregion
                if (moveControl != moveControl2)
                    UserUtils.TeleportTo(moveControl);
            }
            else
            {
                player.GetComponent<Collider>().enabled = true;
                if (Input.GetKey(KeyCode.Q))
                {
                    Physics.gravity = Vector3.up * -9.5f;
                    iCountBalance = 10;
                }
                else if (Input.GetKey(KeyCode.E))
                {
                    Physics.gravity = Vector3.up * 9.5f;
                    iCountBalance = 10;
                }
                else if (iCountBalance >= 0)
                {
                    CharacterController controller = player.GetComponent<CharacterController>();
                    if (controller.velocity[1] != 0.0f)
                    {
                        iCountBalance = 10;
                        Physics.gravity = new Vector3(0, -controller.velocity[1] * 2.0f);
                    }
                    else
                    {
                        iCountBalance = -1;
                        Physics.gravity = Vector3.zero;
                    }
                }
            }
        }

        // NoClip Speed [Default: 4.0f]
        public static float fNoClipSpeed = 4.0f;

        public static int iCountBalance = -1;
    }
}