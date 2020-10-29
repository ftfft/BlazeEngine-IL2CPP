using System;
using System.Linq;
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
    public class FeaturePermissionManager : MonoBehaviour
    {
        public FeaturePermissionManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static FeaturePermissionManager Instance
        {
            get
            {
                if (!properties.ContainsKey(nameof(Instance)))
                {
                    properties.Add(nameof(Instance), Instance_Class.GetProperty(x => x.Instance));
                    if (!properties.ContainsKey(nameof(Instance)))
                        return null;
                }

                return properties[nameof(Instance)].GetGetMethod().Invoke()?.unbox<FeaturePermissionManager>();
            }
        }

        public static Dictionary<string, IL2Property> properties = new Dictionary<string, IL2Property>();
        public static Dictionary<string, IL2Method> methods = new Dictionary<string, IL2Method>();
        public static Dictionary<string, IL2Field> fields = new Dictionary<string, IL2Field>();

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("FeaturePermissionManager", "VRC");
    }
}
