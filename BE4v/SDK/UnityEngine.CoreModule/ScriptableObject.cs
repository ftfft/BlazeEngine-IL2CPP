using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
    public class ScriptableObject : Object
    {
        public ScriptableObject(IntPtr ptr) : base(ptr) => base.ptr = ptr;


        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("ScriptableObject", "UnityEngine");
    }
}
