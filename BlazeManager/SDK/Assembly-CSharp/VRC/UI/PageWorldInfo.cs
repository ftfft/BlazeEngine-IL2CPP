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
        
        public IL2String worldInfoScreenPath
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(worldInfoScreenPath));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(string).FullName)).Name = nameof(worldInfoScreenPath);
                return field?.GetValue(ptr)?.unbox_ToString();
            }
        }
        
        public ApiWorldInstance worldInstance
        {
            get => Instance_Class.GetField(nameof(worldInstance)).GetValue(ptr)?.unbox<ApiWorldInstance>();
        }

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("PageWorldInfo", "VRC.UI");
    }
}
