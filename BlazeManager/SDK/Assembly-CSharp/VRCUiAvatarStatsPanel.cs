using System;
using System.Linq;
using BlazeIL.il2cpp;
using UnityEngine;

public class VRCUiAvatarStatsPanel : MonoBehaviour
{
    public VRCUiAvatarStatsPanel(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses()
        .FirstOrDefault(
            x =>
            x.GetMethod("PageUpPressed") != null &&
            x.GetMethod("BackPressed") != null
        );
}