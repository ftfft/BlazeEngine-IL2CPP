using System;

namespace IL2CPP_Core.Objects
{
    public class IL2String : IL2Object
    {
        public IL2String(IntPtr ptr) : base(ptr) => Pointer = ptr;
        unsafe public IL2String(string str) : base(IntPtr.Zero)
        {
            if (str == null)
            {
                Pointer = IntPtr.Zero;
                return;
            }
            while (Pointer == IntPtr.Zero || ToString() != str)
            {
                int length = str.Length;
                Pointer = Import.Object.il2cpp_string_new(string.Empty.PadRight(length, '\u0001'));
                for (int i = 0; i < length; i++)
                {
                    *(char*)(Pointer + 0x14 + (0x2 * i)) = str[i];
                }
            }
        }

        unsafe public override string ToString()
        {
            if (Pointer == IntPtr.Zero)
                return null;

            return new string((char*)Pointer + 10);
        }
    }
}
