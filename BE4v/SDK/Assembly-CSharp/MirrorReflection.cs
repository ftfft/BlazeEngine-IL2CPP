using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class MirrorReflection : MonoBehaviour
{
    public MirrorReflection(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	unsafe public LayerMask m_ReflectLayers
	{
		get
		{
			IL2Field field = Instance_Class.GetField(nameof(m_ReflectLayers));
			if (field == null)
				(field = Instance_Class.GetField(x => x.ReturnType.Name == "UnityEngine.LayerMask")).Name = nameof(m_ReflectLayers);
			return field.GetValue(ptr).GetValuе<LayerMask>();
		}
		set
		{
			IL2Field field = Instance_Class.GetField(nameof(m_ReflectLayers));
			if (field == null)
				(field = Instance_Class.GetField(x => x.ReturnType.Name == "UnityEngine.LayerMask")).Name = nameof(m_ReflectLayers);
			field.SetValue(ptr, new IntPtr(&value));
		}
	}
	
	public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FindClass_ByMethodName("OnWillRenderObject");
}