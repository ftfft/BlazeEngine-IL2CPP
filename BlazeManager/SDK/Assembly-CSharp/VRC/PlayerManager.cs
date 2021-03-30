using System;
using System.Linq;
using System.Collections.Generic;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;

namespace VRC
{
    public class PlayerManager : MonoBehaviour
    {
        public PlayerManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static PlayerManager Instance
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(Instance));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
                return property?.GetGetMethod().Invoke()?.unbox<PlayerManager>();
            }
        }

        public Player[] PlayersCopy
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(PlayersCopy));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == Player.Instance_Class.FullName + "[]")).Name = nameof(PlayersCopy);
                return property?.GetGetMethod().Invoke(ptr)?.unbox_ToArray<Player>();
            }
        }

        public static Player GetPlayer(int playerId)
        {
            if (playerId < 0)
                return null;

            return Instance_Class.GetMethod(nameof(GetPlayer)).Invoke(new IntPtr[] { playerId.MonoCast() })?.unbox<Player>();
        }

        public static Player GetPlayer(IL2Photon.Realtime.Player photonPlayer)
        {
            if (photonPlayer == null)
                return null;

            return Instance_Class.GetMethod(nameof(GetPlayer), x => x.GetParameters()[0].ReturnType.Name == IL2Photon.Realtime.Player.Instance_Class.FullName).Invoke(new IntPtr[] { photonPlayer.ptr })?.unbox<Player>();
        }

        public static Player GetPlayer(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return null;

            return Instance_Class.GetMethod(nameof(GetPlayer), x => x.GetParameters()[0].ReturnType.Name == typeof(string).FullName).Invoke(new IntPtr[] { new IL2String(userId).ptr })?.unbox<Player>();
        }

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses().FirstOrDefault(x => x.GetMethod("Awake") != null && x.GetMethod("Start") != null && x.GetMethod("Start").ReturnType.Name == "System.Collections.IEnumerator" && x.GetProperty(y => y.Instance) != null && x.GetProperties(y => y.GetGetMethod().ReturnType.Name == VRC.Player.Instance_Class.FullName + "[]").Length == 1);
    }
}