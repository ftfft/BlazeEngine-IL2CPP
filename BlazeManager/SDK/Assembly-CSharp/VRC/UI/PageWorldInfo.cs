using System;
using System.Linq;
using UnityEngine;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using VRC.Core;

namespace VRC.UI
{
    public class PageWorldInfo : Component
    {
        public PageWorldInfo(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public ApiWorld apiWorld
        {
            get
            {
                if (f_apiWorld == null)
                {
                    f_apiWorld = Instance_Class.GetFields().First(x => x.ReturnType.Name == ApiWorld.Instance_Class.FullName);
                    if (f_apiWorld == null)
                        return null;
                }
                return f_apiWorld.GetValue(ptr)?.MonoCast<ApiWorld>();
            }
        }
        private static IL2Field f_apiWorld;

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PageWorldInfo", "VRC.UI");
    }
}
