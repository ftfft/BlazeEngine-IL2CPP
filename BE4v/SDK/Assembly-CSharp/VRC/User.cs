using System;
using System.Linq;
using IL2CPP_Core.Objects;
using VRC.Core;

namespace VRC
{
    public class User : APIUser
    {
        public User(IntPtr ptr) : base(ptr) { }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.BaseType == APIUser.Instance_Class);
    }
}
