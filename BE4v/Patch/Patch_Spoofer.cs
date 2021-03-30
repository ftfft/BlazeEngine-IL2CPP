using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using Steamworks;

namespace BE4v.Patch
{
    public delegate SteamId _Steamworks_SteamClient_Get_SteamId();
    public delegate IntPtr _UnityEngine_SystemInfo();
    public static class Patch_Spoofer
    {
        public static void Start()
        {
            try
            {
                IL2Method method = Assembler.list["UnityEngine.CoreModule"].GetClass("SystemInfo", "UnityEngine").GetProperty("deviceUniqueIdentifier").GetGetMethod();
                if (method == null)
                    throw new Exception();

                new IL2Patch(method, (_UnityEngine_SystemInfo)UnityEngine_SystemInfo);
                "HWID".GreenPrefix("Good");
            }
            catch
            {
                "HWID".RedPrefix("Bad");
            }
        }


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
