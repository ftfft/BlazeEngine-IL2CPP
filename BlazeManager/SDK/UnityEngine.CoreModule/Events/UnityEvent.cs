using System;
using BlazeIL.il2cpp;

namespace UnityEngine.Events
{
    public class UnityEvent : UnityEventBase
    {
        public UnityEvent(IntPtr ptr) : base(ptr) => base.ptr = ptr;


        public void AddListener(UnityAction action, object _this = null)
        {
            IntPtr actionPtr = _UnityAction.CreateDelegate(action, _this);
            if (actionPtr == IntPtr.Zero)
                return;

            Instance_Class.GetMethod("AddListener").Invoke(ptr, new IntPtr[] { actionPtr });
        }

        public void AddListener<T, X>(UnityAction<T> action, X _this)
        {
            IntPtr actionPtr = _UnityAction.CreateDelegate(action, _this);
            if (actionPtr == IntPtr.Zero)
                return;

            Instance_Class.GetMethod("AddListener").Invoke(ptr, actionPtr);
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("UnityEvent", "UnityEngine.Events");
    }
}
