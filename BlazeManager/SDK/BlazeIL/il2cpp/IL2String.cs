using System;
using System.Runtime.InteropServices;

namespace BlazeIL.il2cpp
{
    unsafe public class IL2String : IL2Base
    {
        internal IL2String(IntPtr ptr) : base(ptr) => base.ptr = ptr;
        internal IL2String(string str) : base(IntPtr.Zero)
        {
            ptr = IL2Import.il2cpp_string_new_len(string.Empty, str.Length);
            for (int i = 0; i < str.Length; i++)
            {
                *(char*)(ptr + 0x14 + (0x2 * i)) = str[i];
            }
        }

        public override string ToString()
        {
            return new string((char*)ptr.ToPointer() + 10);
        }
    }
}
