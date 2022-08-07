using System;
using System.Runtime.InteropServices;
using IL2CPP_Core.Objects;
using MinHook;

namespace BE4v.SDK
{
    unsafe public class IL2Patch : IL2Object
    {
        internal IL2Method TargetMethod;
        internal IntPtr OriginalMethod;
        internal HookEngine engine;
        internal IL2Patch(IL2Method targetMethod, Delegate newMethod) : base(IntPtr.Zero)
        {
            engine = new HookEngine();
            Pointer = newMethod.Method.MethodHandle.GetFunctionPointer();
            TargetMethod = targetMethod;

            OriginalMethod = engine.CreateHook(*(IntPtr*)targetMethod.Pointer.ToPointer(), newMethod);
            Enabled = true;
            // Import.Patch.VRC_CreateHook(*(IntPtr*)targetMethod.Pointer.ToPointer(), Pointer, out OriginalMethod);
        }

        /*
        internal IL2Patch(IL2Method targetMethod, IntPtr newMethod) : base(newMethod)
        {
            engine = new HookEngine();
            Pointer = newMethod;
            TargetMethod = targetMethod;

            OriginalMethod = engine.CreateHook(*(IntPtr*)targetMethod.Pointer.ToPointer(), Pointer);
            Enabled = true;

            // Import.Patch.VRC_CreateHook(*(IntPtr*)targetMethod.Pointer.ToPointer(), Pointer, out OriginalMethod);
        }
        */
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
                {
                    engine.EnableHooks();
                }
                else
                {
                    engine.DisableHooks();
                }
                // if (isEnabled = value)
                // Import.Patch.VRC_EnableHook(*(IntPtr*)TargetMethod.Pointer.ToPointer());
                // else
                // Import.Patch.VRC_DisableHook(*(IntPtr*)TargetMethod.Pointer.ToPointer());
            }
        }

        private bool isEnabled = true;
    }
}
