using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.ExceptionServices;
using VRCLoader.Attributes;
using VRCLoader.Modules;
using System.Threading;
using BE4v.SDK;

namespace BE4v
{
    [ModuleInfo("BE4V", "4.0", "BlazeBest")]
    public class InjectDLL : VRModule
    {
        [HandleProcessCorruptedStateExceptions]
        public static void Start()
        {
            Main();
        }

        public static void Main()
        {
            SDKLoader.Start();
            Patch.Patch_Spoofer.Start();
            Patch.Patch_AvatarTools.Start();
            Patch.Patch_ForceCloneAvatar.Start();
            Patch.Patch_InvisAPI.Start();
            Patch.Patch_Serilize.Start();
            Patch.Patch_FakePing.Start();
            Mods.Threads.Start();
            SDKLoader.Finish();
        }
    }
}
