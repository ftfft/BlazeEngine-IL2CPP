using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

namespace System.Text
{
    public class IL2Encoding : IL2Base
    {
        public IL2Encoding(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static IL2Encoding ASCII
        {
            get => Instance_Class.GetProperty(nameof(ASCII)).GetGetMethod().Invoke()?.GetValue<IL2Encoding>();
        }
        
        public static IL2Encoding UTF8
        {
            get => Instance_Class.GetProperty(nameof(UTF8)).GetGetMethod().Invoke()?.GetValue<IL2Encoding>();
        }

        public IL2String GetString(byte[] bytes)
        {
            IL2Array<byte> array = new IL2Array<byte>(bytes.Length, Assembler.list["mscorlib"].GetClass("Byte", "System"));
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = bytes[i];
            }
            return GetString(array);
        }

        public IL2String GetString(IL2Array<byte> bytes)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(GetString), x => x.GetParameters().Length == 1 && x.GetParameters()[0].Name == "bytes");
            if (method == null)
                return null;

            var result = method.Invoke(ptr, new IntPtr[] { bytes == null ? IntPtr.Zero : bytes.ptr });
            if (result == null)
                return null;

            return new IL2String(result.ptr);
        }
        
        public virtual IntPtr GetBytes(string s)
        {
            return Instance_Class.GetMethod(nameof(GetBytes),
                x => x.GetParameters().Length == 1
                && x.GetParameters()[0].ReturnType.Name == typeof(string).FullName).Invoke(ptr, new IntPtr[] { new IL2String(s).ptr }).ptr;
        }

        public static IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("Encoding", "System.Text");
    }
}
