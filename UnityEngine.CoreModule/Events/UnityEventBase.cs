using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine.Events
{
    public class UnityEventBase : IL2Base
    {
        public UnityEventBase(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Method methodRemoveAllListeners = null;
        public void RemoveAllListeners()
        {
            if (methodRemoveAllListeners == null)
            {
                methodRemoveAllListeners = Instance_Class.GetMethod("RemoveAllListeners");
                if (methodRemoveAllListeners == null)
                    return;
            }

            methodRemoveAllListeners.Invoke(ptr);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(UnityEventBase))
                return false;
            return ((UnityEventBase)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();


        public static IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("UnityEventBase", "UnityEngine.Events");
    }
}
