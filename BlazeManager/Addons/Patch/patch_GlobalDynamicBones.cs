﻿using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeIL.il2generic;
using UnityEngine;
using UnityEngine.UI;
using BlazeTools;

namespace Addons.Patch
{
    public delegate void _VRC_Player_Update(IntPtr instance);
    public static class patch_GlobalDynamicBones
    {
        public static void Toggle_Enable()
        {
            BlazeManager.SetForPlayer("GlobalDynamicBones", !BlazeManager.GetForPlayer<bool>("GlobalDynamicBones"));
            RefreshStatus();
        }

        public static void RefreshStatus()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("GlobalDynamicBones");
            BlazeManagerMenu.Main.togglerList["GlobalDynamicBones"].btnOn.SetActive(toggle);
            BlazeManagerMenu.Main.togglerList["GlobalDynamicBones"].btnOff.SetActive(!toggle);
            currentPlayer = VRC.Player.Instance;
            timeToUpdate = 5f;
        }

        public static void Start()
        {
            IL2Method method = null;
            try
            {
                method = VRC.Player.Instance_Class.GetMethod("Update");
                if (method == null)
                    throw new Exception();

                pVRC_Player_Update = IL2Ch.Patch(method, (_VRC_Player_Update)VRC_Player_Update);
                ConSole.Success("Patch: Global Dynamic Bones");

            }
            catch
            {
                ConSole.Error("Patch: Global Dynamic Bones");
            }
        }

        public static int iLastPlayer = 0;
        public static void VRC_Player_Update(IntPtr ptrInstance)
        {
            if (BlazeAttack.PhotonUtils.raise209_status)
                return;

            if (ptrInstance == IntPtr.Zero)
                return;

            pVRC_Player_Update.InvokeOriginal(ptrInstance);

            if (!BlazeManager.GetForPlayer<bool>("GlobalDynamicBones"))
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

            VRC.Player pPlayer = new VRC.Player(ptrInstance);
            PhotonPlayer photon = pPlayer?.photonPlayer;
            if (photon == null)
                return;

            if (iLastPlayer == photon.ID)
                return;

            iLastPlayer = photon.ID;

            if (currentPlayer.ptr == ptrInstance)
            {
                myColliders = GetHandColliders(currentPlayer.vrcPlayer);
                myBones = currentPlayer.vrcPlayer.GetComponentsInChildren<DynamicBone>(true);
                if (Input.GetKey(KeyCode.G))
                    Console.WriteLine(string.Format("DynamicBoneSync: MyDynamicBones: {0} + MyColliders: {1}", myBones.Length, myColliders.Length));
                return;
            }
            if (myBones.Length == 0 && myColliders.Length == 0) return;

            float num = maxDistance * maxDistance;
            Vector3 position = currentPlayer.vrcPlayer.avatarGameObject.transform.position;

            if ((pPlayer.transform.position - position).sqrMagnitude < num)
            {
                if (!activePlayers.ContainsKey(ptrInstance))
                {
                    globalSyncInfo gsi = new globalSyncInfo();
                    gsi.bones = pPlayer.vrcPlayer.GetComponentsInChildren<DynamicBone>(true);
                    gsi.colliders = GetHandColliders(pPlayer.vrcPlayer);
                    activePlayers.Add(ptrInstance, gsi);
                    
                    ApplyColliders(gsi.bones, myColliders);
                    ApplyColliders(myBones, gsi.colliders);
                }
            }
            else if (activePlayers.ContainsKey(ptrInstance))
            {
                globalSyncInfo gsi = activePlayers[ptrInstance];
                activePlayers.Remove(ptrInstance);
                RemoveColliders(gsi.bones, myColliders);
                RemoveColliders(myBones, gsi.colliders);
            }

        }

        public static void ApplyColliders(DynamicBone[] bones, DynamicBoneCollider[] colliders)
        {
            if (bones.Length == 0 || colliders.Length == 0) return;
            for (int i = 0; i < bones.Length; i++)
            {
                foreach (var collider in colliders.Where(x => !bones[i].m_Colliders.Contains(x.ptr)))
                    bones[i].m_Colliders.Add(collider.ptr);
            }
        }

        public static void RemoveColliders(DynamicBone[] bones, DynamicBoneCollider[] colliders)
        {
            if (bones.Length == 0 || colliders.Length == 0) return;
            for (int i = 0; i < bones.Length; i++)
            {
                foreach (var collider in colliders.Where(x => bones[i].m_Colliders.Contains(x.ptr)))
                    bones[i].m_Colliders.Remove(collider.ptr);
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
            for(int i=0;i< componentsInChildren.Length;i++)
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

        public static IL2Patch pVRC_Player_Update;
    }
}
