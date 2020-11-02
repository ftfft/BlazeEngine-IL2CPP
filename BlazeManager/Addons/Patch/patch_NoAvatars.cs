using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeTools;
using BlazeWebAPI;

namespace Addons.Patch
{
    public delegate bool _VRCAvatarManager_SwitchAvatar(IntPtr instance, IntPtr ptrApiAvatar, IntPtr ptrCurrentVariations, IntPtr ptrLocalScale, IntPtr ptrEvent);
    public static class patch_NoAvatars
    {
        public static void Start()
        {
            try
            {
                IL2Method method = VRCAvatarManager.Instance_Class.GetMethods(x => x.ReturnType.Name == typeof(bool).FullName && x.GetParameters().Length == 4).First(x => x.GetParameters()[0].ReturnType.Name == VRC.Core.ApiAvatar.Instance_Class.FullName && x.GetParameters()[3].Name.StartsWith("VRCAvatarManager."));
                if (method == null)
                    throw new Exception();

                pVRCAvatarManager_SwitchAvatar = IL2Ch.Patch(method, (_VRCAvatarManager_SwitchAvatar)VRCAvatarManager_SwitchAvatar);
                ConSole.Success("Patch: No Avatars");
            }
            catch
            {
                ConSole.Error("Patch: No Avatars");
            }
        }

        private static bool VRCAvatarManager_SwitchAvatar(IntPtr instance, IntPtr ptrApiAvatar, IntPtr ptrCurrentVariations, IntPtr ptrLocalScale, IntPtr ptrEvent)
        {
            IL2Object result = pVRCAvatarManager_SwitchAvatar.InvokeOriginal(instance, new IntPtr[] {
                ptrApiAvatar,
                ptrCurrentVariations,
                ptrLocalScale,
                ptrEvent
            });
            if (result == null)
                return false;

            return result.pUnbox<bool>();
        }

        public static IL2Patch pVRCAvatarManager_SwitchAvatar;
    }
}
