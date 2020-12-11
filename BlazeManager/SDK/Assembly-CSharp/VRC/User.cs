using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;
using VRC.Core;
using VRC.SDKBase;
using SharpDisasm;
using SharpDisasm.Udis86;
using BlazeIL.cpp2il;
using BlazeIL.cpp2il.IL;

namespace VRC
{
    public class User : APIUser
    {
        public User(IntPtr ptr) : base(ptr) => base.ptr = ptr;


        private static IL2Property propertyCurrentUser = null;
        public new static User CurrentUser
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(CurrentUser));
                if (propertyCurrentUser == null)
                    (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(CurrentUser);
                
                return property?.GetGetMethod().Invoke()?.unbox<User>();
            }
        }

        public static IL2String CreateSessionIdForUser(string id)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(CreateSessionIdForUser));
            if (method == null)
                (method = Instance_Class.GetMethod(x => x.IsStatic && x.ReturnType.Name == typeof(string).FullName)).Name = nameof(CreateSessionIdForUser);

            return method.Invoke(new IntPtr[] { new IL2String(id).ptr })?.unbox_ToString();
        }

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses().FirstOrDefault(x => x.BaseType?.FullName == APIUser.Instance_Class.FullName);
    }
}
