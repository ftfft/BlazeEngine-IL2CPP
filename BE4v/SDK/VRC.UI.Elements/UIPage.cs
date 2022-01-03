using System;
using System.Linq;
using UnityEngine;
using VRC.Core;
using BE4v.SDK.CPP2IL;
using VRC.UI.Core;

namespace VRC.UI.Elements
{
    public class UIPage : MonoBehaviour
    {
        public UIPage(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public unsafe string Name
		{
			get
			{
				IL2Field field = Instance_Class.GetField(nameof(Name));
				if (field == null)
				{
					(field = Instance_Class.GetFields().FirstOrDefault(x => x.ReturnType.Name == typeof(string).FullName)).Name = nameof(Name);
					if (field == null)
						return null;
				}

				return field.GetValue(ptr)?.GetValue<string>();
			}
			set
			{
				IL2Field field = Instance_Class.GetField(nameof(Name));
				if (field == null)
				{
					(field = Instance_Class.GetFields().FirstOrDefault(x => x.ReturnType.Name == typeof(string).FullName)).Name = nameof(Name);
					if (field == null)
						return;
				}
				field.SetValue(ptr, new IL2String(value).ptr);
			}
		}

		public unsafe MenuStateController _menuStateController
		{
			get
			{
				IL2Field field = Instance_Class.GetField(nameof(_menuStateController));
				if (field == null)
				{
					(field = Instance_Class.GetField(MenuStateController.Instance_Class)).Name = nameof(_menuStateController);
					if (field == null)
						return null;
				}

				return field.GetValue(ptr)?.GetValue<MenuStateController>();
			}
			set
			{
				IL2Field field = Instance_Class.GetField(nameof(_menuStateController));
				if (field == null)
				{
					(field = Instance_Class.GetField(MenuStateController.Instance_Class)).Name = nameof(_menuStateController);
					if (field == null)
						return;
				}
				field.SetValue(ptr, value.ptr);
			}
		}

		public static new IL2Class Instance_Class = Instance_Class = Assembler.list["VRC.UI.Elements"].GetClasses().FirstOrDefault(x => x.GetField(y => y.ReturnType.Name == "DG.Tweening.Sequence") != null);
    }
}