using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    public unsafe class Application
    {
        private static IL2Property propertyTargetFrameRate = null;
        public static int targetFrameRate
        {
            get
            {
                if (propertyTargetFrameRate == null)
                {
                    propertyTargetFrameRate = Instance_Class.GetProperty("targetFrameRate");
                    if (propertyTargetFrameRate == null)
                        return -1;
                }

                IL2Object result = propertyTargetFrameRate.GetGetMethod().Invoke();
                if (result == null)
                    return -1;

                return *(int*)result.Unbox();
            }
            set
            {
                if (propertyTargetFrameRate == null)
                {
                    propertyTargetFrameRate = Instance_Class.GetProperty("targetFrameRate");
                    if (propertyTargetFrameRate == null)
                        return;
                }

                propertyTargetFrameRate.GetSetMethod().Invoke(new IntPtr[] { new IntPtr(&value) });
            }
        }

        private static IL2Property propertyUnityVersion = null;
        public static string unityVersion
        {
            get
            {
                if (propertyUnityVersion == null)
                {
                    propertyUnityVersion = Instance_Class.GetProperty("unityVersion");
                    if (propertyUnityVersion == null)
                        return null;
                }

                IL2Object result = propertyUnityVersion.GetGetMethod().Invoke();
                if (result == null)
                    return null;

                return result.UnboxString();
            }
        }

        public static IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Application", "UnityEngine");
    }
}
