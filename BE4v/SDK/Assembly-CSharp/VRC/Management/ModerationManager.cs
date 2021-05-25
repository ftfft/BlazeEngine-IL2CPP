using System;
using System.Linq;
using BE4v.SDK.CPP2IL;
using VRC.Core;

namespace VRC.Management
{
    public class ModerationManager : IL2Base
    {
        public ModerationManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod(y => y.IsPrivate && y.GetParameters().Length == 2 && y.GetParameters()[1].ReturnType.Name == "VRC.Core.ApiPlayerModeration.ModerationType") != null);
    }
}
