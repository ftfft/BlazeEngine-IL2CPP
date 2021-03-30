using System;
using System.Linq;
using BlazeIL.il2cpp;
using UnityEngine;
using VRC.Core;

public class InteractivePlayer : MonoBehaviour
{
    public InteractivePlayer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses().Where(x => x.GetFields().Length == 2 && x.GetFields()[0].ReturnType.Name == x.GetFields()[1].ReturnType.Name && x.GetMethod("Awake") != null && x.GetMethod("Update") != null).FirstOrDefault();
}
