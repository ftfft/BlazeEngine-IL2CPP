using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine.Events
{
    public class UnityEventBase : IL2Base
    {
        public UnityEventBase(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public void RemoveAllListeners()
        {
            Instance_Class.GetMethod(nameof(RemoveAllListeners)).Invoke(ptr);
        }

        public static IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("UnityEventBase", "UnityEngine.Events");
    }
}
