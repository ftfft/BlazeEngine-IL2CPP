using System;
using System.Linq;
using BlazeIL.il2cpp;
using VRC.Core;

namespace VRC.Management
{
    public class ModerationManager : IL2Base
    {
        public ModerationManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static ModerationManager Instance
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(Instance));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
                return property?.GetGetMethod().Invoke()?.unbox<ModerationManager>();
            }
        }

        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass(
            VRCApplication.Instance_Class.GetProperty(x => !x.IsStatic &&
            Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass(x.GetGetMethod().ReturnType.Name).GetMethods(y => y.GetParameters().Length == 1 && y.GetParameters()[0].ReturnType.Name == APIUser.Instance_Class.FullName).Length > 10).GetGetMethod().ReturnType.Name
        );
        //public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClasses().First(x => x.GetFields().Where(y => y.ReturnType.Name == "System.Collections.Generic.List<VRC.Core.ApiPlayerModeration>").Count() == 1);
    }
}