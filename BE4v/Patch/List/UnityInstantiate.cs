using System;
using System.Runtime.ExceptionServices;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using BE4v.Patch.Core;
using UnityEngine;

namespace BE4v.Patch.List
{
    public class UnityInstantiate : IPatch
    {
        public delegate IntPtr _Instantiate(IntPtr originalPtr, Vector3 position, Quaternion rotation);

        public void Start()
        {
            IL2Method method = UnityEngine.Object.Instance_Class.GetMethod("Instantiate", x => x.ReturnType.Name == UnityEngine.Object.Instance_Class.FullName && x.GetParameters().Length == 3 && x.GetParameters()[2].Name == "rotation");
            if (method != null)
            {
                patch = new IL2Patch(method, (_Instantiate)Instantiate);
                __Instantiate = patch.CreateDelegate<_Instantiate>();
            }
            else
                throw new NullReferenceException();
        }


        [HandleProcessCorruptedStateExceptions]
        public static IntPtr Instantiate(IntPtr originalPtr, Vector3 position, Quaternion rotation)
        {
            IntPtr result = IntPtr.Zero;
            try
            {
                if (originalPtr != IntPtr.Zero && IsValid(position) && IsValid(rotation))
                    result = __Instantiate(originalPtr, position, rotation);
                else
                    result = new GameObject("Safe VR Object").ptr;
            }
            catch
            {
                result = new GameObject("Safe VR Object").ptr;
            }
            return result;
        }

        private static bool IsValid(Quaternion arg)
        {
            if (IsValid(arg.x) && IsValid(arg.y) && IsValid(arg.z) && IsValid(arg.w))
                return true;

            return false;
        }

        private static bool IsValid(Vector3 arg)
        {
            if (IsValid(arg.x) && IsValid(arg.y) && IsValid(arg.z))
                return true;

            return false;
        }

        private static bool IsValid(float arg)
        {
            if (arg != float.NegativeInfinity && arg != float.NaN && arg != float.PositiveInfinity)
                return true;

            return false;
        }

        public static IL2Patch patch;

        public static _Instantiate __Instantiate;
    }
}
