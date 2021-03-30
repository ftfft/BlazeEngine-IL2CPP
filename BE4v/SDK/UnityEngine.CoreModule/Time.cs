using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
    public static class Time
    {
        public static float time
        {
            get => Instance_Class.GetProperty(nameof(time)).GetGetMethod().Invoke().GetValuе<float>();
        }

        public static float timeSinceLevelLoad
        {
            get => Instance_Class.GetProperty(nameof(timeSinceLevelLoad)).GetGetMethod().Invoke().GetValuе<float>();
        }

        public static float deltaTime
        {
            get => Instance_Class.GetProperty(nameof(deltaTime)).GetGetMethod().Invoke().GetValuе<float>();
        }

        public static float fixedTime
        {
            get => Instance_Class.GetProperty(nameof(fixedTime)).GetGetMethod().Invoke().GetValuе<float>();
        }

        public static float unscaledTime
        {
            get => Instance_Class.GetProperty(nameof(unscaledTime)).GetGetMethod().Invoke().GetValuе<float>();
        }

        public static float fixedUnscaledTime
        {
            get => Instance_Class.GetProperty(nameof(fixedUnscaledTime)).GetGetMethod().Invoke().GetValuе<float>();
        }

        public static float unscaledDeltaTime
        {
            get => Instance_Class.GetProperty(nameof(unscaledDeltaTime)).GetGetMethod().Invoke().GetValuе<float>();
        }
        
        public static float fixedUnscaledDeltaTime
        {
            get => Instance_Class.GetProperty(nameof(fixedUnscaledDeltaTime)).GetGetMethod().Invoke().GetValuе<float>();
        }

        public static float fixedDeltaTime
        {
            get => Instance_Class.GetProperty(nameof(fixedDeltaTime)).GetGetMethod().Invoke().GetValuе<float>();
            set => Instance_Class.GetProperty(nameof(fixedDeltaTime)).GetSetMethod().Invoke(new IntPtr[] { value.MonoCast() });
        }

        public static float maximumDeltaTime
        {
            get => Instance_Class.GetProperty(nameof(maximumDeltaTime)).GetGetMethod().Invoke().GetValuе<float>();
        }

        public static float smoothDeltaTime
        {
            get => Instance_Class.GetProperty(nameof(smoothDeltaTime)).GetGetMethod().Invoke().GetValuе<float>();
        }

        public static float timeScale
        {
            get => Instance_Class.GetProperty(nameof(timeScale)).GetGetMethod().Invoke().GetValuе<float>();
            set => Instance_Class.GetProperty(nameof(timeScale)).GetSetMethod().Invoke(new IntPtr[] { value.MonoCast() });
        }

        public static int frameCount
        {
            get => Instance_Class.GetProperty(nameof(frameCount)).GetGetMethod().Invoke().GetValuе<int>();
        }

        public static int renderedFrameCount
        {
            get => Instance_Class.GetProperty(nameof(renderedFrameCount)).GetGetMethod().Invoke().GetValuе<int>();
        }

        public static float realtimeSinceStartup
        {
            get => Instance_Class.GetProperty(nameof(realtimeSinceStartup)).GetGetMethod().Invoke().GetValuе<float>();
        }

        public static int captureFramerate
        {
            get => Instance_Class.GetProperty(nameof(captureFramerate)).GetGetMethod().Invoke().GetValuе<int>();
        }

        public static bool inFixedTimeStep
        {
            get => Instance_Class.GetProperty(nameof(inFixedTimeStep)).GetGetMethod().Invoke().GetValuе<bool>();
        }

        public static IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("Time", "UnityEngine");
    }
}
