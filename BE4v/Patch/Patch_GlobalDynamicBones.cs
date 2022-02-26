﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE4v.MenuEdit;
using BE4v.Mods;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using UnityEngine;

namespace BE4v.Patch
{
    public delegate void _VRC_Player_Update(IntPtr instance);
    public static class Patch_GlobalDynamicBones
    {
        public static void Toggle()
        {
            Status.isGlobalDynamicBones = !Status.isGlobalDynamicBones;
            ClickClass_GlobalDynamicBones.OnClick_GlobalDynamicBones_Refresh();
        }

        public static void Start()
        {
            try
            {
                IL2Method method = VRC.Player.Instance_Class.GetMethod("Update");
                if (method == null)
                    throw new Exception();

                patch = new IL2Patch(method, (_VRC_Player_Update)VRC_Player_Update);
                _delegateVRC_Player_Update = patch.CreateDelegate<_VRC_Player_Update>();
                "Global Dynamic Bones".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "Global Dynamic Bones".RedPrefix(TMessage.BadPatch);
            }
        }

        public static int iLastPlayer = 0;
        public static void VRC_Player_Update(IntPtr instance)
        {
            if (instance == IntPtr.Zero)
                return;

            _delegateVRC_Player_Update(instance);

            if (!Status.isGlobalDynamicBones)
                return;

            if (currentPlayer == null)
            {
                timeToUpdate = 5f;
                activePlayers.Clear();
                currentPlayer = VRC.Player.Instance;
                return;
            }

            if (timeToUpdate > 0f)
            {
                timeToUpdate -= Time.deltaTime;
                currentPlayer = VRC.Player.Instance;
                return;
            }

            VRC.Player pPlayer = new VRC.Player(instance);
            IL2Photon.Realtime.Player photon = pPlayer?.PhotonPlayer;
            if (photon == null)
                return;

            if (iLastPlayer == photon.ActorNumber)
                return;

            iLastPlayer = photon.ActorNumber;

            if (currentPlayer.ptr == instance)
            {
                myColliders = GetHandColliders(currentPlayer.Components);
                myBones = currentPlayer.Components.GetComponentsInChildren<DynamicBone>(true);
                if (Input.GetKey(KeyCode.G))
                    Console.WriteLine(string.Format("DynamicBoneSync: MyDynamicBones: {0} + MyColliders: {1}", myBones.Length, myColliders.Length));
                return;
            }
            if (myBones.Length == 0 && myColliders.Length == 0) return;

            float num = maxDistance * maxDistance;
            Transform transform = currentPlayer.Components.avatarGameObject.transform;
            Transform transformPlayer = pPlayer.transform;
            if (transform == null || transformPlayer == null)
                return;

            if ((transformPlayer.position - transform.position).sqrMagnitude < num)
            {
                if (!activePlayers.ContainsKey(instance))
                {
                    globalSyncInfo gsi = new globalSyncInfo();
                    gsi.bones = pPlayer.Components.GetComponentsInChildren<DynamicBone>(true);
                    gsi.colliders = GetHandColliders(pPlayer.Components);
                    activePlayers.Add(instance, gsi);

                    ApplyColliders(gsi.bones, myColliders);
                    ApplyColliders(myBones, gsi.colliders);
                }
            }
            else if (activePlayers.ContainsKey(instance))
            {
                globalSyncInfo gsi = activePlayers[instance];
                activePlayers.Remove(instance);
                RemoveColliders(gsi.bones, myColliders);
                RemoveColliders(myBones, gsi.colliders);
            }

        }

        public static void ApplyColliders(DynamicBone[] bones, DynamicBoneCollider[] colliders)
        {
            if (bones.Length == 0 || colliders.Length == 0) return;
            for (int i = 0; i < bones.Length; i++)
            {
                foreach (var collider in colliders)
                {
                    if (!bones[i].m_Colliders.IL2Contains(collider.ptr))
                        bones[i].m_Colliders.IL2Add(collider.ptr);
                }
            }
        }

        public static void RemoveColliders(DynamicBone[] bones, DynamicBoneCollider[] colliders)
        {
            if (bones.Length == 0 || colliders.Length == 0) return;
            for (int i = 0; i < bones.Length; i++)
            {
                foreach (var collider in colliders)
                {
                    if (bones[i].m_Colliders.IL2Contains(collider.ptr))
                        bones[i].m_Colliders.IL2Remove(collider.ptr);
                }
            }
        }

        public static DynamicBoneCollider[] GetHandColliders(VRCPlayer avatar)
        {
            if (avatar?.avatarAnimator == null)
            {
                return new DynamicBoneCollider[0];
            }
            Transform boneTransform = avatar.avatarAnimator.GetBoneTransform(HumanBodyBones.LeftHand);
            List<DynamicBoneCollider> dynamicBoneColliders = new List<DynamicBoneCollider>();
            DynamicBoneCollider[] componentsInChildren = boneTransform.GetComponentsInChildren<DynamicBoneCollider>(true);
            for (int i = 0; i < componentsInChildren.Length; i++)
            {
                if (componentsInChildren[i].m_Bound == DynamicBoneCollider.Bound.Outside)
                    dynamicBoneColliders.Add(componentsInChildren[i]);
            }
            boneTransform = avatar.avatarAnimator.GetBoneTransform(HumanBodyBones.RightHand);
            componentsInChildren = boneTransform.GetComponentsInChildren<DynamicBoneCollider>(true);
            for (int i = 0; i < componentsInChildren.Length; i++)
            {
                if (componentsInChildren[i].m_Bound == DynamicBoneCollider.Bound.Outside)
                    dynamicBoneColliders.Add(componentsInChildren[i]);
            }
            return dynamicBoneColliders.ToArray();
        }
        public class globalSyncInfo
        {
            public DynamicBone[] bones = new DynamicBone[0];

            public DynamicBoneCollider[] colliders = new DynamicBoneCollider[0];
        }

        public static DynamicBone[] myBones = new DynamicBone[0];

        public static DynamicBoneCollider[] myColliders = new DynamicBoneCollider[0];

        public static Dictionary<IntPtr, globalSyncInfo> activePlayers = new Dictionary<IntPtr, globalSyncInfo>();

        public static VRC.Player currentPlayer;

        public static float timeToUpdate = 0f;

        internal static float maxDistance = 2f;

        public static IL2Patch patch;

        public static _VRC_Player_Update _delegateVRC_Player_Update;
    }
}
