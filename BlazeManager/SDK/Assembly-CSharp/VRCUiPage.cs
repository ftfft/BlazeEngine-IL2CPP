using System;
using System.Linq;
using BlazeIL.il2cpp;
using UnityEngine;
using VRC.Core;

public class VRCUiPage : MonoBehaviour
{
    public VRCUiPage(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses()
        .FirstOrDefault(
            x =>
                x.GetMethod("Update") != null &&
                x.GetFields().Length < 9 &&
                x.GetFields(y => y.ReturnType.Name == typeof(Action).FullName).Length == 2 &&
                x.GetFields(y => y.ReturnType.Name == "UnityEngine.AudioClip").Length == 2 &&
                x.GetFields(y => y.ReturnType.Name == "UnityEngine.CanvasGroup").Length == 1
        );
}
