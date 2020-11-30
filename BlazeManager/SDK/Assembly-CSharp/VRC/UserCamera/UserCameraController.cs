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

        public static UserCameraController Instance
        {
            get
            {
                if (!fields.ContainsKey(nameof(Instance)))
                {
                    fields.Add(nameof(Instance), Instance_Class.GetField(x => x.Instance));
                    if (!fields.ContainsKey(nameof(Instance)))
                        return null;
                }

                return fields[nameof(Instance)].GetValue()?.unbox<UserCameraController>();
            }
        }

        public UserCameraIndicator userCameraIndicator
        {
            get
            {
                if (!fields.ContainsKey(nameof(userCameraIndicator)))
                {
                    fields.Add(nameof(userCameraIndicator), Instance_Class.GetField(x => x.ReturnType.Name == UserCameraIndicator.Instance_Class.FullName));
                    if (!fields.ContainsKey(nameof(userCameraIndicator)))
                        return null;
                }

                return fields[nameof(userCameraIndicator)].GetValue(ptr)?.unbox<UserCameraIndicator>();
            }
        }
        
        public CameraMode cameraMode
        {
            get
            {
                if (!properties.ContainsKey(nameof(cameraMode)))
                {
                    properties.Add(nameof(cameraMode), Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name.Length > 30));
                    if (!properties.ContainsKey(nameof(cameraMode)))
                        return CameraMode.Off;
                }

                return properties[nameof(cameraMode)].GetGetMethod().Invoke(ptr).unbox_Unmanaged<CameraMode>();
            }
            set
            {

                if (!properties.ContainsKey(nameof(cameraMode)))
                {
                    properties.Add(nameof(cameraMode), Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name.Length > 30));
                    if (!properties.ContainsKey(nameof(cameraMode)))
                        return;
                }
                properties[nameof(cameraMode)].GetGetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }

        public static Dictionary<string, IL2Property> properties = new Dictionary<string, IL2Property>();
        public static Dictionary<string, IL2Method> methods = new Dictionary<string, IL2Method>();
        public static Dictionary<string, IL2Field> fields = new Dictionary<string, IL2Field>();

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("UserCameraController", "VRC.UserCamera");
    }
}