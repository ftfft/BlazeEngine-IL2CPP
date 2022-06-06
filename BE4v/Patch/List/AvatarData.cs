using System;
using System.Threading;
using BE4v.MenuEdit;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using BE4v.Patch.Core;
using BE4v.Mods;
using BE4v.Mods.API;
using VRC.Core;

namespace BE4v.Patch.List
{
    public class AvatarData : IPatch
    {
        public delegate void _ShowImage(IntPtr instance, IntPtr apiAvatarPtr);
        public delegate void _LoadAvatar(IntPtr instance, bool forceLoad);

        public void Start()
        {
            IL2Method method = VRCAvatarManager.Instance_Class.GetMethod("ShowImage");
            if (method != null)
            {
                IL2Patch patch = new IL2Patch(method, (_ShowImage)ShowImage);
                __ShowImage = patch.CreateDelegate<_ShowImage>();
            }
            else
                throw new NullReferenceException("AvatarData::ShowImage");

            method = VRCPlayer.Instance_Class.GetMethod("LoadAvatar", x => x.GetParameters()[0].ReturnType.Name == typeof(bool).FullName);
            if (method != null)
            {
                IL2Patch patch = new IL2Patch(method, (_LoadAvatar)LoadAvatar);
                __LoadAvatar = patch.CreateDelegate<_LoadAvatar>();
            }
            else
                throw new NullReferenceException("VRCPlayer::LoadAvatar");
        }

        private static void ShowImage(IntPtr instance, IntPtr apiAvatarPtr)
        {
            if (instance == IntPtr.Zero) return;
            __ShowImage(instance, apiAvatarPtr);
            if (Status.SendAvatarData)
            {
                if (apiAvatarPtr == IntPtr.Zero) return;
                ApiAvatar apiAvatar = new ApiAvatar(apiAvatarPtr);
                string avatarId = apiAvatar.id;
                string avatarName = apiAvatar.name;
                if (!Avatars.AvatarSended.Contains(avatarId) && !Avatars.AvatarSearch.Contains(avatarId))
                {
                    Avatars.AvatarSended.Add(avatarId);
                    new Thread(() => {
                        Avatars.SendAvatarData(avatarId, avatarName);
                    }).Start();
                }
            }
        }
        
        private static void LoadAvatar(IntPtr instance, bool forceLoad)
        {
            if (instance == IntPtr.Zero) return;
            __LoadAvatar(instance, forceLoad);
            if (Status.SendAvatarData)
            {
                VRCPlayer player = new VRCPlayer(instance);
                ApiAvatar apiAvatar = player.AvatarModel;
                if (apiAvatar == null) return;
                string avatarId = apiAvatar.id;
                string avatarName = apiAvatar.name;
                if (!Avatars.AvatarSended.Contains(avatarId) && !Avatars.AvatarSearch.Contains(avatarId))
                {
                    Avatars.AvatarSended.Add(avatarId);
                    new Thread(() => {
                        Avatars.SendAvatarData(avatarId, avatarName);
                    }).Start();
                }
            }
        }

        public static _ShowImage __ShowImage;
        public static _LoadAvatar __LoadAvatar;
    }
}
