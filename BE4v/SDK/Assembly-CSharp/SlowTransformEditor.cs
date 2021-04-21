using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class SlowTransformEditor : MonoBehaviour
{
    public SlowTransformEditor(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	public void SwapTransform(Transform A, Transform B)
	{
		Instance_Class.GetMethod(nameof(SwapTransform)).Invoke(ptr, new IntPtr[] { A.ptr, B.ptr });
	}

	public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("SwapTransform") != null);
}