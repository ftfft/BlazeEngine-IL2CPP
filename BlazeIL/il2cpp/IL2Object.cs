using System;
using System.Collections.Generic;
using BlazeIL.il2generic;

namespace BlazeIL.il2cpp
{
    unsafe public class IL2Object : IL2Base
    {
        private IL2ReturnType ReturnType;

        public IL2Object(IntPtr newPtr, IL2ReturnType returntype) : base(newPtr)
        {
            ptr = newPtr;

            ReturnType = returntype;
        }

        public IL2ReturnType GetReturnType() => ReturnType;

        public void* Unbox() => IL2Import.il2cpp_object_unbox(ptr).ToPointer();
        public string UnboxString() => IL2Import.IntPtrToString(ptr);
        public IntPtr[] UnboxArray()
        {
            long length = *((long*)ptr + 3);
            IntPtr[] result = new IntPtr[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = *(IntPtr*)((IntPtr)((long*)ptr + 4) + i * IntPtr.Size);
            }
            return result;
        }
        public string[] UnboxArrayString()
        {
            IntPtr[] buffer = UnboxArray();
            string[] result = new string[buffer.Length];
            for (int i = 0; i < buffer.Length; i++)
                result[i] = new string((char*)buffer[i].ToPointer() + 10);
            return result;
        }

        public Dictionary<T1, T2> UnboxDictionary<T1, T2>()
        {
            // Console.WriteLine("Test: " + Instance_Class)
            return null;
        }
    }
}
