using System;

namespace BlazeIL.il2cpp
{
    unsafe public class IL2String : IL2Base
    {
        internal IL2String(IntPtr ptr) : base(ptr) => base.ptr = ptr;
        internal IL2String(string str) : base(IntPtr.Zero)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                ptr = IntPtr.Zero;
                return;
            }
            while(ptr == IntPtr.Zero || ToString() != str)
            {
                ptr = IL2Import.il2cpp_string_new_len(string.Empty.PadRight(str.Length, 'a'), str.Length);
                for (int i = 0; i < str.Length; i++)
                {
                    *(char*)(ptr + 0x14 + (0x2 * i)) = str[i];
                }
            }
        }
        internal IL2String(IL2Object @object) : base(IntPtr.Zero)
        {
            ptr = IntPtr.Zero;
            if (@object != null)
                ptr = @object.ptr;
        }

        public override string ToString()
        {
            if (ptr == IntPtr.Zero)
                return null;

            return new string((char*)ptr.ToPointer() + 10);
        }
    }
}
