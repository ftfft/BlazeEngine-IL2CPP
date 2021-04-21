using System;
using UnityEngine;
using System.Linq;
using BE4v.SDK.CPP2IL;

namespace VRC.UI
{
    public class DebugDisplayText : MonoBehaviour
    {
        public DebugDisplayText(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetFields().Length == 2 && x.GetFields(y => y.ReturnType.Name == UnityEngine.UI.Text.Instance_Class.FullName).Length == 1 && x.GetFields(y => y.ReturnType.Name.StartsWith(y.ReflectedType.FullName + ".")).Length == 1 && x.GetMethod("Update") != null);
    }
}
