using NET_SDK;
using NET_SDK.Reflection;
using System.Linq;

namespace TestMod
{
    public static class FileInfo
    {
        public const string Name = "TestMod";
        public const string Author = "Herp Derpinstine";
        public const string Company = "NanoNuke @ nanonuke.net";
        public const string Version = "1.0.0";
    }
    [NET_SDK.ModLoader.ModInfo(FileInfo.Name, FileInfo.Version, FileInfo.Author)]

    public class TestMod : NET_SDK.ModLoader.Mod
    {
        void OnPreStart()
        {
            //Logger.Log("[TestMod] OnPreStart");
        }

        void OnApplicationStart()
        {
            //Logger.Log("[TestMod] OnApplicationStart");

            ModPrefs.RegisterCategory("testmod", "TestMod");
            ModPrefs.RegisterPrefBool("testmod", "testbool", false, "TestBool");

            Logger.Log("Getting VRCApplicationSetup");
            IL2CPP_Class VRCApplicationSetup = SDK.GetClass("VRCApplicationSetup");
            Logger.Log("Getting get_Instance");
            IL2CPP_Method VRCApplicationSetup_get_Instance = VRCApplicationSetup.GetProperties().First(x => x.GetGetMethod().GetReturnType().Name.Equals("VRCApplicationSetup")).GetGetMethod();
            Logger.Log("Invoking get_Instance");
            IL2CPP_Object VRCApplicationSetup_Instance = VRCApplicationSetup_get_Instance.Invoke();
            Logger.Log("Getting gameServerVersionOverride");
            IL2CPP_Field VRCApplicationSetup_gameServerVersionOverride = VRCApplicationSetup.GetField("gameServerVersionOverride");
            Logger.Log("Old Value: " + VRCApplicationSetup_gameServerVersionOverride.GetValue(VRCApplicationSetup_Instance.Ptr).UnboxString());
            Logger.Log("Setting Value");
            VRCApplicationSetup_gameServerVersionOverride.SetValue(VRCApplicationSetup_Instance.Ptr, IL2CPP.StringToIntPtr("1337"));
            Logger.Log("New Value: " + VRCApplicationSetup_gameServerVersionOverride.GetValue(VRCApplicationSetup_Instance.Ptr).UnboxString());
        }

        void OnApplicationQuit()
        {
            //Logger.Log("[TestMod] OnApplicationQuit");
        }

        void OnLevelWasLoaded(int level)
        {
            //Logger.Log("[TestMod] OnLevelWasLoaded: " + level.ToString());
        }

        void OnLevelWasInitialized(int level)
        {
            //Logger.Log("[TestMod] OnLevelWasInitialized: " + level.ToString());
        }

        void OnUpdate()
        {
            //Logger.Log("[TestMod] OnUpdate");
        }

        void OnLateUpdate()
        {
            //Logger.Log("[TestMod] OnLateUpdate");
        }

        void OnFixedUpdate()
        {
            //Logger.Log("[TestMod] OnFixedUpdate");
        }

        void OnUiManagerInit()
        {
            //Logger.Log("[TestMod] OnUiManagerInit");
        }

        void OnGUI()
        {
            //Logger.Log("[TestMod] OnGUI");
        }

        void OnModSettingsApplied()
        {
            Logger.Log("[TestMod] OnModSettingsApplied");
        }
    }
}
