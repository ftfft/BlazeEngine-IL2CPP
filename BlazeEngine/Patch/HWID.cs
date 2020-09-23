/*using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using NET_SDK.Reflection;
using NET_SDK.Harmony;
using BlazeEngine.Utils;

namespace BlazeEngine.Patch
{
    public class HWID
    {
        public static void StartPatch()
        {
            if (Assemblies.VRChatStandalone != null)
            {
                IL2CPP_Class patchClass = Assemblies.VRChatStandalone.GetClass("API", "VRC.Core");
                if (patchClass != null)
                {
                    IL2CPP_Method patchMethod = patchClass.GetMethod("get_DeviceID", x => x.GetParameterCount() == 0);
                    if (patchMethod != null)
                    {
                        Instance harmonyInstance = Manager.CreateInstance("HWID");
                        harmonyInstance.Patch(patchMethod, typeof(HWID).GetMethod("DeviceIdPrefix", BindingFlags.NonPublic | BindingFlags.Static));
                        if(FakeDeviceId != "")
                            ConsoleUtils.ConsoleMessage(ConsoleColor.Yellow, "INFO: ", "[+] Patching: Fake HWID");
                    }
                    else
                        ConsoleUtils.ConsoleMessage(ConsoleColor.Red, "ERROR: ", "[-] Bad patch: Fake HWID [#3]");
                }
                else
                    ConsoleUtils.ConsoleMessage(ConsoleColor.Red, "ERROR: ", "[-] Bad patch: Fake HWID [#2]");
            }
            else
                ConsoleUtils.ConsoleMessage(ConsoleColor.Red, "ERROR: ", "[-] Bad patch: Fake HWID [#1]");
        }

        private static string _fakeDeviceId;
        private static string FakeDeviceId
        {
            get
            {
                if (string.IsNullOrEmpty(_fakeDeviceId))
                {
                    _fakeDeviceId = CalculateHash<SHA1>(Guid.NewGuid().ToString());
                    ConsoleUtils.ConsoleMessage(ConsoleColor.Yellow, "INFO: ", "HWID Generated (" + _fakeDeviceId + ")");
                }
                return _fakeDeviceId;
            }
        }

        private static IntPtr DeviceIdPrefix()
        {
            return NET_SDK.IL2CPP.StringToIntPtr(FakeDeviceId);
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
*/