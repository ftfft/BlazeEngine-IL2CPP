using System;
using System.Reflection;

namespace NET_SDK.ModLoader
{
    internal class Controller
    {
        private MethodInfo onPreStartMethod;
        private MethodInfo onApplicationStartMethod;
        private MethodInfo onApplicationFocusMethod;
        private MethodInfo onApplicationPauseMethod;
        private MethodInfo onApplicationQuitMethod;
        private MethodInfo onLevelWasLoadedMethod;
        private MethodInfo onLevelWasInitializedMethod;
        private MethodInfo onUpdateMethod;
        private MethodInfo onFixedUpdateMethod;
        private MethodInfo onLateUpdateMethod;
        private MethodInfo onUiManagerInitMethod;
        private MethodInfo onGUIMethod;
        private MethodInfo onModSettingsApplied;
        public Mod mod;

        public Controller(Mod mod, Type t)
        {
            this.mod = mod;
            MethodInfo[] methods = t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (MethodInfo method in methods)
            {
                if (method.Name.Equals("OnPreStart") && (method.GetParameters().Length == 0))
                    onPreStartMethod = method;
                else if (method.Name.Equals("OnApplicationStart") && (method.GetParameters().Length == 0))
                    onApplicationStartMethod = method;
                else if (method.Name.Equals("OnApplicationFocus") && (method.GetParameters().Length == 1) && (method.GetParameters()[0].ParameterType == typeof(bool)))
                    onApplicationFocusMethod = method;
                else if (method.Name.Equals("OnApplicationPause") && (method.GetParameters().Length == 1) && (method.GetParameters()[0].ParameterType == typeof(bool)))
                    onApplicationPauseMethod = method;
                else if (method.Name.Equals("OnApplicationQuit") && (method.GetParameters().Length == 0))
                    onApplicationQuitMethod = method;
                else if (method.Name.Equals("OnLevelWasLoaded") && (method.GetParameters().Length == 1) && (method.GetParameters()[0].ParameterType == typeof(int)))
                    onLevelWasLoadedMethod = method;
                else if (method.Name.Equals("OnLevelWasInitialized") && (method.GetParameters().Length == 1) && (method.GetParameters()[0].ParameterType == typeof(int)))
                    onLevelWasInitializedMethod = method;
                else if (method.Name.Equals("OnUpdate") && (method.GetParameters().Length == 0))
                    onUpdateMethod = method;
                else if (method.Name.Equals("OnFixedUpdate") && (method.GetParameters().Length == 0))
                    onFixedUpdateMethod = method;
                else if (method.Name.Equals("OnLateUpdate") && (method.GetParameters().Length == 0))
                    onLateUpdateMethod = method;
                else if (method.Name.Equals("OnUiManagerInit") && (method.GetParameters().Length == 0))
                   onUiManagerInitMethod = method;
                else if (method.Name.Equals("OnGUI") && (method.GetParameters().Length == 0))
                    onGUIMethod = method;
                else if (method.Name.Equals("OnModSettingsApplied") && (method.GetParameters().Length == 0))
                    onModSettingsApplied = method;
            }
        }

        public virtual void OnPreStart() { if (mod != null) onPreStartMethod?.Invoke(mod, new object[] { }); }
        public virtual void OnApplicationStart() { if (mod != null) onApplicationStartMethod?.Invoke(mod, new object[] { }); }
        public virtual void OnApplicationFocus(bool hasFocus) { if (mod != null) onApplicationFocusMethod?.Invoke(mod, new object[] { hasFocus }); }
        public virtual void OnApplicationPause(bool pauseStatus) { if (mod != null) onApplicationPauseMethod?.Invoke(mod, new object[] { pauseStatus }); }
        public virtual void OnApplicationQuit() { if (mod != null) onApplicationQuitMethod?.Invoke(mod, new object[] { }); }
        public virtual void OnLevelWasLoaded(int level) { if (mod != null) onLevelWasLoadedMethod?.Invoke(mod, new object[] { level }); }
        public virtual void OnLevelWasInitialized(int level) { if (mod != null) onLevelWasInitializedMethod?.Invoke(mod, new object[] { level }); }
        public virtual void OnUpdate() { if (mod != null) onUpdateMethod?.Invoke(mod, new object[] { }); }
        public virtual void OnFixedUpdate() { if (mod != null) onFixedUpdateMethod?.Invoke(mod, new object[] { }); }
        public virtual void OnLateUpdate() { if (mod != null) onLateUpdateMethod?.Invoke(mod, new object[] { }); }
        public virtual void OnUiManagerInit() { if (mod != null) onUiManagerInitMethod?.Invoke(mod, new object[] { }); }
        public virtual void OnGUI() { if (mod != null) onGUIMethod?.Invoke(mod, new object[] { }); }
        public virtual void OnModSettingsApplied() { if (mod != null) onModSettingsApplied?.Invoke(mod, new object[] { }); }
    }
}