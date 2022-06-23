using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.UI
{
    public class DebugDisplayText : MonoBehaviour
    {
        public DebugDisplayText(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetFields().Length == 2 && x.GetFields(y => y.ReturnType.Name == UnityEngine.UI.Text.Instance_Class.FullName).Length == 1 && x.GetFields(y => y.ReturnType.Name.StartsWith(y.ReflectedType.FullName + ".")).Length == 1 && x.GetMethod("Update") != null);
    }
}
