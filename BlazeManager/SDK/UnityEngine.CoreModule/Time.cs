using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    public static class Time
    {
        public static float time
        {
            get => Instance_Class.GetProperty(nameof(time)).GetGetMethod().Invoke().unbox_Unmanaged<float>();
        }

        public static float timeSinceLevelLoad
        {
            get => Instance_Class.GetProperty(nameof(timeSinceLevelLoad)).GetGetMethod().Invoke().unbox_Unmanaged<float>();
        }

        public static float deltaTime
        {
            get => Instance_Class.GetProperty(nameof(deltaTime)).GetGetMethod().Invoke().unbox_Unmanaged<float>();
        }

        public static float fixedTime
        {
            get => Instance_Class.GetProperty(nameof(fixedTime)).GetGetMethod().Invoke().unbox_Unmanaged<float>();
        }

        public static float unscaledTime
        {
            get => Instance_Class.GetProperty(nameof(unscaledTime)).GetGetMethod().Invoke().unbox_Unmanaged<float>();
        }

        public static float fixedUnscaledTime
        {
            get => Instance_Class.GetProperty(nameof(fixedUnscaledTime)).GetGetMethod().Invoke().unbox_Unmanaged<float>();
        }

        public static float unscaledDeltaTime
        {
            get => Instance_Class.GetProperty(nameof(unscaledDeltaTime)).GetGetMethod().Invoke().unbox_Unmanaged<float>();
        }
        
        public static float fixedUnscaledDeltaTime
        {
            get => Instance_Class.GetProperty(nameof(fixedUnscaledDeltaTime)).GetGetMethod().Invoke().unbox_Unmanaged<float>();
        }

        public static float fixedDeltaTime
        {
            get => Instance_Class.GetProperty(nameof(fixedDeltaTime)).GetGetMethod().Invoke().unbox_Unmanaged<float>();
            set => Instance_Class.GetProperty(nameof(fixedDeltaTime)).GetSetMethod().Invoke(new IntPtr[] { value.MonoCast() });
        }

        public static float maximumDeltaTime
        {
            get => Instance_Class.GetProperty(nameof(maximumDeltaTime)).GetGetMethod().Invoke().unbox_Unmanaged<float>();
        }

        public static float smoothDeltaTime
        {
            get => Instance_Class.GetProperty(nameof(smoothDeltaTime)).GetGetMethod().Invoke().unbox_Unmanaged<float>();
        }

        public static float timeScale
        {
            get => Instance_Class.GetProperty(nameof(timeScale)).GetGetMethod().Invoke().unbox_Unmanaged<float>();
            set => Instance_Class.GetProperty(nameof(timeScale)).GetSetMethod().Invoke(new IntPtr[] { value.MonoCast() });
        }

        public static int frameCount
        {
            get => Instance_Class.GetProperty(nameof(frameCount)).GetGetMethod().Invoke().unbox_Unmanaged<int>();
        }

        public static int renderedFrameCount
        {
            get => Instance_Class.GetProperty(nameof(renderedFrameCount)).GetGetMethod().Invoke().unbox_Unmanaged<int>();
        }

        public static float realtimeSinceStartup
        {
            get => Instance_Class.GetProperty(nameof(realtimeSinceStartup)).GetGetMethod().Invoke().unbox_Unmanaged<float>();
        }

        public static int captureFramerate
        {
            get => Instance_Class.GetProperty(nameof(captureFramerate)).GetGetMethod().Invoke().unbox_Unmanaged<int>();
        }

        public static bool inFixedTimeStep
        {
            get => Instance_Class.GetProperty(nameof(inFixedTimeStep)).GetGetMethod().Invoke().unbox_Unmanaged<bool>();
        }

        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.unityenginecoremodule]].GetClass("Time", "UnityEngine");
    }
}
