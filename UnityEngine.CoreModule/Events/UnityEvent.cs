using System;
using BlazeIL.il2cpp;

namespace UnityEngine.Events
{
    public class UnityEvent : UnityEventBase
    {
        public UnityEvent(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;


        private static IL2Method methodAddListener = null;
        public void AddListener(UnityAction action, object _this = null)
        {
            if (methodAddListener == null)
            {
                methodAddListener = Instance_Class.GetMethod("AddListener");
                if (methodAddListener == null)
                    return;
            }

            IntPtr actionPtr = _UnityAction.CreateDelegate(action, _this);
            if (actionPtr == IntPtr.Zero)
                return;

            methodAddListener.Invoke(ptr, new IntPtr[] { actionPtr });
        }

        public void AddListener<T, X>(UnityAction<T> action, X _this)
        {
            if (methodAddListener == null)
            {
                methodAddListener = Instance_Class.GetMethod("AddListener");
                if (methodAddListener == null)
                    return;
            }

            IntPtr actionPtr = _UnityAction.CreateDelegate(action, _this);
            if (actionPtr == IntPtr.Zero)
                return;

            methodAddListener.Invoke(ptr, actionPtr);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(UnityEvent))
                return false;
            return ((UnityEvent)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("UnityEvent", "UnityEngine.Events");
    }
}
