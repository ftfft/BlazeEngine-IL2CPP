using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    public unsafe sealed class Camera : Component
    {
        public Camera(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyMain = null;
        public static Camera main
        {
            get
            {
                if (propertyMain == null)
                {
                    propertyMain = Instance_Class.GetProperty("main");
                    if (propertyMain == null)
                        return null;
                }

                IL2Object result = propertyMain.GetGetMethod().Invoke();
                if (result == null)
                    return null;

                return result.ptr.MonoCast<Camera>();
            }
        }

        private static IL2Property propertyCurrent = null;
        public static Camera current
        {
            get
            {
                if (propertyCurrent == null)
                {
                    propertyCurrent = Instance_Class.GetProperty("current");
                    if (propertyCurrent == null)
                        return null;
                }

                return propertyCurrent.GetGetMethod().Invoke().ptr.MonoCast<Camera>();
            }
        }


        private static IL2Method ScreenPointToRay1 = null;
        public Ray ScreenPointToRay(Vector3 pos)
        {
            if (ScreenPointToRay1 == null)
            {
                ScreenPointToRay1 = Instance_Class.GetMethod("ScreenPointToRay", x => x.GetParameters().Length == 1);
                if (ScreenPointToRay1 == null)
                    return default;
            }

            IL2Object result = ScreenPointToRay1.Invoke(ptr, new IntPtr[] { new IntPtr(&pos) });
            if (result == null)
                return default;

            return *(Ray*)result.Unbox();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Camera))
                return false;
            return ((Camera)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Camera", "UnityEngine");
    }
}
