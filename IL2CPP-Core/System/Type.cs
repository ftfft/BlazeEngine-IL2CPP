using System;
using System.Reflection;
using BE4v.SDK.CPP2IL;

namespace System
{
    public class IL2Type : IL2MemberInfo
    {
        public IL2Type(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public IL2AssemblyCore Assembly
        {
            get => Instance_Class.GetProperty(nameof(Assembly)).GetGetMethod().Invoke(ptr)?.GetValue<IL2AssemblyCore>();
        }

        public static new IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("Type", "System");
    }
}
