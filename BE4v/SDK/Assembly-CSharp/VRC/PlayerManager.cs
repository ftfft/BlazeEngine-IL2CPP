using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

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
                return property?.GetGetMethod().Invoke()?.GetValue<PlayerManager>();
            }
        }

        public static Player[] PlayersCopy
        {
            get => FindObjectsOfType<Player>();
        }

        unsafe public static Player GetPlayer(int playerId)
        {
            if (playerId < 0)
                return null;

            return Instance_Class.GetMethod(nameof(GetPlayer)).Invoke(new IntPtr[] { new IntPtr(&playerId) })?.GetValue<Player>();
        }

        public static Player GetPlayer(IL2Photon.Realtime.Player photonPlayer)
        {
            if (photonPlayer == null)
                return null;

            return Instance_Class.GetMethod(nameof(GetPlayer), x => x.GetParameters()[0].ReturnType.Name == IL2Photon.Realtime.Player.Instance_Class.FullName).Invoke(new IntPtr[] { photonPlayer.ptr })?.GetValue<Player>();
        }

        public static Player GetPlayer(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return null;

            return Instance_Class.GetMethod(nameof(GetPlayer), x => x.GetParameters()[0].ReturnType.Name == typeof(string).FullName).Invoke(new IntPtr[] { new IL2String(userId).ptr })?.GetValue<Player>();
        }

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FindClass_ByMethodName("OnPlayerDisconnected");
    }
}