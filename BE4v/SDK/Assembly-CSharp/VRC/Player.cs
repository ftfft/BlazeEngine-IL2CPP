using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using VRC.SDKBase;

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
                return property?.GetGetMethod().Invoke()?.GetValue<Player>();
            }
        }

        /*
        public APIUser user
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(user));
                if (property == null)
                    (property = Instance_Class.GetProperty(APIUser.Instance_Class)).Name = nameof(user);
                return property?.GetGetMethod().Invoke(ptr)?.unbox<APIUser>();
            }
        }

        public PlayerNet playerNet
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(playerNet));
                if (property == null)
                    (property = Instance_Class.GetProperty(PlayerNet.Instance_Class)).Name = nameof(playerNet);
                return property?.GetGetMethod().Invoke(ptr)?.unbox<PlayerNet>();
            }
        }
        */
        public IL2Photon.Realtime.Player PhotonPlayer
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(PhotonPlayer));
                if (property == null)
                    (property = Instance_Class.GetProperty(IL2Photon.Realtime.Player.Instance_Class)).Name = nameof(PhotonPlayer);
                return property?.GetGetMethod().Invoke(ptr)?.GetValue<IL2Photon.Realtime.Player>();
            }
        }

        public VRCPlayer Components
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(Components));
                if (property == null)
                    (property = Instance_Class.GetProperty(VRCPlayer.Instance_Class)).Name = nameof(Components);
                return property?.GetGetMethod().Invoke(ptr)?.GetValue<VRCPlayer>();
            }
        }

        public VRCPlayerApi playerApi
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(playerApi));
                if (property == null)
                    (property = Instance_Class.GetProperty(VRCPlayerApi.Instance_Class)).Name = nameof(playerApi);
                return property?.GetGetMethod().Invoke(ptr)?.GetValue<VRCPlayerApi>();
            }
        }

        /*
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

        public bool IsMuted
        {

            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(IsMuted));
                if (property == null)
                    (property = Instance_Class.GetProperties(x => x.GetGetMethod().ReturnType.Name == typeof(bool).FullName && x.GetSetMethod() != null).Skip(2).FirstOrDefault()).Name = nameof(IsMuted);

                IL2Object result = property?.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;
                
                return result.unbox_Unmanaged<bool>();
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
                    (field = Instance_Class.GetField(USpeaker.Instance_Class)).Name = nameof(mUSpeaker);
                return field.GetValue(ptr)?.unbox<USpeaker>();
            }
        }

        public new IL2String ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.unbox_ToString();
        }
        */
        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClass(VRCPlayer.Instance_Class.GetMethod("SpawnEmojiRPC").GetParameters()[1].ReturnType.Name);
    }
}
