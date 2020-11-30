using System;
using System.Runtime.InteropServices;

namespace BlazeIL.il2cpp
{
    public class IL2Param : IL2Base
    {
        public string Name { get; private set; }
        internal IL2Param(IntPtr ptr, string name) : base(ptr)
        {
            base.ptr = ptr;

            Name = name;
            if (Assemblies.isObfuscated == "tr")
                Name = Name.GetMD5();
        }

        public IL2ReturnType ReturnType => new IL2ReturnType(ptr);
    }
}