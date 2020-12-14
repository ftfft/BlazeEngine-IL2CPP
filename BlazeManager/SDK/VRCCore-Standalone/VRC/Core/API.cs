using System;
using System.Collections.Generic;
using BlazeIL.il2cpp;
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
                get => Instance_Class.GetField(nameof(username)).GetValue(ptr)?.unbox_ToString().ToString();
                set => Instance_Class.GetField(nameof(username)).SetValue(ptr, new IL2String(value).ptr);
            }

            public string password
            {
                get => Instance_Class.GetField(nameof(password)).GetValue(ptr)?.unbox_ToString().ToString();
                set => Instance_Class.GetField(nameof(password)).SetValue(ptr, new IL2String(value).ptr);
            }

            public static IL2Type Instance_Class = API.Instance_Class.GetNestedType("CredentialsBundle");
        }

        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.vrccorestandalone]].GetClass("API", "VRC.Core");
    }
}
