using System;
using System.Linq;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
    public sealed class Animator : MonoBehaviour
    {
        public Animator(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public Transform GetBoneTransform(int humanBoneId) => GetBoneTransform((HumanBodyBones)humanBoneId);
        unsafe public Transform GetBoneTransform(HumanBodyBones humanBoneId)
        {
            return Instance_Class.GetMethod("GetBoneTransformInternal").Invoke(ptr, new IntPtr[] { new IntPtr(&humanBoneId) })?.MonoCast<Transform>();
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.AnimationModule"].GetClass("Animator", "UnityEngine");
    }
}
