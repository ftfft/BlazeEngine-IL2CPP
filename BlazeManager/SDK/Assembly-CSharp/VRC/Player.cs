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
    public class Player : MonoBehaviour
    {
        public Player(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        // <!---------- ---------- ---------->
        // <!---------- PROPERTY'S ---------->
        // <!---------- ---------- ---------->
        public static Player Instance
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(Instance));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
                return property?.GetGetMethod().Invoke()?.unbox<Player>();
            }
        }

        public APIUser user
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(user));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == APIUser.Instance_Class.FullName)).Name = nameof(user);
                return property?.GetGetMethod().Invoke(ptr)?.unbox<APIUser>();
            }
        }

        public PlayerNet playerNet
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(playerNet));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == PlayerNet.Instance_Class.FullName)).Name = nameof(playerNet);
                return property?.GetGetMethod().Invoke(ptr)?.unbox<PlayerNet>();
            }
        }

        public Photon.Realtime.Player PhotonPlayer
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(PhotonPlayer));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == Photon.Realtime.Player.Instance_Class.FullName)).Name = nameof(PhotonPlayer);
                return property?.GetGetMethod().Invoke(ptr)?.unbox<Photon.Realtime.Player>();
            }
        }

        public VRCPlayer Components
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(Components));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == VRCPlayer.Instance_Class.FullName)).Name = nameof(Components);
                return property?.GetGetMethod().Invoke(ptr)?.unbox<VRCPlayer>();
            }
        }

        public VRCPlayerApi playerApi
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(playerApi));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == VRCPlayerApi.Instance_Class.FullName)).Name = nameof(playerApi);
                return property?.GetGetMethod().Invoke(ptr)?.unbox<VRCPlayerApi>();
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
                        foreach (var @obj in ILCode.CastToILObject(instructions))
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

        public IL2String userId
        {

            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(userId));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == typeof(string).FullName && x.GetSetMethod() == null)).Name = nameof(userId);
                return property?.GetGetMethod().Invoke(ptr)?.unbox_ToString();
            }
        }

        // <!---------- ------- ---------->
        // <!---------- FIELD'S ---------->
        // <!---------- ------- ---------->
        public USpeaker mUSpeaker
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(mUSpeaker));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == USpeaker.Instance_Class.FullName)).Name = nameof(mUSpeaker);
                return field?.GetValue(ptr)?.unbox<USpeaker>();
            }
        }

        public ulong steamId
        {
            get
            {
                Photon.Realtime.Player photon = PhotonPlayer;
                if (photon == null) return 0U;
                IntPtr ptr = photon.CustomProperties[new IL2String("steamUserID").ptr];
                if (ptr == IntPtr.Zero) return 0U;
                return Convert.ToUInt64(new IL2String(ptr).ToString());
            }
        }

        public new IL2String ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.unbox_ToString();
        }

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("Player", "VRC");
    }
}
