using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    unsafe public class RectTransform : Transform
    {
        public RectTransform(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyAnchoredPosition = null;
        public Vector2 anchoredPosition
        {
            get
            {
                if (propertyAnchoredPosition == null)
                {
                    propertyAnchoredPosition = Instance_Class.GetProperty("anchoredPosition");
                    if (propertyAnchoredPosition == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyAnchoredPosition.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return *(Vector2*)result.Unbox();
            }
            set
            {
                if (propertyAnchoredPosition == null)
                {
                    propertyAnchoredPosition = Instance_Class.GetProperty("anchoredPosition");
                    if (propertyAnchoredPosition == null)
                        return;
                }

                propertyAnchoredPosition.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
            }
        }

        private static IL2Property propertySizeDelta = null;
        public Vector2 sizeDelta
        {
            get
            {
                if (propertySizeDelta == null)
                {
                    propertySizeDelta = Instance_Class.GetProperty("sizeDelta");
                    if (propertySizeDelta == null)
                        return default;
                }

                IL2Object result = null;
                result = propertySizeDelta.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return *(Vector2*)result.Unbox();
            }
            set
            {
                if (propertySizeDelta == null)
                {
                    propertySizeDelta = Instance_Class.GetProperty("sizeDelta");
                    if (propertySizeDelta == null)
                        return;
                }

                propertySizeDelta.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(RectTransform))
                return false;
            return ((RectTransform)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("RectTransform", "UnityEngine");
    }
}
