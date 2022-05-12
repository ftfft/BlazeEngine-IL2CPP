using UnityEngine;
using VRC.Animation;
using BE4v.Mods.Core;

namespace BE4v.Mods.Min
{
    public class InfinityJump : IUpdate
    {
        private static float fPressedLast = 0f;
        public void Update()
        {
            if (!Status.isInfinityJump && !Status.isBHop) return;
            VRCPlayer player = VRCPlayer.Instance;
            if (player == null) return;
            var jump = player.GetComponent<GamelikeInputController>()?.inJump;
            if (jump != null)
            {
                if (jump.button)
                {
                    CharacterController controller = player.GetComponent<CharacterController>();
                    if (controller == null) return;
                    float fPressed = jump.timePressed;
                    if (!controller.isGrounded)
                    {
                        if (fPressed != fPressedLast && Status.isInfinityJump)
                        {
                            OnJump(player);
                        }
                    }
                    else
                    {
                        if (fPressed == fPressedLast && Status.isBHop)
                        {
                            OnJump(player);
                        }
                    }
                    fPressedLast = fPressed;
                }
            }
        }

        public static void OnJump(VRCPlayer player)
        {
            VRCMotionState motionState = player.GetComponent<VRCMotionState>();
            if (motionState == null) return;
            Vector3 vector = motionState.PlayerVelocity;
            vector.y = motionState.jumpPower;
            motionState.PlayerVelocity = vector;
        }
    }
}
