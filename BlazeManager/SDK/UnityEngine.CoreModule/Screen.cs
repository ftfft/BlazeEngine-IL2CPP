using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
	public sealed class Screen
	{
		private static IL2Property propertyWidth;
		public static int width
		{
			get
			{
				if (propertyWidth == null)
				{
					propertyWidth = Instance_Class.GetProperty("width");
					if (propertyWidth == null)
						return default;
				}
				return propertyWidth.GetGetMethod().Invoke().MonoCast<int>();
			}
		}

		private static IL2Property propertyHeight;
		public static int height
		{
			get
			{
				if (propertyHeight == null)
				{
					propertyHeight = Instance_Class.GetProperty("height");
					if (propertyHeight == null)
						return default;
				}
				return propertyHeight.GetGetMethod().Invoke().MonoCast<int>();
			}
		}

		public static IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Screen", "UnityEngine");
	}
}
