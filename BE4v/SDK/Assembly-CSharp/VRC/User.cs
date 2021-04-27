using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using VRC.SDKBase;
using VRC.Core;

namespace VRC
{
    public class User : APIUser
    {
        public User(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.BaseType?.FullName == APIUser.Instance_Class.FullName);
    }
}
