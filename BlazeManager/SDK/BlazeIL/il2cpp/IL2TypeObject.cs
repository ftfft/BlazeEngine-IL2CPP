using System;

namespace BlazeIL.il2cpp
{
    unsafe public class IL2TypeObject : IL2Base
    {
        public IL2TypeObject(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public IL2Object DefaultValue
        {
            get
            {
                IntPtr result = IL2Import.il2cpp_type_get_object(ptr);
                if (result != IntPtr.Zero)
                    return new IL2Object(result);

                return null;
            }
        }

    }
}
