using System;
using System.Reflection;
using BlazeIL.il2cpp;

namespace BlazeIL.il2ch
{
    public class IL2Ch
    {
        public static IL2Patch Patch(IL2Method method, Delegate patch_Delegate) => Patch(method, patch_Delegate.Method);
        public static IL2Patch Patch(IL2Method method, MethodInfo patch_Info) => Patch(method, patch_Info.MethodHandle.GetFunctionPointer());
        public static IL2Patch Patch(IL2Method method, IntPtr patch_Pointer) => new IL2Patch(method, patch_Pointer);
    }
}
