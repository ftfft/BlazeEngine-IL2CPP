using System;
using IL2CPP_Core.Objects;
using BE4v.Mods;
using BE4v.SDK;
using VRC.Core;

namespace BE4v.Patch
{
    public delegate bool _VRC_Management_ModerationManager_HasPlayerModeration(IntPtr instance, IntPtr userId, ApiPlayerModeration.ModerationType moderationType);
    public static class Patch_AntiBlock
    {
        public static void Toggle()
        {
            Status.isAntiBlock = !Status.isAntiBlock;
        }

        public static void Start()
        {
            /*
            try
            {
                IL2Method method = ModerationManager.Instance_Class.GetMethod(x => x.IsPrivate && x.ReturnType.Name == typeof(bool).FullName && x.GetParameters().Length == 2);
                if (method == null)
                    throw new Exception();
                patch = new IL2Patch(method, (_VRC_Management_ModerationManager_HasPlayerModeration)VRC_Management_ModerationManager_HasPlayerModeration);
                _delegateVRC_Management_ModerationManager_HasPlayerModeration = patch.CreateDelegate<_VRC_Management_ModerationManager_HasPlayerModeration>();
                // "Anti-Block".GreenPrefix(TMessage.SuccessPatch);
            }
            catch (Exception ex)
            {
                "Anti-Block".RedPrefix(TMessage.BadPatch);
                ex.ToString().RedPrefix("EX:");
            }
            */
        }

        public static bool VRC_Management_ModerationManager_HasPlayerModeration(IntPtr instance, IntPtr userId, ApiPlayerModeration.ModerationType moderationType)
        {
            // if (moderationType == ApiPlayerModeration.ModerationType.Block)
            //    return true;

            return _delegateVRC_Management_ModerationManager_HasPlayerModeration(instance, userId, moderationType);
        }

        public static IL2Patch patch;

        public static _VRC_Management_ModerationManager_HasPlayerModeration _delegateVRC_Management_ModerationManager_HasPlayerModeration;
    }
}
