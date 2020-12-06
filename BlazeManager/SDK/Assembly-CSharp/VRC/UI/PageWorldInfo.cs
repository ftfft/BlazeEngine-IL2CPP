using System;
using System.Collections.Generic;
using UnityEngine;
using BlazeIL.il2cpp;
using VRC.Core;

namespace VRC.UI
{
    public class PageWorldInfo : VRCUiPage
    {
        public PageWorldInfo(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public ApiWorld world
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(world));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == ApiWorld.Instance_Class.FullName)).Name = nameof(world);
                return property?.GetGetMethod().Invoke(ptr)?.unbox<ApiWorld>();
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PageWorldInfo", "VRC.UI");
    }
}
