using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine.UI
{
    public class Button : Selectable
    {
        public Button(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyOnClick = null;
        public ButtonClickedEvent onClick
        {
            get
            {
                if (propertyOnClick == null)
                {
                    propertyOnClick = Instance_Class.GetProperty("onClick");
                    if (propertyOnClick == null)
                        return null;
                }

                IL2Object result = propertyOnClick.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return null;

                return result.ptr.MonoCast<ButtonClickedEvent>();
            }
            set
            {
                if (propertyOnClick == null)
                {
                    propertyOnClick = Instance_Class.GetProperty("onClick");
                    if (propertyOnClick == null)
                        return;
                }

                propertyOnClick.GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
            }
        }

        public class ButtonClickedEvent : Events.UnityEvent
        {
            public ButtonClickedEvent(IntPtr ptrNew) : base(ptrNew) =>
                ptr = ptrNew;

            public static IL2Method constructButtonClickEvent = null;
            public ButtonClickedEvent() : base(IntPtr.Zero)
            {
                if (constructButtonClickEvent == null)
                {
                    constructButtonClickEvent = Instance_Class.GetMethod(".ctor");
                    if (constructButtonClickEvent == null)
                        return;
                }

                ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
                constructButtonClickEvent.Invoke(ptr);
            }

            public override bool Equals(object obj)
            {
                if (obj.GetType() != typeof(ButtonClickedEvent))
                    return false;
                return ((ButtonClickedEvent)obj).ptr == ptr;
            }

            public override int GetHashCode() =>
                ptr.GetHashCode();

            public static new IL2Type Instance_Class = Button.Instance_Class.GetNestedType("ButtonClickedEvent");
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Button))
                return false;
            return ((Button)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.UI"].GetClass("Button", "UnityEngine.UI");
    }
}
