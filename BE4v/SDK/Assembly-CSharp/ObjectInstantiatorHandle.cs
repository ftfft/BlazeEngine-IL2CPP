using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class ObjectInstantiatorHandle : MonoBehaviour
{
    public ObjectInstantiatorHandle(IntPtr ptr) : base(ptr) => base.ptr = ptr;
	/*
	public ObjectInstantiator Instantiator
	{
		get
		{
			IL2Field field = Instance_Class.GetField(nameof(Instantiator));
			if (field == null)
				(field = Instance_Class.GetField(x => x.ReturnType.Name == ObjectInstantiator.Instance_Class.FullName)).Name = nameof(Instantiator); ;
			return field?.GetValue(ptr)?.GetValue<ObjectInstantiator>();
		}
		set
		{
			IL2Field field = Instance_Class.GetField(nameof(Instantiator));
			if (field == null)
				(field = Instance_Class.GetField(x => x.ReturnType.Name == ObjectInstantiator.Instance_Class.FullName)).Name = nameof(Instantiator);
			field?.SetValue(ptr, value.ptr);
		}
	}
	*/
	unsafe public int? LocalID
	{
		get
		{
			IL2Field field = Instance_Class.GetField(nameof(LocalID));
			if (field == null)
				(field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(int?).FullName)).Name = nameof(LocalID);

			return field.GetValue(ptr)?.GetValuе<int>();
		}
		set
		{
			IL2Field field = Instance_Class.GetField(nameof(LocalID));
			if (field == null)
				(field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(int?).FullName)).Name = nameof(LocalID);
			IntPtr val = IntPtr.Zero;
			if (value != null)
            {
				int iValue = (int)value;
				val = new IntPtr(&iValue);
            }
			field.SetValue(ptr, val);
		}
	}

	public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("ReapObject") != null);
}
