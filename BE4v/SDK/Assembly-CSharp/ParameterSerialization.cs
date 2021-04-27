using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public static class ParameterSerialization
{

	public class SerializableContainer : IL2Base
	{
		public SerializableContainer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		internal string name;

		internal byte[] data;

		public static IL2Class Instance_Class = ParameterSerialization.Instance_Class.GetNestedType("SerializableContainer");
	}

	public static IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetNestedType("SerializableContainer") != null);
}