using System;
using System.Linq;
using BE4v.SDK.CPP2IL;
using UnityEngine;

namespace Discord
{
    public class Discord : IL2Base
    {
        public Discord(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod(".ctor", y => y.GetParameters().Length == 2 && y.GetParameters()[0].Name == "clientId") != null);
    }
}