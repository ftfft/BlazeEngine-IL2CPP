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
        get
        {
			if (fieldM_Bound == null)
			{
				fieldM_Bound = Instance_Class.GetField("m_Bound");
				if (fieldM_Bound == null)
					return 0;
			}
			return fieldM_Bound.GetValue(ptr).MonoCast<Bound>();
		}
		set
		{
			if (fieldM_Bound == null)
			{
				fieldM_Bound = Instance_Class.GetField("m_Bound");
				if (fieldM_Bound == null)
					return;
			}
			fieldM_Bound.SetValue(ptr, value.MonoCast());
		}
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

	// Fields
	private static IL2Field fieldM_Bound;

	// Original Instance_Class
	public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("DynamicBoneCollider");
}
