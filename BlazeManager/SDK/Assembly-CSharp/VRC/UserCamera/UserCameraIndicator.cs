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
    public class UserCameraIndicator : MonoBehaviour
    {
        public UserCameraIndicator(IntPtr ptr) : base(ptr) => base.ptr = ptr;


        public static Dictionary<string, IL2Property> properties = new Dictionary<string, IL2Property>();
        public static Dictionary<string, IL2Method> methods = new Dictionary<string, IL2Method>();
        public static Dictionary<string, IL2Field> fields = new Dictionary<string, IL2Field>();

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("UserCameraIndicator", "VRC.UserCamera");
    }
}