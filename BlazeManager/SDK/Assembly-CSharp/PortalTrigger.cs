using System;
using UnityEngine;
using BlazeIL.il2cpp;

public class PortalTrigger : MonoBehaviour
{
    public PortalTrigger(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("PortalTrigger");
}
