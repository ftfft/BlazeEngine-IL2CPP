using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using UnityEngine.Events;

namespace VRC.Core
{
    public class ApiContainer : IL2Base
    {
        public ApiContainer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public ApiContainer() : base(IntPtr.Zero)
        {
            ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetMethod(".ctor").Invoke(ptr);
        }

        /*
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
        */

        public static IL2Class Instance_Class = Assembler.list["VRCCore-Standalone"].GetClass("ApiContainer", "VRC.Core");
    }
}
