using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    unsafe public class Time
    {
        private static IL2Property propertyTime = null;
        public static float time
        {
            get
            {
                if (propertyTime == null)
                {
                    propertyTime = Instance_Class.GetProperty("time");
                    if (propertyTime == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyTime.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(float*)result.Unbox();
            }
        }

        private static IL2Property propertyTimeSinceLevelLoad = null;
        public static float timeSinceLevelLoad
        {
            get
            {
                if (propertyTimeSinceLevelLoad == null)
                {
                    propertyTimeSinceLevelLoad = Instance_Class.GetProperty("timeSinceLevelLoad");
                    if (propertyTimeSinceLevelLoad == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyTimeSinceLevelLoad.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(float*)result.Unbox();
            }
        }
        private static IL2Property propertyDeltaTime = null;
        public static float deltaTime
        {
            get
            {
                if (propertyDeltaTime == null)
                {
                    propertyDeltaTime = Instance_Class.GetProperty("deltaTime");
                    if (propertyDeltaTime == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyDeltaTime.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(float*)result.Unbox();
            }
        }

        private static IL2Property propertyFixedTime = null;
        public static float fixedTime
        {
            get
            {
                if (propertyFixedTime == null)
                {
                    propertyFixedTime = Instance_Class.GetProperty("fixedTime");
                    if (propertyFixedTime == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyFixedTime.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(float*)result.Unbox();
            }
        }

        private static IL2Property propertyUnscaledTime = null;
        public static float unscaledTime
        {
            get
            {
                if (propertyUnscaledTime == null)
                {
                    propertyUnscaledTime = Instance_Class.GetProperty("unscaledTime");
                    if (propertyUnscaledTime == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyUnscaledTime.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(float*)result.Unbox();
            }
        }

        private static IL2Property propertyFixedUnscaledTime = null;
        public static float fixedUnscaledTime
        {
            get
            {
                if (propertyFixedUnscaledTime == null)
                {
                    propertyFixedUnscaledTime = Instance_Class.GetProperty("fixedUnscaledTime");
                    if (propertyFixedUnscaledTime == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyFixedUnscaledTime.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(float*)result.Unbox();
            }
        }

        private static IL2Property propertyUnscaledDeltaTime = null;
        public static float unscaledDeltaTime
        {
            get
            {
                if (propertyUnscaledDeltaTime == null)
                {
                    propertyUnscaledDeltaTime = Instance_Class.GetProperty("unscaledDeltaTime");
                    if (propertyUnscaledDeltaTime == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyUnscaledDeltaTime.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(float*)result.Unbox();
            }
        }
        
        private static IL2Property propertyFixedUnscaledDeltaTime = null;
        public static float fixedUnscaledDeltaTime
        {
            get
            {
                if (propertyFixedUnscaledDeltaTime == null)
                {
                    propertyFixedUnscaledDeltaTime = Instance_Class.GetProperty("fixedUnscaledDeltaTime");
                    if (propertyFixedUnscaledDeltaTime == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyFixedUnscaledDeltaTime.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(float*)result.Unbox();
            }
        }

        private static IL2Property propertyFixedDeltaTime = null;
        public static float fixedDeltaTime
        {
            get
            {
                if (propertyFixedDeltaTime == null)
                {
                    propertyFixedDeltaTime = Instance_Class.GetProperty("fixedDeltaTime");
                    if (propertyFixedDeltaTime == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyFixedDeltaTime.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(float*)result.Unbox();
            }
            set
            {
                if (propertyFixedDeltaTime == null)
                {
                    propertyFixedDeltaTime = Instance_Class.GetProperty("fixedDeltaTime");
                    if (propertyFixedDeltaTime == null)
                        return;
                }

                propertyFixedDeltaTime.GetSetMethod().Invoke(new IntPtr[] { new IntPtr(&value) });
            }
        }

        private static IL2Property propertyMaximumDeltaTime = null;
        public static float maximumDeltaTime
        {
            get
            {
                if (propertyMaximumDeltaTime == null)
                {
                    propertyMaximumDeltaTime = Instance_Class.GetProperty("maximumDeltaTime");
                    if (propertyMaximumDeltaTime == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyMaximumDeltaTime.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(float*)result.Unbox();
            }
        }

        private static IL2Property propertySmoothDeltaTime = null;
        public static float smoothDeltaTime
        {
            get
            {
                if (propertySmoothDeltaTime == null)
                {
                    propertySmoothDeltaTime = Instance_Class.GetProperty("smoothDeltaTime");
                    if (propertySmoothDeltaTime == null)
                        return default;
                }
                
                IL2Object result = null;
                result = propertySmoothDeltaTime.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(float*)result.Unbox();
            }
        }

        private static IL2Property propertyTimeScale = null;
        public static float timeScale
        {
            get
            {
                if (propertyTimeScale == null)
                {
                    propertyTimeScale = Instance_Class.GetProperty("timeScale");
                    if (propertyTimeScale == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyTimeScale.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(float*)result.Unbox();
            }
            set
            {
                if (propertyTimeScale == null)
                {
                    propertyTimeScale = Instance_Class.GetProperty("timeScale");
                    if (propertyTimeScale == null)
                        return;
                }

                propertyTimeScale.GetSetMethod().Invoke(new IntPtr[] { new IntPtr(&value) });
            }
        }

        private static IL2Property propertyFrameCount = null;
        public static int frameCount
        {
            get
            {
                if (propertyFrameCount == null)
                {
                    propertyFrameCount = Instance_Class.GetProperty("frameCount");
                    if (propertyFrameCount == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyFrameCount.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(int*)result.Unbox();
            }
        }

        private static IL2Property propertyRenderedFrameCount = null;
        public static int renderedFrameCount
        {
            get
            {
                if (propertyRenderedFrameCount == null)
                {
                    propertyRenderedFrameCount = Instance_Class.GetProperty("renderedFrameCount");
                    if (propertyRenderedFrameCount == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyRenderedFrameCount.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(int*)result.Unbox();
            }
        }

        private static IL2Property propertyRealtimeSinceStartup = null;
        public static float realtimeSinceStartup
        {
            get
            {
                if (propertyRealtimeSinceStartup == null)
                {
                    propertyRealtimeSinceStartup = Instance_Class.GetProperty("realtimeSinceStartup");
                    if (propertyRealtimeSinceStartup == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyRealtimeSinceStartup.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(float*)result.Unbox();
            }
        }

        private static IL2Property propertyCaptureFramerate = null;
        public static int captureFramerate
        {
            get
            {
                if (propertyCaptureFramerate == null)
                {
                    propertyCaptureFramerate = Instance_Class.GetProperty("captureFramerate");
                    if (propertyCaptureFramerate == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyCaptureFramerate.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(int*)result.Unbox();
            }
        }

        private static IL2Property propertyInFixedTimeStep = null;
        public static bool inFixedTimeStep
        {
            get
            {
                if (propertyInFixedTimeStep == null)
                {
                    propertyInFixedTimeStep = Instance_Class.GetProperty("inFixedTimeStep");
                    if (propertyInFixedTimeStep == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyInFixedTimeStep.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(bool*)result.Unbox();
            }
        }

        public static IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Time", "UnityEngine");
    }
}
