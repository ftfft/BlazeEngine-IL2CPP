using System;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine.Events
{
    public class UnityEventBase : IL2Base
    {
        public UnityEventBase(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public void RemoveAllListeners()
        {
            Instance_Class.GetMethod("RemoveAllListeners").Invoke(ptr);
        }

        public static IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("UnityEventBase", "UnityEngine.Events");
    }
}
