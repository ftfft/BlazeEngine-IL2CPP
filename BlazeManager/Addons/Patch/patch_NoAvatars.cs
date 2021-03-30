using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeIL.cpp2il;
using BlazeIL.cpp2il.IL;
using BlazeTools;
using BlazeWebAPI;
using SharpDisasm;
using SharpDisasm.Udis86;
using VRC.Core;

namespace Addons.Patch
{
    public delegate bool _VRCAvatarManager_SwitchAvatar(IntPtr instance, IntPtr ptrApiAvatar, IntPtr ptrCurrentVariations, float fLocalScale, IntPtr ptrEvent);
    public static class patch_NoAvatars
    {
        public static void Start()
        {
            try
            {
                int methodCount = 0;
                IL2Method method = null;
                foreach(var m in VRCAvatarManager.Instance_Class.GetMethods(x => x.ReturnType.Name == typeof(bool).FullName && x.GetParameters().Length == 4 && x.GetParameters()[0].ReturnType.Name == ApiAvatar.Instance_Class.FullName))
                {
                    var disassembler = disasm.GetDisassembler(m);
                    var instructions = disassembler.Disassemble().TakeWhile(x => x.Mnemonic != ud_mnemonic_code.UD_Iint3);
                    if (instructions.Count() > methodCount)
                    {
                        methodCount = instructions.Count();
                        method = m;
                    }
                }
                if (method == null)
                    throw new Exception();

                method.Name = "SwitchAvatar";

                var patch = IL2Ch.Patch(method, (_VRCAvatarManager_SwitchAvatar)VRCAvatarManager_SwitchAvatar);
                _VRCAvatarManager_SwitchAvatar = patch.CreateDelegate<_VRCAvatarManager_SwitchAvatar>();
                Dll_Loader.success_Patch.Add("No Avatars");
            }
            catch
            {
                Dll_Loader.failed_Patch.Add("No Avatars");
            }
        }

        private static bool VRCAvatarManager_SwitchAvatar(IntPtr instance, IntPtr ptrApiAvatar, IntPtr ptrCurrentVariations, float fLocalScale, IntPtr ptrEvent)
        {
            if (ptrApiAvatar != IntPtr.Zero)
            {
                ApiAvatar avatar = new ApiAvatar(ptrApiAvatar);
                // Logger
                Console.WriteLine("/ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ /");
                Console.WriteLine("AvatarID: " + avatar?.id);
                Console.WriteLine("AvatarName: " + avatar?.name);
                Console.WriteLine("/ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ /");
                if (UserUtils.blockedAvatars?.Contains(avatar?.id) == true)
                {
                    return false;
                }
            }
            return _VRCAvatarManager_SwitchAvatar(instance,
                ptrApiAvatar,
                ptrCurrentVariations,
                fLocalScale,
                ptrEvent
            );
        }

        public static _VRCAvatarManager_SwitchAvatar _VRCAvatarManager_SwitchAvatar;
    }
}
