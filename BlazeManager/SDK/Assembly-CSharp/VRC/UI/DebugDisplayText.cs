using System;
using System.Collections.Generic;
using UnityEngine;
using BlazeIL.il2cpp;
using VRC.Core;
using System.Linq;

namespace VRC.UI
{
    public class DebugDisplayText : MonoBehaviour
    {
        public DebugDisplayText(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses().FirstOrDefault(x => x.GetFields().Length == 2 && x.GetFields(y => y.ReturnType.Name == UnityEngine.UI.Text.Instance_Class.FullName).Length == 1 && x.GetFields(y => y.ReturnType.Name.StartsWith(y.ReflectedType.FullName + ".")).Length == 1 && x.GetMethod("Update") != null);
    }
}
