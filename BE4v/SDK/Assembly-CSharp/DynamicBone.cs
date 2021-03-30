using BE4v.SDK.CPP2IL;
using System;
using System.Linq;
using UnityEngine;
using VRC;

public class DynamicBone : MonoBehaviour
{
	public DynamicBone(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	public IL2List<DynamicBoneCollider> m_Colliders
	{
        get => Instance_Class.GetField(nameof(m_Colliders)).GetValue(ptr).ToIL2List<DynamicBoneCollider>();
		set => Instance_Class.GetField(nameof(m_Colliders)).SetValue(ptr, value.ptr);
	}

	public static new IL2Class Instance_Class = Assembler.list["acs"].GetClass("DynamicBone");
}
