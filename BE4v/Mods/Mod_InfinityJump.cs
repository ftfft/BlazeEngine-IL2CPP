﻿using BE4v.MenuEdit;
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
        
        public static void Toggle_Bhop()
        {
            Status.isBHop = !Status.isBHop;
            ClickClass_BunnyHop.OnClick_BunnyHopToggle_Refresh();
        }

        public static void Update(VRCPlayer player)
        {
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
                            OnJump();
                        }
                    }
                    else
                    {
                        if (fPressed == fPressedLast && Status.isBHop)
                        {
                            OnJump();
                        }
                    }
                    fPressedLast = fPressed;
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
