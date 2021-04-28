using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using VRC.Core;

namespace VRC.UI
{
    public class PageUserInfo : VRCUiPage
    {
        public PageUserInfo(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public APIUser user
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(user));
                if (field == null)
                    (field = Instance_Class.GetField(APIUser.Instance_Class)).Name = nameof(user);
                return field.GetValue(ptr)?.GetValue<APIUser>();
            }
        }

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("RequestInvitation") != null);
    }
}
