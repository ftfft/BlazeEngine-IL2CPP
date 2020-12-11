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
            Instance_Class.GetMethod(nameof(RemoveAllListeners)).Invoke(ptr);
        }

        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.unityenginecoremodule]].GetClass("UnityEventBase", "UnityEngine.Events");
    }
}
