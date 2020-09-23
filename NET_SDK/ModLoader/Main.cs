using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NET_SDK.Reflection;

namespace NET_SDK.ModLoader
{
    public class Main
    {
        public static List<Mod> Mods = new List<Mod>();
        private static List<Controller> ModControllers = new List<Controller>();

        private static Harmony.Instance harmonyInstance;
        internal static Harmony.Patch onApplicationQuit;
        internal static Harmony.Patch onApplicationFocus;
        internal static Harmony.Patch onApplicationPause;
        internal static Harmony.Patch onUpdate;
        internal static Harmony.Patch onLateUpdate;
        internal static Harmony.Patch onFixedUpdate;
        internal static Harmony.Patch onGUI;

        unsafe internal static void Initialize()
        {
            if (Environment.CommandLine.Contains("--vrcloader.debug"))
                Logger.consoleEnabled = true;
            else if (Environment.CommandLine.Contains("--netsdk.console"))
            {
                Logger.consoleEnabled = true;
                DebugConsole.Create();
            }

            Logger.Initialize();
            SDK.Initialize();

            Logger.Log("-----------------------------");
            Logger.Log("Using " + SDK_FileInfo.Name + " " + SDK_FileInfo.Version);
            Logger.Log("-----------------------------");

            string modDirectory = Path.Combine(Environment.CurrentDirectory, "Mods");
            if (!Directory.Exists(modDirectory))
                Directory.CreateDirectory(modDirectory);
            else
            {
                List<Assembly> loadedAssemblies = new List<Assembly>();

                //uint modslist_length = IL2CPP.vrcloader_get_net_mod_count();
                //if (modslist_length > 0)
                //{
                //for (uint i = 0; i < modslist_length; i++)
                //{
                //    string s = IL2CPP.vrcloader_get_net_mod(i);
                    string[] files = Directory.GetFiles(modDirectory, "*.dll");
                    foreach (string s in files)
                    {
                        if (!File.Exists(s) || !s.EndsWith(".dll", true, null))
                            return;
                        Logger.Log("Loading " + Path.GetFileName(s));
                        try
                        {
                            byte[] data = File.ReadAllBytes(s);
                            Assembly a = Assembly.Load(data);
                            loadedAssemblies.Add(a);
                        }
                        catch (Exception e)
                        {
                            Logger.LogError("Unable to load Assembly " + s + ":\n" + e);
                        }
                    }
                //}

                if (loadedAssemblies.Count() > 0)
                {
                    foreach (Assembly a in loadedAssemblies)
                        LoadModsFromAssembly(a);
                }
                if (Mods.Count() > 0)
                {
                    Logger.Log("-----------------------------");
                    foreach (var mod in Mods)
                        Logger.Log(mod.Name + " (" + mod.Version + ") by " + mod.Author + (mod.DownloadLink != null ? " (" + mod.DownloadLink + ")" : ""));
                    Logger.Log("-----------------------------");
                    InitialSetup();
                    OnPreStart();
                }
            }
        }

        private static void InitialSetup()
        {
            harmonyInstance = Harmony.Manager.CreateMainInstance();
            IL2CPP_Class VRCApplication = SDK.GetClass("VRCApplication");
            onApplicationQuit = harmonyInstance.Patch(VRCApplication.GetMethod("OnApplicationQuit"), typeof(FakeThisDelegateClass).GetMethod("OnApplicationQuit", BindingFlags.Instance | BindingFlags.Public));
            onApplicationFocus = harmonyInstance.Patch(VRCApplication.GetMethod("OnApplicationFocus"), typeof(FakeThisDelegateClass).GetMethod("OnApplicationFocus", BindingFlags.Instance | BindingFlags.Public));
            onApplicationPause = harmonyInstance.Patch(VRCApplication.GetMethod("OnApplicationPause"), typeof(FakeThisDelegateClass).GetMethod("OnApplicationPause", BindingFlags.Instance | BindingFlags.Public));
            //onUpdate = harmonyInstance.Patch(SDK.GetClass("VRCAudioManager").GetMethod("Update"), typeof(FakeThisDelegateClass).GetMethod("Update", BindingFlags.Instance | BindingFlags.Public));
            onLateUpdate = harmonyInstance.Patch(SDK.GetClass("VRCUiManager").GetMethod("LateUpdate"), typeof(FakeThisDelegateClass).GetMethod("LateUpdate", BindingFlags.Instance | BindingFlags.Public));
            onFixedUpdate = harmonyInstance.Patch(SDK.GetClass("Photon.Pun.PhotonHandler").GetMethod("FixedUpdate"), typeof(FakeThisDelegateClass).GetMethod("FixedUpdate", BindingFlags.Instance | BindingFlags.Public));
            //onGUI = harmonyInstance.Patch(SDK.GetClass("VRGUI").GetMethod("OnGUI"), typeof(FakeThisDelegateClass).GetMethod("OnGUI", BindingFlags.Instance | BindingFlags.Public));
        }

        private static void LoadModsFromAssembly(Assembly assembly)
        {
            try
            {
                foreach (Type t in GetLoadableTypes(assembly))
                {
                    if (t.IsSubclassOf(typeof(Mod)))
                    {
                        try
                        {
                            Mod modInstance = Activator.CreateInstance(t) as Mod;
                            Mods.Add(modInstance);
                            ModControllers.Add(new Controller(modInstance, t));
                            ModInfoAttribute modInfoAttribute = modInstance.GetType().GetCustomAttributes(typeof(ModInfoAttribute), true).FirstOrDefault() as ModInfoAttribute;
                            if (modInfoAttribute != null)
                            {
                                modInstance.Name = modInfoAttribute.Name;
                                modInstance.Version = modInfoAttribute.Version;
                                modInstance.Author = modInfoAttribute.Author;
                                modInstance.DownloadLink = modInfoAttribute.DownloadLink;
                            }
                        }
                        catch (Exception e)
                        {
                            Logger.LogError("Could not load mod " + t.FullName + " in " + assembly.GetName() + "! " + e);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logger.LogError("Could not load " + assembly.GetName() + "! " + e);
            }
        }

        public static IEnumerable<Type> GetLoadableTypes(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                Logger.LogError("An error occured while getting types from assembly " + assembly.GetName().Name + ". Returning types from error.\n" + e);
                return e.Types.Where(t => t != null);
            }
        }

        private static IL2CPP_Class VRCUiManager = null;
        private static IL2CPP_Method VRCUiManager_GetInstance = null;
        private static bool shouldCheckForUiManager = true;
        private static void CheckForUiManager()
        {
            if (shouldCheckForUiManager)
            {
                if (VRCUiManager == null)
                    VRCUiManager = SDK.GetClass("VRCUiManager");
                if (VRCUiManager != null)
                {
                    if (VRCUiManager_GetInstance == null)
                    {
                        IL2CPP_Method[] methods = VRCUiManager.GetMethods();
                        foreach (IL2CPP_Method method in methods)
                        {
                            IL2CPP_Type returntype = method.GetReturnType();
                            if ((returntype != null) && (IL2CPP.il2cpp_type_get_name(returntype.Ptr) == "VRCUiManager"))
                            {
                                if (method.HasFlag(IL2CPP_BindingFlags.METHOD_STATIC))
                                {
                                    VRCUiManager_GetInstance = method;
                                    break;
                                }
                            }
                        }
                    }
                    if (VRCUiManager_GetInstance != null)
                    {
                        IL2CPP_Object returnval = VRCUiManager_GetInstance.Invoke();
                        if (returnval != null)
                        {
                            shouldCheckForUiManager = false;
                            OnUiManagerInit();
                        }
                    }
                }
            }
        }

        private static IL2CPP_Class SceneManager = null;
        private static IL2CPP_Method SceneManager_GetActiveScene_Method = null;
        unsafe internal static int GetActiveSceneIndex()
        {
            if (SceneManager == null)
                SceneManager = SDK.GetClass("UnityEngine.SceneManagement.SceneManager");
            if (SceneManager == null)
                return -9;
            if (SceneManager_GetActiveScene_Method == null)
                SceneManager_GetActiveScene_Method = SceneManager.GetMethod("GetActiveScene");
            if (SceneManager_GetActiveScene_Method == null)
                return -9;
            IL2CPP_Object scene = SceneManager_GetActiveScene_Method.Invoke();
            if (scene == null)
                return -9;
            return GetSceneIndex(scene.Ptr);
        }

        private static IL2CPP_Class Scene = null;
        private static IL2CPP_Method Scene_get_buildIndex_Method = null;
        unsafe internal static int GetSceneIndex(IntPtr scene)
        {
            if (Scene == null)
                Scene = SDK.GetClass("UnityEngine.SceneManagement.Scene");
            if (Scene == null)
                return -9;
            if (Scene_get_buildIndex_Method == null)
                Scene_get_buildIndex_Method = Scene.GetMethod("get_buildIndex");
            if (Scene_get_buildIndex_Method == null)
                return -9;
            return *(int*)Scene_get_buildIndex_Method.Invoke(scene).Unbox();
        }

        internal static int LastSceneIndex = -9;
        internal static void CheckForSceneChange()
        {
            int currentscene = GetActiveSceneIndex();
            if (LastSceneIndex != currentscene)
            {
                LastSceneIndex = currentscene;
                OnLevelWasLoaded(currentscene);
            }
        }

        internal static void OnPreStart()
        {
            if (ModControllers.Count() > 0)
                foreach (Controller mod in ModControllers)
                    mod.OnPreStart();
        }

        internal static void OnApplicationStart()
        {
            if (ModControllers.Count() > 0)
                foreach (Controller mod in ModControllers)
                    mod.OnApplicationStart();
        }

        internal static void OnApplicationQuit()
        {
            if (ModControllers.Count() > 0)
                foreach (Controller mod in ModControllers)
                    mod.OnApplicationQuit();
            Harmony.Manager.UnpatchAll();
            Harmony.Manager.UnpatchMain();
        }

        internal static void OnApplicationFocus(bool hasFocus)
        {
            if (ModControllers.Count() > 0)
                foreach (Controller mod in ModControllers)
                    mod.OnApplicationFocus(hasFocus);
        }

        internal static void OnApplicationPause(bool hasPaused)
        {
            if (ModControllers.Count() > 0)
                foreach (Controller mod in ModControllers)
                    mod.OnApplicationPause(hasPaused);
        }

        private static bool freshlyLoaded = false;
        unsafe internal static void OnLevelWasLoaded(int level)
        {
            if (ModControllers.Count() > 0)
                foreach (Controller mod in ModControllers)
                    mod.OnLevelWasLoaded(level);
            freshlyLoaded = true;
        }

        internal static void OnLevelWasInitialized(int level)
        {
            if (ModControllers.Count() > 0)
                foreach (Controller mod in ModControllers)
                    mod.OnLevelWasInitialized(level);
        }

        public static float LastUpdate = 0.0f;
        private static IL2CPP_Method TimeGetTime = null;
        unsafe internal static void OnUpdate()
        {
            if (TimeGetTime == null)
                TimeGetTime = SDK.GetClass("UnityEngine.Time")?.GetMethod("get_time");
            if (TimeGetTime == null)
                LastUpdate = 0.0f;
            else
                LastUpdate = *(float*)TimeGetTime.Invoke().Unbox();

            CheckForUiManager();

            if (freshlyLoaded)
            {
                freshlyLoaded = false;
                OnLevelWasInitialized(GetActiveSceneIndex());
            }

            CheckForSceneChange();

            if (ModControllers.Count() > 0)
                foreach (Controller mod in ModControllers)
                    mod.OnUpdate();
        }
        
        internal static void OnFixedUpdate()
        {
            if (ModControllers.Count() > 0)
                foreach (Controller mod in ModControllers)
                    mod.OnFixedUpdate();
        }

        internal static void OnLateUpdate()
        {
            if (ModControllers.Count() > 0)
                foreach (Controller mod in ModControllers)
                    mod.OnLateUpdate();
        }

        internal static void OnUiManagerInit()
        {
            SettingsMenu.Main.OnUIManagerInit();

            if (ModControllers.Count() > 0)
                foreach (Controller mod in ModControllers)
                    mod.OnUiManagerInit();
        }

        internal static void OnGUI()
        {
            if (ModControllers.Count() > 0)
                foreach (Controller mod in ModControllers)
                    mod.OnGUI();
        }

        public static void OnModSettingsApplied()
        {
            if (ModControllers.Count() > 0)
                foreach (Controller mod in ModControllers)
                    mod.OnModSettingsApplied();
        }
    }

    internal class FakeThisDelegateClass
    {
        public void OnApplicationQuit()
        {
            Main.onApplicationQuit.InvokeOriginal(IL2CPP.ObjectToIntPtr(this));
            Main.OnApplicationQuit();
        }

        public void OnApplicationFocus(bool hasFocus)
        {
            Main.onApplicationFocus.InvokeOriginal(IL2CPP.ObjectToIntPtr(this), IL2CPP.ObjectToIntPtr(hasFocus));
            Main.OnApplicationFocus(hasFocus);
        }

        public void OnApplicationPause(bool hasPaused)
        {
            Main.onApplicationFocus.InvokeOriginal(IL2CPP.ObjectToIntPtr(this), IL2CPP.ObjectToIntPtr(hasPaused));
            Main.OnApplicationPause(hasPaused);
        }

        public void Update()
        {
            Main.onUpdate.InvokeOriginal(IL2CPP.ObjectToIntPtr(this));
            Main.OnUpdate();
        }

        public void LateUpdate()
        {
            Main.onLateUpdate.InvokeOriginal(IL2CPP.ObjectToIntPtr(this));
            Main.OnLateUpdate();
        }
        
        public void FixedUpdate()
        {
            Main.onFixedUpdate.InvokeOriginal(IL2CPP.ObjectToIntPtr(this));
            Main.OnFixedUpdate();
        }

        unsafe public void OnGUI()
        {
            // Calling Original causes Exception
            //Main.onGUI.InvokeOriginal(this);
            Main.OnGUI();
        }
    }
}
