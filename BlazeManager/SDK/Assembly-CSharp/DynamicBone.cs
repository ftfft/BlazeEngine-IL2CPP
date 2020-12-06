using System;
using System.Linq;
using UnityEngine;
using VRC;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2generic;

public class DynamicBone : MonoBehaviour
{
	public DynamicBone(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	public IL2List<DynamicBoneCollider> m_Colliders
	{
        get => new IL2List<DynamicBoneCollider>(Instance_Class.GetField(nameof(m_Colliders)).GetValue(ptr).ptr);
		set => Instance_Class.GetField(nameof(m_Colliders)).SetValue(ptr, value.ptr);
	}

	public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("DynamicBone");
}
