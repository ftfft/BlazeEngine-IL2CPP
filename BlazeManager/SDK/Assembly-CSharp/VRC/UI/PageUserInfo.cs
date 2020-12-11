using System;
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
            get => Instance_Class.GetField(nameof(user)).GetValue(ptr)?.unbox<APIUser>();
        }

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("PageUserInfo", "VRC.UI");
    }
}