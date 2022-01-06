using BE4v.SDK.CPP2IL;
using System;
using System.Runtime.InteropServices;

namespace BE4v.SDK
{
    public static class IL2SystemClass
    {
        public static IL2Class Byte = Assembler.list["mscorlib"].GetClass(typeof(byte).Name, typeof(byte).Namespace);
        public static IL2Class Int32 = Assembler.list["mscorlib"].GetClass(typeof(int).Name, typeof(int).Namespace);
        public static IL2Class String = Assembler.list["mscorlib"].GetClass(typeof(string).Name, typeof(string).Namespace);
    }
}
