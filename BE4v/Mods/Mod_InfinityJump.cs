using BE4v.MenuEdit;
using System;
using UnityEngine;
using VRC;
using VRC.Animation;

namespace BE4v.Mods
{
    public static class Mod_InfinityJump
    {
        private static float fPressedLast = 0f;
        public static void Toggle()
        {
            Status.isInfinityJump = !Status.isInfinityJump;
            ClickClass_InfinityJump.OnClick_InfinityJumpToggle_Refresh();
        }

        public static void Update()
        {
            VRCPlayer player = VRCPlayer.Instance;
            if (player == null || player.GetComponent<CharacterController>()?.isGrounded != false) return;
            var jump = player.GetComponent<GamelikeInputController>()?.inJump;
            if (jump != null)
            {
                if (jump.button)
                {
                    float fPressed = jump.timePressed;
                    if (fPressed != fPressedLast)
                    {
                        OnJump();
                        fPressedLast = fPressed;
                    }
                }
            }
        }

        public static void OnJump()
        {
            VRCMotionState motionState = VRCPlayer.Instance.GetComponent<VRCMotionState>();
            if (motionState == null) return;
            Vector3 vector = motionState.PlayerVelocity;
            vector.y = motionState.jumpPower;
            motionState.PlayerVelocity = vector;
        }
    }
}
