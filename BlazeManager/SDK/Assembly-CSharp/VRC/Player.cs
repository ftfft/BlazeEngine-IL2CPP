using System;
using System.Linq;
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

        private static IL2Property propertyGetInstance = null;
        public static Player Instance
        {
            get
            {
                if (propertyGetInstance == null)
                {
                    propertyGetInstance = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == Instance_Class.FullName);
                    if (propertyGetInstance == null)
                        return null;
                }

                return propertyGetInstance.GetGetMethod().Invoke()?.Unbox<Player>();
            }
        }

        internal static IL2Method methodUpdateModeration = null;
        public void UpdateModeration()
        {
            if (methodUpdateModeration == null)
                return;

            methodUpdateModeration.Invoke(ptr);
        }

        private static IL2Property propertyApiPlayer = null;
        public VRCSDK2.VRC_PlayerApi apiPlayer
        {
            get
            {
                if (propertyApiPlayer == null)
                {
                    propertyApiPlayer = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == VRCSDK2.VRC_PlayerApi.Instance_Class.FullName);
                    if (propertyApiPlayer == null)
                        return null;
                }

                return propertyApiPlayer.GetGetMethod().Invoke(ptr)?.Unbox<VRCSDK2.VRC_PlayerApi>();
            }
        }

        private static IL2Property propertyApiuser = null;
        public APIUser apiuser
        {
            get
            {
                if (propertyApiuser == null)
                {
                    propertyApiuser = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == APIUser.Instance_Class.FullName);
                    if (propertyApiuser == null)
                        return null;
                }

                return propertyApiuser.GetGetMethod().Invoke(ptr)?.Unbox<APIUser>();
            }
        }


        private static IL2Property propertyPlayerNet = null;
        public PlayerNet playerNet
        {
            get
            {
                if (propertyPlayerNet == null)
                {
                    propertyPlayerNet = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == PlayerNet.Instance_Class.FullName);
                    if (propertyPlayerNet == null)
                        return default;
                }

                return propertyPlayerNet.GetGetMethod().Invoke(ptr)?.Unbox<PlayerNet>();
            }
        }

        private static IL2Field fieldPhotonPlayer = null;
        public PhotonPlayer photonPlayer
        {
            get
            {
                if (fieldPhotonPlayer == null)
                {
                    fieldPhotonPlayer = Instance_Class.GetFields().First(x => x.ReturnType.Name == PhotonPlayer.Instance_Class.FullName);
                    if (fieldPhotonPlayer == null)
                        return null;
                }

                return fieldPhotonPlayer.GetValue(ptr)?.Unbox<PhotonPlayer>();
            }
        }

        private static IL2Field fieldVrcPlayer = null;
        public VRCPlayer vrcPlayer
        {
            get
            {
                if (fieldVrcPlayer == null)
                {
                    fieldVrcPlayer = Instance_Class.GetFields().First(x => x.ReturnType.Name == VRCPlayer.Instance_Class.FullName);
                    if (fieldVrcPlayer == null)
                        return null;
                }

                return fieldVrcPlayer.GetValue(ptr)?.Unbox<VRCPlayer>();
            }
        }

        private static IL2Field fieldUSpeaker = null;
        public USpeaker uSpeaker
        {
            get
            {
                if (fieldUSpeaker == null)
                {
                    fieldUSpeaker = Instance_Class.GetFields().First(x => x.ReturnType.Name == USpeaker.Instance_Class.FullName);
                    if (fieldUSpeaker == null)
                        return null;
                }

                return fieldUSpeaker.GetValue(ptr)?.Unbox<USpeaker>();
            }
        }

        private static IL2Property propertyVRCPlayerApi = null;
        public VRCPlayerApi vrcPlayerApi
        {
            get
            {
                if (propertyVRCPlayerApi == null)
                {
                    propertyVRCPlayerApi = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == VRCPlayerApi.Instance_Class.FullName);
                    if (propertyVRCPlayerApi == null)
                        return default;
                }

                return propertyVRCPlayerApi.GetGetMethod().Invoke(ptr).Unbox<VRCPlayerApi>();
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
                        var instructions = disassembler.Disassemble().TakeWhile(x => x.Mnemonic != ud_mnemonic_code.UD_Iint3);

                        foreach (var instruction in instructions)
                        {
                            if (!ILCode.IsCall(instruction))
                                continue;
                            try
                            {
                                var addr = ILCode.GetPointer(instruction);
                                if (*(IntPtr*)methodAPI.ptr == addr)
                                {
                                    propertyIsFriend = prop;
                                    break;
                                }
                            }
                            catch { }
                        }
                        if (propertyIsFriend != null) break;
                    }
                    if (propertyIsFriend == null)
                        return default;
                }
                return propertyIsFriend.GetGetMethod().Invoke(ptr).Unbox<bool>();
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

        public ulong steamId
        {
            get
            {
                return Convert.ToUInt64(((IntPtr)photonPlayer.hashtable["steamUserID"]).MonoCast<string>());
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

        private static IL2Method methodToString = null;
        public override string ToString()
        {
            if (!IL2Get.Method("ToString", Instance_Class, ref methodToString))
                return default;

            return methodToString.Invoke(ptr)?.MonoCast<string>();
        }

        public IntPtr ToStringPointer()
        {
            if (!IL2Get.Method("ToString", Instance_Class, ref methodToString))
                return default;

            IL2Object @object = methodToString.Invoke(ptr);
            if (@object == null) return IntPtr.Zero;
            return @object.ptr;
        }

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("Player", "VRC");
    }
}
