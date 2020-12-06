using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine.UI
{
    public class Selectable : Component
    {
        public Selectable(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public bool interactable
        {
            get => Instance_Class.GetProperty(nameof(interactable)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
            set => Instance_Class.GetProperty(nameof(interactable)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.UI"].GetClass("Selectable", "UnityEngine.UI");
    }
}
