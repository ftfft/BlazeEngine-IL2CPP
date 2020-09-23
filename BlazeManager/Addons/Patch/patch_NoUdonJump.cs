using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDisasm;
using SharpDisasm.Udis86;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeTools;
using VRC;
using UnityEngine;

namespace Addons.Patch
{
    public delegate void _PlayerModComponentJump_Update();
    public static class patch_NoUdonJump
    {
        public static void Start()
        {
            try
            {
                IL2Method method = Assemblies.a["Assembly-CSharp"].GetClass("PlayerModComponentJump").GetMethod("Update");

                IL2Ch.Patch(method, (_PlayerModComponentJump_Update)PlayerModComponentJump_Update);
                ConSole.Success("Patch: No Udon Jump");
            }
            catch
            {
                ConSole.Error("Patch: No Udon Jump");
            }
        }

        public static void PlayerModComponentJump_Update()
        {
            Console.WriteLine("1");
            Player player = Player.Instance;
            CharacterController controller = player?.GetComponent<CharacterController>();
            if (controller == null) return;
            if (controller.isGrounded)
            {
                if (playerVelocity.y < 0)
                    playerVelocity.y = 0f;

                if (Input.GetButtonDown("Jump"))
                    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);

        }

        public static Vector3 playerVelocity = new Vector3(0,0,0);
        public static float gravityValue = -9.5f;
        public static float jumpHeight = 3f;
    }
}
