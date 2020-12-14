using System;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine.Events;

namespace VRC.Core
{
    public class ApiContainer : IL2Base
    {
        public ApiContainer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public ApiContainer() : base(IntPtr.Zero)
        {
            ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetConstructor().Invoke(ptr);
        }


        // Action<ApiContainer>
        public Delegate OnError
        {
            // get => Instance_Class.GetField(nameof(OnError)).GetValue(ptr);
            set => Instance_Class.GetField(nameof(OnError)).SetValue(ptr, _UnityAction.CreateDelegate(value, IntPtr.Zero, BlazeTools.IL2SystemClass.action));
        }

        public Delegate OnSuccess
        {
            // get => Instance_Class.GetField(nameof(OnSuccess)).GetValue(ptr).ptr;
            set => Instance_Class.GetField(nameof(OnSuccess)).SetValue(ptr, _UnityAction.CreateDelegate(value, IntPtr.Zero, BlazeTools.IL2SystemClass.action));
        }

        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.vrccorestandalone]].GetClass("ApiContainer", "VRC.Core");
    }
}
