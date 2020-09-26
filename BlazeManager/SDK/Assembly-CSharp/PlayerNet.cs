using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;

public class PlayerNet : VRCNetworkBehaviour
{
    public PlayerNet(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PlayerNet");
}