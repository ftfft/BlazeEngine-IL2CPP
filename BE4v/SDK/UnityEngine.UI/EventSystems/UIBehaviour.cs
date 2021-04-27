using BE4v.SDK.CPP2IL;
using System;

namespace UnityEngine.EventSystems
{
	public abstract class UIBehaviour : MonoBehaviour
	{
		public UIBehaviour(IntPtr ptr) : base(ptr) => base.ptr = ptr;
	
		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UI"].GetClass("UIBehaviour", "UnityEngine.EventSystems");
	}
}
