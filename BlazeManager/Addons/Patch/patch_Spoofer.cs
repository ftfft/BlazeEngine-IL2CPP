using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeTools;
using Steamworks;

namespace Addons.Patch
{
    public delegate SteamId _Steamworks_SteamClient_Get_SteamId();
    public delegate IntPtr _UnityEngine_SystemInfo();
    public static class patch_Spoofer
    {
        public static void Start()
        {
            try
            {
                IL2Method method = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.unityenginecoremodule]].GetClass("SystemInfo", "UnityEngine").GetProperty("deviceUniqueIdentifier").GetGetMethod();
                if (method == null)
                    throw new Exception();

                IL2Ch.Patch(method, (_UnityEngine_SystemInfo)UnityEngine_SystemInfo);
                Dll_Loader.success_Patch.Add("Spoofer [HWID]");
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("Spoofer [HWID]");
            }
            try
            {
                IL2Method method = SteamClient.Instance_Class.GetProperty("SteamId").GetGetMethod();
                if (method == null)
                    throw new Exception();

                IL2Patch patch = IL2Ch.Patch(method, (_Steamworks_SteamClient_Get_SteamId)Steamworks_SteamClient_Get_SteamId);
                _delegateSteamworks_SteamClient_Get_SteamId = patch.CreateDelegate<_Steamworks_SteamClient_Get_SteamId>();
                Dll_Loader.success_Patch.Add("Spoofer [SteamId]");
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("Spoofer [SteamId]");
            }
        }

        public static SteamId fakeSteamId = 0U;
        public static SteamId? realSteamId = null;
        public static SteamId Steamworks_SteamClient_Get_SteamId()
        {
            if (BlazeManager.GetForPlayer<bool>("Steam Spoof"))
                return fakeSteamId;

            if (realSteamId is null)
            {
                realSteamId = _delegateSteamworks_SteamClient_Get_SteamId.Invoke();
            }
            return realSteamId.Value;
        }
        public static _Steamworks_SteamClient_Get_SteamId _delegateSteamworks_SteamClient_Get_SteamId;


        public static IL2String _fakeDeviceId = null;
        private static IntPtr UnityEngine_SystemInfo()
        {
            if (_fakeDeviceId == null)
            {
                string src = Path.Combine(Environment.CurrentDirectory, "BlazeEngine");
                src += "\\spoof-id.json";
                if (File.Exists(src))
                {
                    _fakeDeviceId = new IL2String(File.ReadAllText(src));
                }
                if (string.IsNullOrWhiteSpace(_fakeDeviceId?.ToString()))
                {
                    _fakeDeviceId = new IL2String(CalculateHash<SHA1>(Guid.NewGuid().ToString()));
                    File.WriteAllText(src, _fakeDeviceId.ToString(), Encoding.UTF8);
                }
                _fakeDeviceId.Static = true;
            }
            return _fakeDeviceId.ptr;
        }


        public static string CalculateHash<T>(string input) where T : HashAlgorithm
        {
            byte[] array = CalculateHash<T>(Encoding.UTF8.GetBytes(input));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }

        public static byte[] CalculateHash<T>(byte[] buffer) where T : HashAlgorithm
        {
            byte[] result;
            using (T t = typeof(T).GetMethod("Create", new Type[0]).Invoke(null, null) as T)
            {
                result = t.ComputeHash(buffer);
            }
            return result;
        }

    }
}
