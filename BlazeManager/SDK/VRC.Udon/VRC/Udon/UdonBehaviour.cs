using System;
using BlazeIL.il2cpp;
using UnityEngine;

namespace VRC.Udon
{
    public class UdonBehaviour : MonoBehaviour
    {
        public UdonBehaviour(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Type Instance_Class = Assemblies.a["VRC.Udon"].GetClass("UdonBehaviour", "VRC.Udon");
    }
}
