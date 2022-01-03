using System;
using System.Linq;
using UnityEngine;
using VRC.Core;
using BE4v.SDK.CPP2IL;
using VRC.UI.Core;

namespace VRC.UI.Elements.Menus
{
    public class LaunchPadQMMenu : UIPage
	{
        public LaunchPadQMMenu(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public static new IL2Class Instance_Class = Assembler.list["VRC.UI.Elements"].GetClasses().FirstOrDefault(x => x.BaseType?.ptr == UIPage.Instance_Class.ptr && x.GetFields().Length > 6 && x.GetFields().Select(y => y.ReturnType.Name == UnityEngine.UI.Button.Instance_Class.FullName).Count() > 5);
    }
}