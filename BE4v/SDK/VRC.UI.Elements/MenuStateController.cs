using System;
using System.Linq;
using UnityEngine;
using VRC.Core;
using BE4v.SDK.CPP2IL;
using VRC.UI.Core;

namespace VRC.UI.Elements
{
    public class MenuStateController : MonoBehaviour
    {
        public MenuStateController(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Class Instance_Class = Assembler.list["VRC.UI.Elements"].GetClasses().FirstOrDefault(y => y.FullName == UIMenu.Instance_Class.GetProperties().FirstOrDefault(x => x.GetSetMethod() == null).GetGetMethod().ReturnType.Name);
    }
}