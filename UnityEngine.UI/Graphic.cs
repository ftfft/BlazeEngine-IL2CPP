using System;
using BlazeIL.il2cpp;

namespace UnityEngine.UI
{
    // Graphic -> UIBehaviour -> MonoBehaviour -> Behaviour -> Component
    unsafe public class Graphic : Component
    {
        public Graphic(IntPtr ptrONew) : base(ptrONew) =>
            ptr = ptrONew;

        private static IL2Property propertyColor = null;
        public Color color
        {
            get
            {
                if (propertyColor == null)
                {
                    propertyColor = Instance_Class.GetProperty("color");
                    if (propertyColor == null)
                        return Color.white;
                }

                IL2Object result = null;
                if (result == null)
                    return Color.white;

                return *(Color*)result.Unbox();
            }
            set
            {
                if (propertyColor == null)
                {
                    propertyColor = Instance_Class.GetProperty("color");
                    if (propertyColor == null)
                        return;
                }

                propertyColor.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Graphic))
                return false;
            return ((Graphic)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.UI"].GetClass("Graphic", "UnityEngine.UI");
    }
}
