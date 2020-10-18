using System;
using System.Collections.Generic;
using UnityEngine;
using BlazeIL.il2cpp;
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
                if (!fields.ContainsKey(nameof(apiWorld)))
                {
                    fields.Add(nameof(apiWorld), Instance_Class.GetField(x => x.ReturnType.Name == ApiWorld.Instance_Class.FullName));
                    if (!fields.ContainsKey(nameof(apiWorld)))
                        return null;
                }
                return fields[nameof(apiWorld)].GetValue(ptr)?.unbox<ApiWorld>();
            }
        }

        public static Dictionary<string, IL2Property> properties = new Dictionary<string, IL2Property>();
        public static Dictionary<string, IL2Method> methods = new Dictionary<string, IL2Method>();
        public static Dictionary<string, IL2Field> fields = new Dictionary<string, IL2Field>();

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PageWorldInfo", "VRC.UI");
    }
}
