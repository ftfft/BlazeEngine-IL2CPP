using System;
using System.IO;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace System.Runtime.Serialization.Formatters.Binary
{
    public sealed class IL2BinaryFormatter : IL2Base
    {
        public IL2BinaryFormatter(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public IL2BinaryFormatter() : base(IntPtr.Zero)
        {
            ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 0).Invoke(ptr);
        }

        public void Serialize(IL2Stream serializationStream, IL2Object graph)
        {
            Instance_Class.GetMethod(nameof(Serialize), x => x.GetParameters().Length == 2).Invoke(ptr, new IntPtr[] { serializationStream.ptr, graph.ptr });
        }

        public IL2Object Deserialize(IL2Stream serializationStream)
        {
            return Instance_Class.GetMethod(nameof(Deserialize), x => x.GetParameters().Length == 1).Invoke(ptr, new IntPtr[] { serializationStream.ptr });
        }

        public static IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("BinaryFormatter", "System.Runtime.Serialization.Formatters.Binary");
    }
}
