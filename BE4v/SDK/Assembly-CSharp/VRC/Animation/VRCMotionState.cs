using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using BE4v.SDK.CPP2IL;

namespace VRC.Animation
{
    public class VRCMotionState : MonoBehaviour
    {
        public VRCMotionState(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        unsafe public Vector3 PlayerVelocity
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(PlayerVelocity));
                if (property == null)
                    (property = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == "UnityEngine.Vector3" && x.GetSetMethod() != null)).Name = nameof(PlayerVelocity);
                return property.GetGetMethod().Invoke(ptr).GetValuе<Vector3>();
            }
            set
            {
                IL2Property property = Instance_Class.GetProperty(nameof(PlayerVelocity));
                if (property == null)
                    (property = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == "UnityEngine.Vector3" && x.GetSetMethod() != null)).Name = nameof(PlayerVelocity);
                property.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
            }
        }

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("OnControllerColliderHit") != null && x.GetMethod("Reset") != null && x.GetMethod("KillPortal") == null);
    }
}
