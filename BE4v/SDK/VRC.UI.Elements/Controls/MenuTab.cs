using System;
using System.Linq;
using UnityEngine;
using VRC.Core;
using BE4v.SDK.CPP2IL;
using VRC.UI.Core;

namespace VRC.UI.Elements.Controls
{
    public class MenuTab : MonoBehaviour
    {
        public MenuTab(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public unsafe string pageName
		{
			get
			{
				IL2Field field = Instance_Class.GetField(nameof(pageName));
				if (field == null)
                {
					(field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(string).FullName)).Name = nameof(pageName);
					if (field == null)
						return null;
                }
				return field.GetValue(ptr).GetValue<string>();
			}
			set
			{
				IL2Field field = Instance_Class.GetField(nameof(pageName));
				if (field == null)
				{
					(field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(string).FullName)).Name = nameof(pageName);
					if (field == null)
						return;
				}
				field.SetValue(ptr, new IL2String(value).ptr);
			}
		}

		public static new IL2Class Instance_Class = Assembler.list["VRC.UI.Elements"].GetClasses().FirstOrDefault(x => x.GetFields().Length == 4 && x.GetMethod("ShowTabContent") != null);
    }
}