using System;
using System.Runtime.InteropServices;
using IL2CPP_Core.Objects;

namespace BE4v.SDK
{
    unsafe public class IL2Patch : IL2Object
    {
        internal IL2Method TargetMethod;
        internal IntPtr OriginalMethod;
        internal IL2Patch(IL2Method targetMethod, Delegate newMethod) : base(IntPtr.Zero)
        {
            Pointer = newMethod.Method.MethodHandle.GetFunctionPointer();
            TargetMethod = targetMethod;
            Import.Patch.VRC_CreateHook(*(IntPtr*)targetMethod.Pointer.ToPointer(), Pointer, out OriginalMethod);
        }

        internal IL2Patch(IL2Method targetMethod, IntPtr newMethod) : base(newMethod)
        {
            Pointer = newMethod;
            TargetMethod = targetMethod;
            Import.Patch.VRC_CreateHook(*(IntPtr*)targetMethod.Pointer.ToPointer(), Pointer, out OriginalMethod);
        }

        public T CreateDelegate<T>() where T : Delegate
        {
            return Marshal.GetDelegateForFunctionPointer(OriginalMethod, typeof(T)) as T;
        }

        public bool Enabled
        {
            get => isEnabled;
            set
            {
                if (isEnabled = value)
                    Import.Patch.VRC_EnableHook(*(IntPtr*)TargetMethod.Pointer.ToPointer());
                else
                    Import.Patch.VRC_DisableHook(*(IntPtr*)TargetMethod.Pointer.ToPointer());
            }
        }

        private bool isEnabled = true;
    }
}
