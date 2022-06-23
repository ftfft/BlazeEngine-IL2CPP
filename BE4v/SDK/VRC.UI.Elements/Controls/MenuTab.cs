using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.UI.Elements.Controls
{
    public class MenuTab : MonoBehaviour
    {
		public MenuTab(IntPtr ptr) : base(ptr) { }

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
				return field.GetValue(this)?.GetValue<IL2String>().ToString();
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
				field.SetValue(this, new IL2String(value).Pointer);
			}
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRC.UI.Elements"].GetClasses().FirstOrDefault(x => x.GetFields().Length == 4 && x.GetMethod("ShowTabContent") != null);
    }
}