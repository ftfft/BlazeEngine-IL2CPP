using System;
using System.Runtime.InteropServices;

namespace BE4v.SDK.CPP2IL
{
    public class IL2Delegate : IL2Base
    {
        public IL2Delegate(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public unsafe static IL2Delegate CreateDelegate(Delegate function, IL2Class klass = null)
        {
            if (klass == null)
                klass = IL2SystemClass.Action;

            var obj = Import.Object.il2cpp_object_new(klass.ptr);
            var runtimeStaticMethod = Marshal.AllocHGlobal(8);
            *(IntPtr*)runtimeStaticMethod = function.Method.MethodHandle.GetFunctionPointer();
            *((IntPtr*)obj + 2) = function.Method.MethodHandle.GetFunctionPointer();
            *((IntPtr*)obj + 4) = IntPtr.Zero;
            *((IntPtr*)obj + 5) = runtimeStaticMethod;

            if (obj != IntPtr.Zero)
                return new IL2Delegate(obj);

            return null;
        }
    }
}


/*

        public unsafe static IntPtr CreateDelegate<T>(Delegate function, T instance, IL2Class klass = null)
        {
            if (klass == null)
                klass = Instance_Class;

            var obj = Import.Object.il2cpp_object_new(klass.ptr);
            if (instance == null || (typeof(T) == typeof(IntPtr) && (IntPtr)(object)instance == IntPtr.Zero))
            {
                var runtimeStaticMethod = Marshal.AllocHGlobal(8);
                *(IntPtr*)runtimeStaticMethod = function.Method.MethodHandle.GetFunctionPointer();
                *((IntPtr*)obj + 2) = function.Method.MethodHandle.GetFunctionPointer();
                *((IntPtr*)obj + 4) = IntPtr.Zero;
                *((IntPtr*)obj + 5) = runtimeStaticMethod;
                return obj;
            }

            IL2Method ctor = klass.GetMethod(".ctor");
            GCHandle handle1 = GCHandle.Alloc(instance);
            var runtimeMethod = Marshal.AllocHGlobal(80);
            //methodPtr
            *((IntPtr*)runtimeMethod) = function.Method.MethodHandle.GetFunctionPointer();
            byte paramCount = (byte)(function.Method.GetParameters()?.Length ?? 0);
            //Parameter count
            *((byte*)runtimeMethod + 75) = paramCount; // 0 parameter_count

            //Slot (65535)
            *((byte*)runtimeMethod + 74) = 0xFF;
            *((byte*)runtimeMethod + 73) = 0xFF;

            *((IntPtr*)obj + 2) = function.Method.MethodHandle.GetFunctionPointer();
            *((IntPtr*)obj + 4) = obj;
            *((IntPtr*)obj + 5) = runtimeMethod;
            *((IntPtr*)obj + 7) = GCHandle.ToIntPtr(handle1);

            return obj;
        }
*/
