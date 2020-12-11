using System;
using System.Linq;
using System.Collections.Generic;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;
using VRC.SDKBase;

namespace VRC.UserCamera
{
    public class UserCameraController : MonoBehaviour
    {
        public UserCameraController(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        // <!---------- ---------- ---------->
        // <!---------- PROPERTY'S ---------->
        // <!---------- ---------- ---------->

        public UserCameraMode mode
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(mode));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses().FirstOrDefault(y => y.IsEnum && y.GetFields().Where(z => z.Name == "Off" || z.Name == "Photo" || z.Name == "Video").Count() == 3).FullName)).Name = nameof(mode);
                IL2Object result = property?.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;
                return result.unbox_Unmanaged<UserCameraMode>();
            }
            set
            {
                IL2Property property = Instance_Class.GetProperty(nameof(mode));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses().FirstOrDefault(y => y.IsEnum && y.GetFields().Where(z => z.Name == "Off" || z.Name == "Photo" || z.Name == "Video").Count() == 3).FullName)).Name = nameof(mode);
                property?.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }


        // <!---------- ------- ---------->
        // <!---------- FIELD'S ---------->
        // <!---------- ------- ---------->
        public static UserCameraController Instance
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(Instance));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.Instance)).Name = nameof(Instance);
                return field?.GetValue()?.unbox<UserCameraController>();
            }
        }

        public UserCameraIndicator userCameraIndicator
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(Instance));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == UserCameraIndicator.Instance_Class.FullName)).Name = nameof(Instance);
                return field?.GetValue()?.unbox<UserCameraIndicator>();
            }
        }
        
        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("UserCameraController", "VRC.UserCamera");
    }
}