using BE4v.MenuEdit;
using System;
using UnityEngine;
using VRC;

namespace BE4v.Mods
{
    public static class Mod_Fly
    {
        public static void Toggle()
        {
            Status.isFly = !Status.isFly;
            if (!Status.isFly)
            {
                Physics.gravity = Vector3.up * -9.5f;
            }
            else
            {
                Physics.gravity = Vector3.zero;
            }
            BE4V_QuickUIMenu.OnClick_FlyToggle_Refresh();
        }

        public static void Update()
        {
            Player player = Player.Instance;
            if (player == null) return;
            /*
            if (true != false)
            {
                Transform transform = Camera.main.transform;
                player.GetComponent<Collider>().enabled = false;
                float MultiSpeed = Input.GetKey(KeyCode.LeftShift) ? 2.5F : 1F;
                float calcTimes = MultiSpeed * Time.deltaTime * fNoClipSpeed * (BlazeManager.GetForPlayer<bool>("SpeedHack") ? MultiHack.fNoClipSpeed : 1f);
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
            */
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
            //}
        }

        // NoClip Speed [Default: 4.0f]
        public static float fNoClipSpeed = 4.0f;

        public static int iCountBalance = -1;
    }
}
