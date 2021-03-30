using System;
using System.Linq;

namespace BE4v.SDK.CPP2IL
{
    public class IL2Object : IL2Base
    {
        public IL2Object(IntPtr ptr) : base(ptr)
        {
            base.ptr = ptr;
        }

        /// <summary>
        ///     NOT UNMANAGED
        /// </summary>
        /// <returns></returns>
        unsafe public T1 GetValue<T1>()
        {
            if (typeof(T1) == typeof(string))
                return (T1)(object)(new IL2String(ptr).ToString());
            return (T1)typeof(T1).GetConstructors().First(x => x.GetParameters().Length == 1).Invoke(new object[] { ptr });
        }
        /// <summary>
        ///     IS UNMANAGED
        /// </summary>
        /// <returns></returns>
        unsafe public T1 GetValuе<T1>() where T1 : unmanaged
        {
            return *(T1*)(ptr + 0x10).ToPointer();
        }

        /// <summary>
        ///     NOT UNMANAGED
        /// </summary>
        /// <returns></returns>
        unsafe public T1[] UnboxArray<T1>()
        {
            long length = *((long*)ptr + 3);
            T1[] result = new T1[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = new IL2Object(*(IntPtr*)((IntPtr)((long*)ptr + 4) + i * IntPtr.Size)).GetValue<T1>();
            }
            return result;
        }
        /// <summary>
        ///     IS UNMANAGED
        /// </summary>
        /// <returns></returns>
        unsafe public T1[] UnboxArraу<T1>() where T1 : unmanaged
        {
            long length = *((long*)ptr + 3);
            T1[] result = new T1[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = new IL2Object(*(IntPtr*)((IntPtr)((long*)ptr + 4) + i * sizeof(T1))).GetValuе<T1>();
            }
            return result;
        }

        public IL2List<T1> ToIL2List<T1>()
        {
            return new IL2List<T1>(ptr);
        }
    }
}
