using System;
using System.Linq;
using IL2CPP_Core.Objects;
using BE4v.MenuEdit;
using BE4v.Mods;
using BE4v.SDK;
using BE4v.Patch.Core;
using SharpDisasm.Udis86;

namespace BE4v.Patch.List
{
    public class BypassEAC : IPatch
    {
        public delegate EAC_Reason _methodBypass(IntPtr ptr);
        public delegate void _methodBypass2(IntPtr instance, IntPtr str);

        public void Start()
        {
            IL2Method method = EAC_StaticClass2.Instance_Class.GetMethod(x => x.Token == 0x6007734);
            if (method != null)
            {
                var patch = new IL2Patch(method, (_methodBypass)methodBypass);
                _method = patch.CreateDelegate<_methodBypass>();
            }
            else
                throw new NullReferenceException();



            IL2Class klass = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.Token == 0x2000253).GetNestedTypes().FirstOrDefault(x => x.Token == 0x2000270);
            method = klass.GetMethod(x => x.Token == 0x60031D3);
            if (method != null)
            {
                new IL2Patch(method, (_methodBypass2)methodBypass2);
            }
            else
                throw new NullReferenceException();
        }

        private static EAC_Reason methodBypass(IntPtr ptr)
        {
            EAC_Reason response = EAC_Reason.AntiCheatDeviceIdAuthIsNotSupported;
            response = _method(ptr);
            response.ToString().RedPrefix("Response");
            response = EAC_Reason.AlreadyConfigured;
            return response;
        }

        private static void methodBypass2(IntPtr instance, IntPtr str)
        {
            "Triggered bypass".RedPrefix("***");
        }
        
        public static _methodBypass _method;
    }
}
