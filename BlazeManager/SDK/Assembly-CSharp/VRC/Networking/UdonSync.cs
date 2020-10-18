using System;
using UnityEngine;
using BlazeIL.il2cpp;

namespace VRC.Networking
{
	public class UdonSync : MonoBehaviour
	{
		public UdonSync(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("UdonSync", "VRC.Networking");
	}
}