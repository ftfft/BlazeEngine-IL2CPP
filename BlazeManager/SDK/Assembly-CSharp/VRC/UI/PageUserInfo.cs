using System;
using System.Collections.Generic;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;
using VRC.Core;
namespace VRC.UI
{
    public class PageUserInfo : MonoBehaviour
    {
        public PageUserInfo(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public APIUser user
        {
            get
            {
                if (!fields.ContainsKey(nameof(user)))
                {
                    fields.Add(nameof(user), Instance_Class.GetField("user"));
                    if (!fields.ContainsKey(nameof(user)))
                        return null;
                }
                return fields[nameof(user)].GetValue(ptr)?.unbox<APIUser>();
            }
        }

        public static Dictionary<string, IL2Property> properties = new Dictionary<string, IL2Property>();
        public static Dictionary<string, IL2Method> methods = new Dictionary<string, IL2Method>();
        public static Dictionary<string, IL2Field> fields = new Dictionary<string, IL2Field>();

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PageUserInfo", "VRC.UI");
    }
}