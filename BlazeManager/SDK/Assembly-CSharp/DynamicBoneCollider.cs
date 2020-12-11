using System;
using System.Linq;
using UnityEngine;
using VRC;
using BlazeIL;
using BlazeIL.il2cpp;

public class DynamicBoneCollider : MonoBehaviour
{
	public DynamicBoneCollider(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	public Bound m_Bound
    {
        get => Instance_Class.GetField(nameof(m_Bound)).GetValue(ptr).unbox_Unmanaged<Bound>();
        set => Instance_Class.GetField(nameof(m_Bound)).SetValue(ptr, value.MonoCast());
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

	public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("DynamicBoneCollider");
}
