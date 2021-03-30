using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine.UI
{
    public class Button : Selectable
    {
        public Button(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public ButtonClickedEvent onClick
        {
            get => Instance_Class.GetProperty(nameof(onClick)).GetGetMethod().Invoke(ptr)?.GetValue<ButtonClickedEvent>();
            set => Instance_Class.GetProperty(nameof(onClick)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
        }

        public class ButtonClickedEvent : Events.UnityEvent
        {
            public ButtonClickedEvent(IntPtr ptr) : base(ptr) => base.ptr = ptr;

            public ButtonClickedEvent() : base(IntPtr.Zero)
            {
                ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
                Instance_Class.GetMethod(".ctor").Invoke(ptr);
            }

            public static new IL2Class Instance_Class = Button.Instance_Class.GetNestedType("ButtonClickedEvent");
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UI"].GetClass("Button", "UnityEngine.UI");
    }
}
