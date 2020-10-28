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
                    properties.Add(nameof(Instance), Instance_Class.GetProperty(x => x.Instance));
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
                if (!properties.ContainsKey(nameof(apiuser)))
                {
                    properties.Add(nameof(apiuser), Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == APIUser.Instance_Class.FullName));
                    if (!properties.ContainsKey(nameof(apiuser)))
                        return null;
                }

                return properties[nameof(apiuser)].GetGetMethod().Invoke(ptr)?.unbox<APIUser>();
            }
        }

        public PlayerNet playerNet
        {
            get
            {
                if (!properties.ContainsKey(nameof(playerNet)))
                {
                    properties.Add(nameof(playerNet), Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == PlayerNet.Instance_Class.FullName));
                    if (!properties.ContainsKey(nameof(playerNet)))
                        return null;
                }

                return properties[nameof(playerNet)].GetGetMethod().Invoke(ptr)?.unbox<PlayerNet>();
            }
        }

        public PhotonPlayer photonPlayer
        {
            get
            {
                if (!fields.ContainsKey(nameof(photonPlayer)))
                {
                    fields.Add(nameof(photonPlayer), Instance_Class.GetField(x => x.ReturnType.Name == PhotonPlayer.Instance_Class.FullName));
                    if (!fields.ContainsKey(nameof(photonPlayer)))
                        return null;
                }

                return fields[nameof(photonPlayer)].GetValue(ptr)?.unbox<PhotonPlayer>();
            }
        }

        public VRCPlayer vrcPlayer
        {
            get
            {
                if (!fields.ContainsKey(nameof(vrcPlayer)))
                {
                    fields.Add(nameof(vrcPlayer), Instance_Class.GetField(x => x.ReturnType.Name == VRCPlayer.Instance_Class.FullName));
                    if (!fields.ContainsKey(nameof(vrcPlayer)))
                        return null;
                }

                return fields[nameof(vrcPlayer)].GetValue(ptr)?.unbox<VRCPlayer>();
            }
        }

        public USpeaker uSpeaker
        {
            get
            {
                if (!fields.ContainsKey(nameof(uSpeaker)))
                {
                    fields.Add(nameof(uSpeaker), Instance_Class.GetField(x => x.ReturnType.Name == USpeaker.Instance_Class.FullName));
                    if (!fields.ContainsKey(nameof(uSpeaker)))
                        return null;
                }
                return fields[nameof(uSpeaker)].GetValue(ptr)?.unbox<USpeaker>();
            }
        }

        public VRCPlayerApi vrcPlayerApi
        {
            get
            {
                if (!properties.ContainsKey(nameof(vrcPlayerApi)))
                {
                    properties.Add(nameof(vrcPlayerApi), Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == VRCPlayerApi.Instance_Class.FullName));
                    if (!properties.ContainsKey(nameof(vrcPlayerApi)))
                        return null;
                }

                return properties[nameof(vrcPlayerApi)].GetGetMethod().Invoke(ptr)?.unbox<VRCPlayerApi>();
            }
        }

        unsafe public bool IsFriend
        {
            get
            {
                if (!properties.ContainsKey(nameof(IsFriend)))
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
                                Player.properties.Add(nameof(IsFriend), prop);
                                break;
                            }
                        }
                        if (Player.properties.ContainsKey(nameof(IsFriend))) break;
                    }
                    if (!Player.properties.ContainsKey(nameof(IsFriend)))
                        return false;
                }
                return !properties[nameof(IsFriend)].GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
            }
        }

        public string userId => IL2Import.IntPtrToString(userId_Pointer);
        public IntPtr userId_Pointer
        {
            get
            {
                if (!properties.ContainsKey(nameof(userId)))
                {
                    properties.Add(nameof(userId), Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == typeof(string).FullName));
                    if (!properties.ContainsKey(nameof(userId)))
                        return IntPtr.Zero;
                }
                IL2Object @object = properties[nameof(userId)].GetGetMethod().Invoke(ptr);
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
