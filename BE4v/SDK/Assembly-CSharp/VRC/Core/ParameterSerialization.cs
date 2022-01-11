using System;
using System.Linq;
using BE4v.SDK.CPP2IL;

namespace VRC.Core
{
    public static class ParameterSerialization
    {
        static ParameterSerialization()
        {
            Instance_Class = Assembler.list["acs"].GetClasses()
                .FirstOrDefault(x => x.GetNestedType("SerializableContainer") != null);
        }

        public class SerializableContainer : IL2Base
        {
            public SerializableContainer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

            public string name
            {
                get => Instance_Class.GetField(nameof(name)).GetValue()?.GetValue<string>();
                set => Instance_Class.GetField(nameof(name)).SetValue(new IL2String(value).ptr);
            }

            public byte[] data
            {
                get => Instance_Class.GetField(nameof(name)).GetValue()?.UnboxArraу<byte>();
                set
                {
                    // Мне пока что лень
                    // Instance_Class.GetField(nameof(name)).SetValue(new IL2String(value).ptr);
                }
            }
        }

        public static IL2Class Instance_Class;
    }
}