﻿using System;
using System.Collections.Generic;
using IL2CPP_Core.Objects;
using UnityEngine;
using VRC.Core;
using BE4v.Mods;
using BE4v.Patch.Core;
using BE4v.Utils;
using VRC.SDKBase;
using VRC.SDK3.Components;

namespace BE4v.Patch.List
{
    public class OnPlayerUpdateSync : IPatch
    {
        public delegate void _VRC_Player_Update(IntPtr instance);
        public void Start()
        {
            IL2Method method = VRC.Player.Instance_Class.GetMethod("Update");
            if (method == null)
                throw new NullReferenceException();

            VRC_PlayerUpdate = PatchUtils.FastPatch<_VRC_Player_Update>(method, VRC_Player_Update);
        }

        public static void VRC_Player_Update(IntPtr instance)
        {
            if (instance == IntPtr.Zero) return;
            VRC_PlayerUpdate(instance);
            if (PickupOrbit_VRC_Player_Pointer != IntPtr.Zero)
            {
                if (PickupOrbit_VRC_Player_Pointer == instance)
                {
                    VRCPickup[] pickups = UnityEngine.Object.FindObjectsOfType<VRCPickup>();

                    float degrees = 360 / pickups.Length;

                    for (int i = 0; i < pickups.Length; i++)
                    {
                        VRC_Pickup pickup = pickups[i];

                        VRCPlayerApi localPlayerApi = Networking.LocalPlayer;
                        if (Networking.GetOwner(pickup.gameObject) != localPlayerApi)
                            Networking.SetOwner(localPlayerApi, pickup.gameObject);

                        pickup.transform.position = new VRC.Player(instance).gameObject.transform.position + new Vector3(Mathf.Sin(Time.time * PickupOrbit.speed + degrees * i) * PickupOrbit.distance, PickupOrbit.height, Mathf.Cos(Time.time * PickupOrbit.speed + degrees * i) * PickupOrbit.distance);
                    }
                }
            }
            if (Mods.Min.SitOnHead.VRC_Player_Pointer != IntPtr.Zero)
            {
                if (Mods.Min.SitOnHead.VRC_Player_Pointer == instance)
                {
                    VRC.Player player = VRC.Player.Instance;
                    player.GetComponent<Collider>().enabled = false;
                    if (Status.SitOnType == 0)
                    {
                        player.transform.position = new VRC.Player(instance).Components.avatarAnimator.GetBoneTransform(HumanBodyBones.Head).position;
                    }
                    else if (Status.SitOnType == 1)
                    {
                        player.transform.position = new VRC.Player(instance).Components.avatarAnimator.GetBoneTransform(HumanBodyBones.LeftHand).position;
                    }
                    else
                    {
                        player.transform.position = new VRC.Player(instance).Components.avatarAnimator.GetBoneTransform(HumanBodyBones.RightHand).position;
                    }
                }
            }
            if (Status.isNamePlatesGUI)
            {
                if (instance != VRC.Player.Instance.Pointer)
                {
                    VRC.Player player = new VRC.Player(instance);
                    // "Player Nameplate"
                    Transform transformNamePlate = player.transform.Find("Player Nameplate");
                    if (transformNamePlate != null)
                    {
                        Transform transformGUINamePlate = transformNamePlate.Find("BE4vNamePlate");
                        if (transformGUINamePlate == null)
                        {
                            // Add func for GUI
                        }
                        if (transformGUINamePlate != null)
                        {
                            // Update Func for GUI ...
                        }
                    }
                }
            }
        }

        public static class PickupOrbit
        {
            public static float speed = 1f;

            public static float distance = 1f;

            public static float height = 1f;
        }

        public static IntPtr PickupOrbit_VRC_Player_Pointer = IntPtr.Zero;

        public static _VRC_Player_Update VRC_PlayerUpdate;
    }
}
