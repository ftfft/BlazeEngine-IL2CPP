using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine.UI
{
    public class Button : Selectable
    {
        public Button(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public ButtonClickedEvent onClick
        {
            get => Instance_Class.GetProperty(nameof(onClick)).GetGetMethod().Invoke(ptr)?.unbox<ButtonClickedEvent>();
            set => Instance_Class.GetProperty(nameof(onClick)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
        }

        public class ButtonClickedEvent : Events.UnityEvent
        {
            public ButtonClickedEvent(IntPtr ptr) : base(ptr) => base.ptr = ptr;

            public ButtonClickedEvent() : base(IntPtr.Zero)
            {
                ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
                Instance_Class.GetConstructor().Invoke(ptr);
            }

            public static new IL2Type Instance_Class = Button.Instance_Class.GetNestedType("ButtonClickedEvent");
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.UI"].GetClass("Button", "UnityEngine.UI");
    }
}
