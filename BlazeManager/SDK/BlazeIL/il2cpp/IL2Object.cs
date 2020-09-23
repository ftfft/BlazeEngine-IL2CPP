using System;
using System.Linq;
using System.Collections.Generic;

namespace BlazeIL.il2cpp
{
    public class IL2Object : IL2Base
    {
        public IL2Object(IntPtr ptr, IL2ReturnType ReturnType) : base(ptr)
        {
            base.ptr = ptr;

            this.ReturnType = ReturnType;
        }

        public IL2ReturnType ReturnType { get; set; }
        public T Unbox<T>() => ptr.MonoCast<T>();
        public T pUnbox<T>() where T : unmanaged => ptr.pUnbox<T>();
        unsafe public IntPtr[] UnboxArray()
        {
            long length = *((long*)ptr + 3);
            IntPtr[] result = new IntPtr[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = *(IntPtr*)((IntPtr)((long*)ptr + 4) + i * IntPtr.Size);
            }
            return result;
        }
        public T[] UnboxArray<T>()
        {
            IntPtr[] a = UnboxArray();
            T[] b = new T[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = a[i].MonoCast<T>();
            }
            return b;
        }
    }
}
