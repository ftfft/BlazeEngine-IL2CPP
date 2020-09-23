using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    public unsafe static class Input
    {
        private static IL2Method methodGetAxis = null;
        public static float GetAxis(string axisName)
        {
            if (methodGetAxis == null)
            {
                methodGetAxis = Instance_Class.GetMethod("GetAxis");
                if (methodGetAxis == null)
                    return default;
            }

            IL2Object result = null;
            result = methodGetAxis.Invoke(new IntPtr[] { IL2Import.StringToIntPtr(axisName) });
            if (result == null)
                return default;

            return *(float*)result.Unbox();
        }

        private static IL2Method methodGetKey = null;
        public static bool GetKey(KeyCode key)
        {
            if (methodGetKey == null)
            {
                methodGetKey = Instance_Class.GetMethod("GetKeyInt");
                if (methodGetKey == null)
                    return default;
            }

            IL2Object result = null;
            result = methodGetKey.Invoke(new IntPtr[] { new IntPtr(&key) });
            if (result == null)
                return default;

            return *(bool*)result.Unbox();
        }


        private static IL2Method methodGetKeyDown = null;
        public static bool GetKeyDown(KeyCode key)
        {
            if (methodGetKeyDown == null)
            {
                methodGetKeyDown = Instance_Class.GetMethod("GetKeyDownInt");
                if (methodGetKeyDown == null)
                    return default;
            }

            IL2Object result = null;
            result = methodGetKeyDown.Invoke(new IntPtr[] { new IntPtr(&key) });
            if (result == null)
                return default;

            return *(bool*)result.Unbox();
        }

        private static IL2Method methodGetKeyUp = null;
        public static bool GetKeyUp(KeyCode key)
        {
            if (methodGetKeyUp == null)
            {
                methodGetKeyUp = Instance_Class.GetMethod("GetKeyUpInt");
                if (methodGetKeyUp == null)
                    return default;
            }

            IL2Object result = null;
            result = methodGetKeyUp.Invoke(new IntPtr[] { new IntPtr(&key) });
            if (result == null)
                return default;

            return *(bool*)result.Unbox();
        }

        private static IL2Property propertyMousePosition = null;
        public static Vector3 mousePosition
        {
            get
            {

                if (propertyMousePosition == null)
                {
                    propertyMousePosition = Instance_Class.GetProperty("mousePosition");
                    if (propertyMousePosition == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyMousePosition.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(Vector3*)result.Unbox();
            }
        }


        public static IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Input", "UnityEngine");
    }
}
