using System;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

public class FadeCycleEffect : MonoBehaviour
{
    public FadeCycleEffect(IntPtr ptr) : base(ptr) => base.ptr = ptr;


	private static IL2Field fieldSpeed;
	public float speed
	{
		get
		{
			if (!IL2Get.Field("speed", Instance_Class, ref fieldSpeed))
				return -1;

			return fieldSpeed.GetValue(ptr).Unbox<float>();
		}
		set
		{
			if (!IL2Get.Field("speed", Instance_Class, ref fieldSpeed))
				return;

			fieldSpeed.SetValue(ptr, value.MonoCast());
		}
	}
	
	private static IL2Field fieldMinAlpha;
	public float minAlpha
	{
		get
		{
			if (!IL2Get.Field("minAlpha", Instance_Class, ref fieldMinAlpha))
				return -1;

			return fieldMinAlpha.GetValue(ptr).Unbox<float>();
		}
		set
		{
			if (!IL2Get.Field("minAlpha", Instance_Class, ref fieldMinAlpha))
				return;

			fieldMinAlpha.SetValue(ptr, value.MonoCast());
		}
	}
	
	private static IL2Field fieldMaxAlpha;
	public float maxAlpha
	{
		get
		{
			if (!IL2Get.Field("maxAlpha", Instance_Class, ref fieldMaxAlpha))
				return -1;

			return fieldMaxAlpha.GetValue(ptr).Unbox<float>();
		}
		set
		{
			if (!IL2Get.Field("maxAlpha", Instance_Class, ref fieldMaxAlpha))
				return;

			fieldMaxAlpha.SetValue(ptr, value.MonoCast());
		}
	}

	public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("FadeCycleEffect");
}
