using System;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

public class FadeCycleEffect : MonoBehaviour
{
    public FadeCycleEffect(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	public float speed
	{
		get => Instance_Class.GetField(nameof(speed)).GetValue(ptr).unbox_Unmanaged<float>();
		set => Instance_Class.GetField(nameof(speed)).SetValue(ptr, value.MonoCast());
	}
	
	public float minAlpha
	{
		get => Instance_Class.GetField(nameof(minAlpha)).GetValue(ptr).unbox_Unmanaged<float>();
		set => Instance_Class.GetField(nameof(minAlpha)).SetValue(ptr, value.MonoCast());
	}
	
	public float maxAlpha
	{
		get => Instance_Class.GetField(nameof(maxAlpha)).GetValue(ptr).unbox_Unmanaged<float>();
		set => Instance_Class.GetField(nameof(maxAlpha)).SetValue(ptr, value.MonoCast());
	}
	
	public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("FadeCycleEffect");
}
