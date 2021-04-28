using BE4v.SDK.CPP2IL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace BE4v.SDK
{
    unsafe public class IL2Patch : IL2Base
    {
        internal IL2Method TargetMethod;
        internal IntPtr OriginalMethod;
        internal IL2Patch(IL2Method targetMethod, Delegate newMethod) : base(IntPtr.Zero)
        {
            ptr = newMethod.Method.MethodHandle.GetFunctionPointer();
            TargetMethod = targetMethod;
            Import.Patch.VRC_CreateHook(*(IntPtr*)targetMethod.ptr.ToPointer(), ptr, out OriginalMethod);
        }

        internal IL2Patch(IL2Method targetMethod, IntPtr newMethod) : base(newMethod)
        {
            ptr = newMethod;
            TargetMethod = targetMethod;
            Import.Patch.VRC_CreateHook(*(IntPtr*)targetMethod.ptr.ToPointer(), ptr, out OriginalMethod);
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
                    Import.Patch.VRC_EnableHook(*(IntPtr*)TargetMethod.ptr.ToPointer());
                else
                    Import.Patch.VRC_DisableHook(*(IntPtr*)TargetMethod.ptr.ToPointer());
            }
        }

        private bool isEnabled = true;
    }
}
