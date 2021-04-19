using BE4v.MenuEdit;
using BE4v.Mods;
using System;
using UnityEngine;
using VRC;

namespace BE4v.Mods
{
    public static class Mod_SpeedHack
    {
        /*
        public static void Toggle_Enable_SpeedHack()
        {
            bool toggle = !BlazeManager.GetForPlayer<bool>("SpeedHack");
            BlazeManager.SetForPlayer("SpeedHack", toggle);
            RefreshStatus_SpeedHack();
        }

        public static void RefreshStatus_SpeedHack()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("SpeedHack");
            BlazeManagerMenu.Main.togglerList["SpeedHack"].SetToggleToOn(toggle, false);
        }
        public static void Toggle_Enable_JumpHack()
        {
            bool toggle = !BlazeManager.GetForPlayer<bool>("JumpHack");
            BlazeManager.SetForPlayer("JumpHack", toggle);
            RefreshStatus_JumpHack();
        }

        public static void RefreshStatus_JumpHack()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("JumpHack");
            BlazeManagerMenu.Main.togglerList["JumpHack"].SetToggleToOn(toggle, false);
        }
        */
        public static void Toggle()
        {
            Status.isSpeedHack = !Status.isSpeedHack;
            BE4V_QuickUIMenu.OnClick_SHToggle_Refresh();
        }

        public static void Update()
        {
            CharacterController controller = Player.Instance.GetComponent<CharacterController>();
            Vector3 vector = Vector3.zero;
            Vector3 velocity = controller.velocity;
            if (Status.isSpeedHack)
            {
                vector[0] = velocity.x / 200 * fSpeed;
                vector[2] = velocity.z / 200 * fSpeed;
            }
            /*
            if (BlazeManager.GetForPlayer<bool>("JumpHack"))
            {
                vector[1] = controller.velocity.y / 200 * fNoClipSpeed * 0.1f;
            }
            */
            if (vector != Vector3.zero)
                controller.Move(vector);
        }

        public static float fSpeed = 4.0f;
    }
}