using System;
using System.Linq;
using System.Collections.Generic;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;
using VRC.Core;
using VRC.SDKBase;
using SharpDisasm;
using SharpDisasm.Udis86;
using BlazeIL.cpp2il;
using BlazeIL.cpp2il.IL;

namespace VRC
{
    public class Player : Component
    {
        public Player(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static Player Instance
        {
            get
            {
                if (!properties.ContainsKey(nameof(Instance)))
                {
                    properties.Add(nameof(Instance), Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == Instance_Class.FullName));
                    if (!properties.ContainsKey(nameof(Instance)))
                        return null;
                }

                return properties[nameof(Instance)].GetGetMethod().Invoke()?.unbox<Player>();
            }
        }

        public void UpdateModeration()
        {
            if (!methods.ContainsKey(nameof(UpdateModeration)))
                return;

            methods[nameof(UpdateModeration)].Invoke(ptr);
        }

        public VRCSDK2.VRC_PlayerApi apiPlayer
        {
            get
            {
                if (!properties.ContainsKey(nameof(apiPlayer)))
                {
                    properties.Add(nameof(apiPlayer), Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == VRCSDK2.VRC_PlayerApi.Instance_Class.FullName));
                    if (!properties.ContainsKey(nameof(apiPlayer)))
                        return null;
                }

                return properties[nameof(apiPlayer)].GetGetMethod().Invoke(ptr)?.unbox<VRCSDK2.VRC_PlayerApi>();
            }
        }

        public APIUser apiuser
        {
            get
            {
                if (!properties.ContainsKey(nameof(apiPlayer)))
                {
                    properties.Add(nameof(apiPlayer), Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == APIUser.Instance_Class.FullName));
                    if (!properties.ContainsKey(nameof(apiPlayer)))
                        return null;
                }

                return properties[nameof(apiuser)].GetGetMethod().Invoke(ptr)?.unbox<APIUser>();
            }
        }


        private static IL2Property propertyPlayerNet = null;
        public PlayerNet playerNet
        {
            get
            {
                if (!IL2Get.Property(PlayerNet.Instance_Class.FullName, Instance_Class, ref propertyPlayerNet, false))
                    return null;

                return propertyPlayerNet.GetGetMethod().Invoke(ptr)?.unbox<PlayerNet>();
            }
        }

        private static IL2Field fieldPhotonPlayer = null;
        public PhotonPlayer photonPlayer
        {
            get
            {
                if (!IL2Get.Field(PhotonPlayer.Instance_Class.FullName, Instance_Class, ref fieldPhotonPlayer, false))
                    return null;

                return fieldPhotonPlayer.GetValue(ptr)?.unbox<PhotonPlayer>();
            }
        }

        private static IL2Field fieldVrcPlayer = null;
        public VRCPlayer vrcPlayer
        {
            get
            {
                if (!IL2Get.Field(VRCPlayer.Instance_Class.FullName, Instance_Class, ref fieldVrcPlayer, false))
                    return null;

                return fieldVrcPlayer.GetValue(ptr)?.unbox<VRCPlayer>();
            }
        }

        private static IL2Field fieldUSpeaker = null;
        public USpeaker uSpeaker
        {
            get
            {
                if (!IL2Get.Field(USpeaker.Instance_Class.FullName, Instance_Class, ref fieldUSpeaker, false))
                    return null;

                return fieldUSpeaker.GetValue(ptr)?.unbox<USpeaker>();
            }
        }

        private static IL2Property propertyVRCPlayerApi = null;
        public VRCPlayerApi vrcPlayerApi
        {
            get
            {
                if (!IL2Get.Property(VRCPlayerApi.Instance_Class.FullName, Instance_Class, ref propertyVRCPlayerApi, false))
                    return null;

                return propertyVRCPlayerApi.GetGetMethod().Invoke(ptr).unbox<VRCPlayerApi>();
            }
        }

        private static IL2Property propertyIsFriend = null;
        unsafe public bool IsFriend
        {
            get
            {
                if (propertyIsFriend == null)
                {
                    var properties = Instance_Class.GetProperties().Where(x => x.GetGetMethod().ReturnType.Name == typeof(bool).FullName);
                    var methodAPI = APIUser.Instance_Class.GetProperty("friendIDs").GetGetMethod();
                    foreach (var prop in properties)
                    {
                        var method = prop.GetGetMethod();
                        if (method == null)
                            continue;

                        var disassembler = disasm.GetDisassembler(method);
                        var instructions = disassembler.Disassemble();
                        foreach(var @obj in ILCode.CastToILObject(instructions))
                        {
                            if (@obj.Type != ILType.method)
                                continue;

                            if (*(IntPtr*)methodAPI.ptr == @obj.ptr)
                            {
                                propertyIsFriend = prop;
                                break;
                            }
                        }
                        if (propertyIsFriend != null) break;
                    }
                    if (propertyIsFriend == null)
                        return false;
                }
                return propertyIsFriend.GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
            }
        }

        private static IL2Property propertyUserId = null;
        public string userId
        {
            get
            {
                if (propertyUserId == null)
                {
                    propertyUserId = Instance_Class.GetProperties().Where(x => x.GetGetMethod().ReturnType.Name == typeof(string).FullName).First(x => x.GetSetMethod() == null);
                    if (propertyUserId == null)
                        return default;
                }
                return propertyUserId.GetGetMethod().Invoke(ptr)?.Unbox<string>();
            }
        }
        public IntPtr userId_Pointer
        {
            get
            {
                if (propertyUserId == null)
                {
                    propertyUserId = Instance_Class.GetProperties().Where(x => x.GetGetMethod().ReturnType.Name == typeof(string).FullName).First(x => x.GetSetMethod() == null);
                    if (propertyUserId == null)
                        return IntPtr.Zero;
                }
                IL2Object @object = propertyUserId.GetGetMethod().Invoke(ptr);
                if (@object == null)
                    return IntPtr.Zero;

                return @object.ptr;
            }
        }

        public ulong steamId
        {
            get
            {
                PhotonPlayer photon = photonPlayer;
                if (photon == null) return 0U;
                IntPtr ptr = photon.hashtable[new IL2String("steamUserID").ptr];
                if (ptr == IntPtr.Zero) return 0U;
                return Convert.ToUInt64(new IL2String(ptr).ToString());
            }
        }

        public static IL2Method methodApplyMute = null;
        public void ApplyMute(bool status)
        {
            if (methodApplyMute == null)
                return;

            methodApplyMute.Invoke(ptr, status.MonoCast());
        }

        public static IL2Method methodApplyBlock = null;
        public void ApplyBlock(bool status)
        {
            if (methodApplyBlock == null)
                return;

            methodApplyBlock.Invoke(ptr, status.MonoCast());
        }

        static IL2Method methodToString = null;
        public override string ToString() => ToIL2String()?.ToString();
        public IL2String ToIL2String()
        {
            if (!IL2Get.Method("ToString", Instance_Class, ref methodToString))
                return default;

            IL2Object @object = methodToString.Invoke(ptr);
            if (@object == null)
                return null;

            return @object.unbox_ToString();
        }

        public static Dictionary<string, IL2Property> properties = new Dictionary<string, IL2Property>();
        public static Dictionary<string, IL2Method> methods = new Dictionary<string, IL2Method>();
        public static Dictionary<string, IL2Field> fields = new Dictionary<string, IL2Field>();

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("Player", "VRC");
    }
}
