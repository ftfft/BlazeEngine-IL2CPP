using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace System
{
    public class IL2Delegate : IL2Base
    {
        public IL2Delegate(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public unsafe static IL2Delegate CreateDelegate(Delegate function, IL2Class klass = null)
        {
            if (function == null)
                return null;

            if (klass == null)
                klass = IL2Action.Instance_Class;

            cache.Add(function);

            var obj = Import.Object.il2cpp_object_new(klass.ptr);
            var runtimeMethod = Marshal.AllocHGlobal(80);
            try
            {
                *((IntPtr*)runtimeMethod) = function.Method.MethodHandle.GetFunctionPointer();

                // customAttributeIndex : int
                // *((byte*)runtimeMethod + 61) = 0xFF;
                // *((byte*)runtimeMethod + 62) = 0xFF;
                // *((byte*)runtimeMethod + 63) = 0xFF;
                // *((byte*)runtimeMethod + 64) = 0xFF;

                // token : uint
                // *((byte*)runtimeMethod + 65) = 0xFF;
                // *((byte*)runtimeMethod + 66) = 0xFF;
                // *((byte*)runtimeMethod + 67) = 0xFF;
                // *((byte*)runtimeMethod + 68) = 0xFF;

                // flags : Il2CppMethodFlags : ushort
                // *((byte*)runtimeMethod + 69) = 0xFF;
                // *((byte*)runtimeMethod + 70) = 0xFF;

                // iflags : Il2CppMethodImplFlags : ushort
                // *((byte*)runtimeMethod + 71) = 0xFF;
                // *((byte*)runtimeMethod + 72) = 0xFF;

                // Slot (65535) : ushort
                *((byte*)runtimeMethod + 73) = 0xFF;
                *((byte*)runtimeMethod + 74) = 0xFF;

                // Parameter count : byte
                *((byte*)runtimeMethod + 75) = (byte)function.Method.GetParameters().Length;

                *((IntPtr*)obj + 2) = function.Method.MethodHandle.GetFunctionPointer();
                *((IntPtr*)obj + 4) = obj;
                *((IntPtr*)obj + 5) = runtimeMethod;
                *((IntPtr*)obj + 7) = IntPtr.Zero;

                if (obj != IntPtr.Zero)
                    return new IL2Delegate(obj);

            }
            finally
            {
                Marshal.FreeHGlobal(runtimeMethod);
            }
            return null;
        }

        private static readonly List<object> cache = new List<object>();

        unsafe public IntPtr method_ptr
        {
            get => Instance_Class.GetField(nameof(method_ptr)).GetValue(ptr).GetValuе<IntPtr>();
            set => Instance_Class.GetField(nameof(method_ptr)).SetValue(ptr, new IntPtr(&value));
        }

        unsafe public IntPtr invoke_impl
        {
            get => Instance_Class.GetField(nameof(invoke_impl)).GetValue(ptr).GetValuе<IntPtr>();
            set => Instance_Class.GetField(nameof(invoke_impl)).SetValue(ptr, new IntPtr(&value));
        }

        public IL2Object m_target
        {
            get => Instance_Class.GetField(nameof(m_target)).GetValue(ptr);
            set => Instance_Class.GetField(nameof(m_target)).SetValue(ptr, value == null ? IntPtr.Zero : value.ptr);
        }

        unsafe public IntPtr method
        {
            get => Instance_Class.GetField(nameof(method)).GetValue(ptr).GetValuе<IntPtr>();
            set => Instance_Class.GetField(nameof(method)).SetValue(ptr, new IntPtr(&value));
        }

        unsafe public IntPtr delegate_trampoline
        {
            get => Instance_Class.GetField(nameof(delegate_trampoline)).GetValue(ptr).GetValuе<IntPtr>();
            set => Instance_Class.GetField(nameof(delegate_trampoline)).SetValue(ptr, new IntPtr(&value));
        }

        unsafe public IntPtr extra_arg
        {
            get => Instance_Class.GetField(nameof(extra_arg)).GetValue(ptr).GetValuе<IntPtr>();
            set => Instance_Class.GetField(nameof(extra_arg)).SetValue(ptr, new IntPtr(&value));
        }

        unsafe public IntPtr method_code
        {
            get => Instance_Class.GetField(nameof(method_code)).GetValue(ptr).GetValuе<IntPtr>();
            set => Instance_Class.GetField(nameof(method_code)).SetValue(ptr, new IntPtr(&value));
        }


        /*
        unsafe public Il2CppMethodInfo* method_info
        {
            get => (Il2CppMethodInfo*)Instance_Class.GetField(nameof(method_code)).GetValue(ptr).ptr;
            set => Instance_Class.GetField(nameof(method_code)).SetValue(ptr, new IntPtr(&value));
        }

        unsafe public Il2CppMethodInfo* original_method_info
        {
            get => (Il2CppMethodInfo*)Instance_Class.GetField(nameof(method_code)).GetValue(ptr).ptr;
            set => Instance_Class.GetField(nameof(method_code)).SetValue(ptr, new IntPtr(&value));
        }
        */

        // unsafe public DelegateData data;

        unsafe public bool method_is_virtual
        {
            get => Instance_Class.GetField(nameof(method_code)).GetValue(ptr).GetValuе<bool>();
            set => Instance_Class.GetField(nameof(method_code)).SetValue(ptr, new IntPtr(&value));
        }

        private bool isStatic = false;
        private IntPtr handleStatic = IntPtr.Zero;
        public bool Static
        {
            get => isStatic;
            set
            {
                isStatic = value;
                if (value)
                {
                    if (handleStatic == IntPtr.Zero)
                    {
                        handleStatic = Import.Handler.il2cpp_gchandle_new(ptr, true);
                    }
                }
                else
                {
                    if (handleStatic != IntPtr.Zero)
                    {
                        Import.Handler.il2cpp_gchandle_free(handleStatic);
                        handleStatic = IntPtr.Zero;
                    }
                }
            }
        }

        public static IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("Delegate", "System");
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
