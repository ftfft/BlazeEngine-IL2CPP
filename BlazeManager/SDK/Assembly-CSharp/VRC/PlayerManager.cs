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

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PlayerManager", "VRC");
    }
}