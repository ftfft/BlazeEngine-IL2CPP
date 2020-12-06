using System;

namespace BlazeIL.il2cpp
{
    unsafe public class IL2String : IL2Base
    {
        internal IL2String(IntPtr ptr) : base(ptr) => base.ptr = ptr;
        internal IL2String(string str) : base(IntPtr.Zero)
        {
            if (str == null)
            {
                ptr = IntPtr.Zero;
                return;
            }
            while(ptr == IntPtr.Zero || ToString() != str)
            {
                ptr = IL2Import.il2cpp_string_new(string.Empty.PadRight(str.Length, '\u0001'));
                for (int i = 0; i < str.Length; i++)
                {
                    *(char*)(ptr + 0x14 + (0x2 * i)) = str[i];
                }
            }
        }
        internal IL2String(IL2Object @object) : base(IntPtr.Zero)
        {
            ptr = (@object != null) ? @object.ptr : IntPtr.Zero;
        }

        public override string ToString()
        {
            if (ptr == IntPtr.Zero)
                return null;

            return new string((char*)ptr.ToPointer() + 10);
        }

        private bool isStatic = false;
        private IntPtr handleStatic = IntPtr.Zero;
        public bool Static
        {
            get => isStatic;
            set
            {
                isStatic = value;
                if (value)
                {
                    if (handleStatic == IntPtr.Zero)
                    {
                        handleStatic = IL2Import.il2cpp_gchandle_new(ptr, true);
                    }
                }
                else
                {
                    if (handleStatic != IntPtr.Zero)
                    {
                        IL2Import.il2cpp_gchandle_free(handleStatic);
                        handleStatic = IntPtr.Zero;
                    }
                }
            }
        }
    }
}
