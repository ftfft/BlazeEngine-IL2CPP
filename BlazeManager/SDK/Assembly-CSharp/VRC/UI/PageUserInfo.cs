using System;
using System.Linq;
using System.Collections.Generic;
using BlazeIL.il2cpp;
using UnityEngine;
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
                return field.GetValue(ptr)?.unbox<APIUser>();
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses().First(x => x.GetMethod("DeclineFriendRequest") != null);
    }
}