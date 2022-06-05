using BE4v.SDK.CPP2IL;
using System;

namespace UnityEngine.Events
{
    public class UnityEvent : UnityEventBase
    {
        public UnityEvent(IntPtr ptr) : base(ptr) => base.ptr = ptr;


        public void AddListener(UnityAction action)
        {
            IL2Delegate @delegate = IL2Delegate.CreateDelegate(action, Assembler.list["UnityEngine.CoreModule"].GetClass("UnityAction", "UnityEngine.Events"));
            Instance_Class.GetMethod("AddListener").Invoke(ptr, new IntPtr[] { @delegate == null ? IntPtr.Zero : @delegate.ptr });
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("UnityEvent", "UnityEngine.Events");
    }
}
