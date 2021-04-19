using System;
using UnityEngine;
using System.Linq;
using BE4v.SDK.CPP2IL;

public class FadeCycleEffect : MonoBehaviour
{
    public FadeCycleEffect(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	unsafe public float speed
	{
		get => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName)[0].GetValue(ptr).GetValuе<float>();
		set => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName)[0].SetValue(ptr, new IntPtr(&value));
	}

	unsafe public float minAlpha
	{
		get => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName)[1].GetValue(ptr).GetValuе<float>();
		set => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName)[1].SetValue(ptr, new IntPtr(&value));
	}
	
	unsafe public float maxAlpha
	{
		get => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName)[2].GetValue(ptr).GetValuе<float>();
		set => Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName)[2].SetValue(ptr, new IntPtr(&value));
	}
	
	public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses()
		.FirstOrDefault(
			x =>
			x.GetMethod("Start") != null &&
			x.GetMethod("Update") != null &&
			x.GetFields().Length == 4 &&
			x.GetFields(y => y.ReturnType.Name == typeof(float).FullName).Length == 3 &&
			x.GetFields(y => y.ReturnType.Name == UnityEngine.UI.Image.Instance_Class.FullName).Length == 1
		);
}
