using System;
using System.Linq;
using UnityEngine;
using VRC;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2generic;
using BlazeIL.il2reflection;

public class DynamicBone : MonoBehaviour
{
	public DynamicBone(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	private static IL2Field fieldM_Colliders;
	public IL2List<DynamicBoneCollider> m_Colliders
	{
        get
        {
			if (!IL2Get.Field("m_Colliders", Instance_Class, ref fieldM_Colliders))
				return null;
			
			return new IL2List<DynamicBoneCollider>(fieldM_Colliders.GetValue(ptr).ptr);
		}
		set
		{
			if (!IL2Get.Field("m_Colliders", Instance_Class, ref fieldM_Colliders))
				return;
			
			fieldM_Colliders.SetValue(ptr, value.ptr);
		}
	}

	public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("DynamicBone");
}
