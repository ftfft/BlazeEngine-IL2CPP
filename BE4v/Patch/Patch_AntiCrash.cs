using System;
using System.Linq;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using SharpDisasm.Udis86;
using VRC.Core;

namespace BE4v.Patch
{
    public delegate bool _VRCAvatarManager_SwitchAvatar(IntPtr instance, IntPtr ptrApiAvatar, IntPtr ptrCurrentVariations, float fLocalScale, IntPtr ptrEvent);
    public static class Patch_AntiCrash
    {
        public static void Start()
        {
            try
            {

                int methodCount = 0;
                IL2Method method = null;
                foreach (var m in VRCAvatarManager.Instance_Class.GetMethods(x => x.ReturnType.Name == typeof(bool).FullName && x.GetParameters().Length == 4 && x.GetParameters()[0].ReturnType.Name == ApiAvatar.Instance_Class.FullName))
                {
                    var instructions = m.GetDisassembler().Disassemble().TakeWhile(x => x.Mnemonic != ud_mnemonic_code.UD_Iint3);
                    if (instructions.Count() > methodCount)
                    {
                        methodCount = instructions.Count();
                        method = m;
                    }
                }
                if (method == null)
                    throw new Exception();

                method.Name = "SwitchAvatar";

                var patch = new IL2Patch(method, (_VRCAvatarManager_SwitchAvatar)VRCAvatarManager_SwitchAvatar);
                _VRCAvatarManager_SwitchAvatar = patch.CreateDelegate<_VRCAvatarManager_SwitchAvatar>();
                "AntiCrash".GreenPrefix(TMessage.SuccessPatch);
            }
            catch (Exception ex)
            {
                "AntiCrash".RedPrefix(TMessage.BadPatch);
                Console.WriteLine(ex.ToString());
            }
        }

        private static bool VRCAvatarManager_SwitchAvatar(IntPtr instance, IntPtr ptrApiAvatar, IntPtr ptrCurrentVariations, float fLocalScale, IntPtr ptrEvent)
        {
            // Logger
            /*
            Console.WriteLine("/ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ /");
            Console.WriteLine("AvatarID: " + avatar?.id);
            Console.WriteLine("AvatarName: " + avatar?.name);
            Console.WriteLine("/ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ /");
            if (UserUtils.blockedAvatars?.Contains(avatar?.id) == true)
            {
                return false;
            }
            */
            bool result = false;
            try
            {
                result = _VRCAvatarManager_SwitchAvatar(instance,
                    ptrApiAvatar,
                    ptrCurrentVariations,
                    fLocalScale,
                    ptrEvent
                );
            }
            catch
            {
                if (ptrApiAvatar != IntPtr.Zero)
                {
                    ApiAvatar avatar = new ApiAvatar(ptrApiAvatar);
                    Console.WriteLine("/ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ / BAD LOAD");
                    Console.WriteLine("AvatarID: " + avatar?.id);
                    Console.WriteLine("AvatarName: " + avatar?.name);
                    Console.WriteLine("/ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ /");
                }
            }
            return result;
        }

        public static _VRCAvatarManager_SwitchAvatar _VRCAvatarManager_SwitchAvatar;
    }
}
