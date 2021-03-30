using System;
using System.Linq;

namespace BlazeIL.il2cpp
{
    public class IL2Object : IL2Base
    {
        public IL2Object(IntPtr ptr) : base(ptr)
        {
            base.ptr = ptr;

            ReturnType = null;
        }

        public IL2Object(IntPtr ptr, IL2ReturnType ReturnType) : base(ptr)
        {
            base.ptr = ptr;

            this.ReturnType = ReturnType;
        }

        public IL2ReturnType ReturnType { get; set; }
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
        
        public T unbox<T>()
        {
            InvocationDelegate fastInvoke = IL2Tools.GetMethodInvoker(typeof(T).GetConstructors().First(x => x.GetParameters().Length == 1));
            return (T)fastInvoke(null, new object[] { ptr });
        }

        unsafe public T unbox_Unmanaged<T>() where T : unmanaged
        {
            return *(T*)(ptr + 0x10).ToPointer();
        }

        unsafe public T unbox_Dis_Unmanaged<T>() where T : unmanaged
        {
            IntPtr @int = ptr;
            return *(T*)&@int;
        }
        unsafe public IL2Object[] unbox_ToArray()
        {
            long length = *((long*)ptr + 3);
            IL2Object[] result = new IL2Object[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = new IL2Object(*(IntPtr*)((IntPtr)((long*)ptr + 4) + i * IntPtr.Size), null);
            }
            return result;
        }

        public T[] unbox_ToArray<T>()
        {
            IL2Object[] @objects = unbox_ToArray();
            T[] result = new T[@objects.Length];
            for (int i = 0; i < @objects.Length; i++)
                result[i] = @objects[i].unbox<T>();
            return result;
        }

        public string[] unbox_ToArray_String()
        {
            IL2Object[] @objects = unbox_ToArray();
            string[] result = new string[@objects.Length];
            for (int i = 0; i < @objects.Length; i++)
                result[i] = @objects[i].unbox_ToString().ToString();
            return result;
        }

        public IL2String[] unbox_ToArray_IL2String()
        {
            IL2Object[] @objects = unbox_ToArray();
            IL2String[] result = new IL2String[@objects.Length];
            for (int i = 0; i < @objects.Length; i++)
                result[i] = @objects[i].unbox_ToString();
            return result;
        }

        unsafe public T[] unbox_ToArray_Unmanaged<T>() where T : unmanaged
        {
            long length = *((long*)ptr + 3);
            T[] result = new T[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = new IL2Object(*(IntPtr*)((IntPtr)((long*)ptr + 4) + i * sizeof(T)), null).unbox_Unmanaged<T>();
            }
            return result;
        }

        unsafe public T[] unbox_ToArray_Dis_Unmanaged<T>() where T : unmanaged
        {
            long length = *((long*)ptr + 3);
            T[] result = new T[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = new IL2Object(*(IntPtr*)((IntPtr)((long*)ptr + 4) + i * sizeof(T)), null).unbox_Dis_Unmanaged<T>();
            }
            return result;
        }

        public IL2String unbox_ToString() => new IL2String(ptr);
    }
}
