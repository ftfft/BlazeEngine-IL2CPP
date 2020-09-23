using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
	/// <summary>
	///   <para>Behaviours are Components that can be enabled or disabled.</para>
	/// </summary>
	public class Shader : Object
	{
		public Shader(IntPtr ptr) : base(ptr) => base.ptr = ptr;


		private static IL2Method methodFind = null;
		public static Shader Find(string name)
		{
			if (methodFind == null)
			{
				methodFind = Instance_Class.GetMethod("Find");
				if (methodFind == null)
					return null;
			}
			return methodFind.Invoke(new IntPtr[] { IL2Import.il2cpp_string_new_len(name, name.Length) }).MonoCast<Shader>();
		}

		public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Shader", "UnityEngine");
	}
}
