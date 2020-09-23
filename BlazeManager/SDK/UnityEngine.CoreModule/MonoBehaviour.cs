using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
	/// <summary>
	///   <para>Behaviours are Components that can be enabled or disabled.</para>
	/// </summary>
	public class MonoBehaviour : Behaviour
	{
		public MonoBehaviour(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("MonoBehaviour", "UnityEngine");
	}
}
