using System;
using UnityEngine;
using VRC;
using VRC.UI;
using VRC.Core;

namespace Addons.Utils
{
    public static class Avatar
    {
        public static void SelectAvatar(string AvatarId)
        {
            new PageAvatar
            {
                avatar = new SimpleAvatarPedestal
                {
                    apiAvatar = new ApiAvatar
                    {
                        id = AvatarId
                    }
                }
            }.ChangeToSelectedAvatar();
        }
    }
}
