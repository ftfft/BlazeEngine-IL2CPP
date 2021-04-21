using BE4v.SDK.CPP2IL;
using System;

public class FoldoutList : IL2Base
{
	public FoldoutList(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	public static IL2Class Instance_Class = Assembler.list["acs"].GetClass("FoldoutList");
}
