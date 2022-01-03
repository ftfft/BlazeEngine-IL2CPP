using System;
using System.Linq;
using UnityEngine;
using VRC.Core;
using BE4v.SDK.CPP2IL;
using VRC.UI.Elements;

namespace VRC.UI.Core
{
    public class UIContext : IL2Base
    {
        public UIContext(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public static IL2Class Instance_Class = Instance_Class = Assembler.list["VRC.UI.Core"].GetClasses().FirstOrDefault(x => x.GetFields().Length == 4 && x.GetMethods().Length < 3);
    }
}