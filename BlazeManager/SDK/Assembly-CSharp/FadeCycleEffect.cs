using System;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using System.Linq;

public class FadeCycleEffect : MonoBehaviour
{
    public FadeCycleEffect(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	public float speed
	{
		get => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName)[0].GetValue(ptr).unbox_Unmanaged<float>();
		set => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName)[0].SetValue(ptr, value.MonoCast());
	}
	
	public float minAlpha
	{
		get => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName)[1].GetValue(ptr).unbox_Unmanaged<float>();
		set => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName)[1].SetValue(ptr, value.MonoCast());
	}
	
	public float maxAlpha
	{
		get => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName)[2].GetValue(ptr).unbox_Unmanaged<float>();
		set => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName)[2].SetValue(ptr, value.MonoCast());
	}
	
	public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses()
		.FirstOrDefault(
			x =>
			x.GetMethod("Start") != null &&
			x.GetMethod("Update") != null &&
			x.GetFields().Length == 4 &&
			x.GetFields(y => y.ReturnType.Name == typeof(float).FullName).Length == 3 &&
			x.GetFields(y => y.ReturnType.Name == UnityEngine.UI.Image.Instance_Class.FullName).Length == 1
		);
}
