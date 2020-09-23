using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
    public sealed class Animator : MonoBehaviour
    {
        public Animator(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public Transform GetBoneTransform(int humanBoneId) => GetBoneTransform((HumanBodyBones)humanBoneId);
        private static IL2Method methodGetBoneTransformInternal = null;
        public Transform GetBoneTransform(HumanBodyBones humanBoneId)
        {
            if (methodGetBoneTransformInternal == null)
            {
                methodGetBoneTransformInternal = Instance_Class.GetMethod("GetBoneTransformInternal");
                if (methodGetBoneTransformInternal == null)
                    return null;
            }
            return methodGetBoneTransformInternal.Invoke(ptr, new IntPtr[] { ((int)humanBoneId).MonoCast() })?.MonoCast<Transform>();
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.AnimationModule"].GetClass("Animator", "UnityEngine");
    }
}
