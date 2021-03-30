using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine.UI
{
    public class Selectable : Component
    {
        public Selectable(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public bool interactable
        {
            get => Instance_Class.GetProperty(nameof(interactable)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
            set => Instance_Class.GetProperty(nameof(interactable)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UI"].GetClass("Selectable", "UnityEngine.UI");
    }
}
