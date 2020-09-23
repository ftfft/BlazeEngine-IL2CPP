using System;
using System.Linq;
using System.Reflection;
using BlazeIL.il2cpp;

unsafe public class USpeaker : UnityEngine.Object
{
    public USpeaker(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("USpeaker");
}