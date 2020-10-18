using System;
using System.Collections.Generic;
using UnityEngine;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace VRC.UI
{
    public class PageAvatar : Component
    {
        public PageAvatar(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public SimpleAvatarPedestal avatar
        {
            get
            {
                if (!fields.ContainsKey(nameof(avatar)))
                {
                    fields.Add(nameof(avatar), Instance_Class.GetField("avatar"));
                    if (!fields.ContainsKey(nameof(avatar)))
                        return default;
                }

                return fields[nameof(avatar)].GetValue(ptr)?.unbox<SimpleAvatarPedestal>();
            }
            set
            {
                if (!fields.ContainsKey(nameof(avatar)))
                {
                    fields.Add(nameof(avatar), Instance_Class.GetField("avatar"));
                    if (!fields.ContainsKey(nameof(avatar)))
                        return;
                }

                fields[nameof(avatar)].SetValue(ptr, value.ptr);
            }
        }

        public static Dictionary<string, IL2Property> properties = new Dictionary<string, IL2Property>();
        public static Dictionary<string, IL2Method> methods = new Dictionary<string, IL2Method>();
        public static Dictionary<string, IL2Field> fields = new Dictionary<string, IL2Field>();

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PageAvatar", "VRC.UI");
    }
}