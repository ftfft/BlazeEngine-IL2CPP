using System;
using System.Collections.Generic;
using BE4v.SDK.CPP2IL;
using VRC.Core.BestHTTP;

namespace VRC.Core
{
    public static class API
    {


        public class CredentialsBundle : IL2Base
        {
            public CredentialsBundle(IntPtr ptr) : base(ptr) => base.ptr = ptr;

            public string username
            {
                get => Instance_Class.GetField(nameof(username)).GetValue(ptr)?.GetValue<string>();
                set => Instance_Class.GetField(nameof(username)).SetValue(ptr, new IL2String(value).ptr);
            }

            public string password
            {
                get => Instance_Class.GetField(nameof(password)).GetValue(ptr)?.GetValue<string>();
                set => Instance_Class.GetField(nameof(password)).SetValue(ptr, new IL2String(value).ptr);
            }

            public static IL2Class Instance_Class = API.Instance_Class.GetNestedType("CredentialsBundle");
        }

        public static IL2Class Instance_Class = Assembler.list["VRCCore-Standalone"].GetClass("API", "VRC.Core");
    }
}
