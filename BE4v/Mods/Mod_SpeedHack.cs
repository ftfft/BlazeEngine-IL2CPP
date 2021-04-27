using BE4v.MenuEdit;
using UnityEngine;
using VRC;

namespace BE4v.Mods
{
    public static class Mod_SpeedHack
    {
        public static void Toggle()
        {
            Status.isSpeedHack = !Status.isSpeedHack;
            ClickClass_SpeedHack.OnClick_SHToggle_Refresh();
        }

        public static void Update()
        {
            CharacterController controller = Player.Instance.GetComponent<CharacterController>();
            Vector3 vector = Vector3.zero;
            Vector3 velocity = controller.velocity;
            if (Status.isSpeedHack)
            {
                vector[0] = velocity.x / 200 * Status.iSpeedHackSpeed;
                vector[2] = velocity.z / 200 * Status.iSpeedHackSpeed;
            }
            if (vector != Vector3.zero)
                controller.Move(vector);
        }
    }
}