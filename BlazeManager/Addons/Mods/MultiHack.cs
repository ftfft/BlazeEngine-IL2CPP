using System;
using UnityEngine;
using VRC;

namespace Addons.Mods
{
    public static class MultiHack
    {
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

        public static void Update()
        {
            CharacterController controller = Player.Instance.GetComponent<CharacterController>();
            Vector3 vector = Vector3.zero;
            if (BlazeManager.GetForPlayer<bool>("SpeedHack"))
            {
                vector[0] = controller.velocity.x / 200 * fNoClipSpeed;
                vector[2] = controller.velocity.z / 200 * fNoClipSpeed;
            }
            if (BlazeManager.GetForPlayer<bool>("JumpHack"))
            {
                vector[1] = controller.velocity.y / 200 * fNoClipSpeed * 0.1f;
            }
            if (vector != Vector3.zero)
                controller.Move(vector);
        }

        public static float fNoClipSpeed = 4.0f;
    }
}