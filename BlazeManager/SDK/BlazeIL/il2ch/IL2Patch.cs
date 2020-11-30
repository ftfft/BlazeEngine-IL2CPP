using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BlazeIL.il2cpp;

namespace BlazeIL.il2ch
{
    unsafe public class IL2Patch : IL2Base
    {
        internal IL2Method TargetMethod;
        internal IntPtr OriginalMethod;
        internal IL2Patch(IL2Method targetMethod, IntPtr newMethod) : base(newMethod)
        {
            ptr = newMethod;
            TargetMethod = targetMethod;
            IL2Import.VRC_CreateHook(*(IntPtr*)targetMethod.ptr.ToPointer(), newMethod, out OriginalMethod);
        }

        public T CreateDelegate<T>() where T : Delegate
        {
            return (T)Marshal.GetDelegateForFunctionPointer(OriginalMethod, typeof(T));
        }
    }
}
