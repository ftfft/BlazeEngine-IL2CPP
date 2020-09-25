using System;
using UnityEngine;
using BlazeIL.il2cpp;
using BlazeIL.il2generic;
using BlazeIL.il2reflection;

namespace VRC.Networking
{
	public class UdonSync : MonoBehaviour
	{
		public UdonSync(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("UdonSync", "VRC.Networking");
	}
}