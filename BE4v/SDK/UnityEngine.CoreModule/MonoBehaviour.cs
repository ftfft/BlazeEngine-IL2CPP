using System;
using System.Reflection.Emit;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	/// <summary>
	///   <para>Behaviours are Components that can be enabled or disabled.</para>
	/// </summary>
	public class MonoBehaviour : Behaviour
	{
		public MonoBehaviour(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public void StopAllCoroutines()
        {
			Instance_Class.GetMethod(nameof(StopAllCoroutines)).Invoke(ptr);
        }

		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("MonoBehaviour", "UnityEngine");
	}
}
