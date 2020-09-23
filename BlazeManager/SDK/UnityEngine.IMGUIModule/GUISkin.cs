using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
	// ScriptableObject -> Object
	public sealed class GUISkin : Object
	{
		public GUISkin(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		private static IL2Property propertyLabel;
		public GUIStyle label
		{
			get
			{
				if (propertyLabel == null)
				{
					propertyLabel = Instance_Class.GetProperty("label");
					if (propertyLabel == null)
						return null;
				}
				return propertyLabel.GetGetMethod().Invoke(ptr).MonoCast<GUIStyle>();
			}
			set
			{
				if (propertyLabel == null)
				{
					propertyLabel = Instance_Class.GetProperty("label");
					if (propertyLabel == null)
						return;
				}
				propertyLabel.GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
			}
		}

		public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.IMGUIModule"].GetClass("GUISkin", "UnityEngine");
	}
}
