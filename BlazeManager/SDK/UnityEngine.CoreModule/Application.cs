using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
    public static class Application
    {
        public static int targetFrameRate
        {
            get => Instance_Class.GetProperty(nameof(targetFrameRate)).GetGetMethod().Invoke().unbox_Unmanaged<int>();
            set => Instance_Class.GetProperty(nameof(targetFrameRate)).GetSetMethod().Invoke(new IntPtr[] { value.MonoCast() });
        }

        public static string unityVersion
        {
            get => Instance_Class.GetProperty(nameof(unityVersion)).GetGetMethod().Invoke()?.unbox_ToString().ToString();
        }

        public static string streamingAssetsPath
        {
            get => Instance_Class.GetProperty(nameof(streamingAssetsPath)).GetGetMethod().Invoke()?.unbox_ToString().ToString();
        }

        public static IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Application", "UnityEngine");
    }
}
