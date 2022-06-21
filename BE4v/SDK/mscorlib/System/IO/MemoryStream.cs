using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

namespace System.IO
{
    public class IL2MemoryStream : IL2Stream
    {
        public IL2MemoryStream() : base(IntPtr.Zero)
        {
            ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetMethod(".ctor").Invoke(ptr);
        }

        public IL2MemoryStream(byte[] buffer) : base(IntPtr.Zero)
        {
            ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);

            IntPtr result = IntPtr.Zero;
            if (buffer != null)
            {
                IntPtr[] ptrs = new IntPtr[buffer.Length];
                unsafe
                {
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        fixed (byte* pointer = &buffer[i])
                        {
                            ptrs[i] = new IntPtr(pointer);
                        }
                    }
                }
                result = ptrs.ArrayToIntPtr(IL2SystemClass.Byte);
            }

            Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 1 && x.GetParameters()[0].Name == "buffer").Invoke(ptr, new IntPtr[] { result });
        }

        public virtual byte[] ToArray()
        {
            IL2Object result = Instance_Class.GetMethod(nameof(ToArray)).Invoke(ptr);
            if (result == null) return null;
            return result.UnboxArray<byte>();
            // uint length = Import.Object.il2cpp_array_get_byte_length(result.ptr);
            // return SDKUtils.IntPtrToStructureArray<byte>(result.ptr, length);
        }

        public static new IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("MemoryStream", "System.IO");
    }
}
