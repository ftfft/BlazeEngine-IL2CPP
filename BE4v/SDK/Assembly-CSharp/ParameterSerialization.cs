using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

public static class ParameterSerialization
{
	public static IL2Object[] Decode(byte[] data)
	{
		IL2Method method = Instance_Class.GetMethod(nameof(Decode));
		if (method == null)
        {
			(method = Instance_Class.GetMethod(x => x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == typeof(byte[]).FullName)).Name = nameof(Decode);
			if (method == null)
				return null;
		}

		int len = data.Length;
		IL2Array<byte> b = new IL2Array<byte>(len, IL2SystemClass.Byte);
		for(int i=0;i<len;i++)
        {
			b[i] = data[i];
		}
		IL2Object @object = method.Invoke(new IntPtr[] { b.ptr });
		if (@object == null)
			return null;

		return @object.UnboxArray<IL2Object>();
	}

	public class SerializableContainer : IL2Base
	{
		public SerializableContainer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		internal string name;

		internal byte[] data;

		public static IL2Class Instance_Class = ParameterSerialization.Instance_Class.GetNestedType("SerializableContainer");
	}

	public static IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FindClass_ByNesestTypedName("SerializableContainer");
}