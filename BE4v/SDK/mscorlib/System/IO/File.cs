using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

namespace System.IO
{
    public static class IL2File
    {
        public static void WriteAllBytes(string path, IntPtr bytes)
        {
            Instance_Class.GetMethod(nameof(WriteAllBytes)).Invoke(new IntPtr[] { new IL2String(path).ptr, bytes });
        }

        public static IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("File", "System.IO");
    }
}
