using System;
using System.Linq;
using UnityEngine;
using VRC;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

public class DynamicBoneCollider : MonoBehaviour
{
	public DynamicBoneCollider(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	unsafe public Bound m_Bound
    {
        get => Instance_Class.GetField(nameof(m_Bound)).GetValue(ptr).GetValuе<Bound>();
		set => Instance_Class.GetField(nameof(m_Bound)).SetValue(ptr, new IntPtr(&value));
    }

	public enum Direction
	{
		X,
		Y,
		Z
	}

	public enum Bound
	{
		Outside,
		Inside
	}

	public static new IL2Class Instance_Class = Assembler.list["acs"].GetClass("DynamicBoneCollider");
}
