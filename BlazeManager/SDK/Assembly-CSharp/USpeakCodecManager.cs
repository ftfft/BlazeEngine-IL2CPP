using System;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;

public class USpeakCodecManager : IL2Base
{
    public USpeakCodecManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("USpeakCodecManager");
}