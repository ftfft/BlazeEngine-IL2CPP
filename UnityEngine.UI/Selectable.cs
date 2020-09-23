using System;
using BlazeIL.il2cpp;

namespace UnityEngine.UI
{
    unsafe public class Selectable : Component
    {
        public Selectable(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyInteractable = null;
        public bool interactable
        {
            get
            {
                if (propertyInteractable == null)
                {
                    propertyInteractable = Instance_Class.GetProperty("interactable");
                    if (propertyInteractable == null)
                        return default;
                }

                IL2Object result = propertyInteractable.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return *(bool*)result.Unbox();
            }
            set
            {
                if (propertyInteractable == null)
                {
                    propertyInteractable = Instance_Class.GetProperty("interactable");
                    if (propertyInteractable == null)
                        return;
                }

                propertyInteractable.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Selectable))
                return false;
            return ((Selectable)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.UI"].GetClass("Selectable", "UnityEngine.UI");
    }
}
