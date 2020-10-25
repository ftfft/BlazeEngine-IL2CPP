﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BlazeIL.il2cpp;

namespace BlazeIL.il2reflection
{
    public class IL2MethodBody : IL2Base
    {
        internal IL2MethodBody(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public string Name
        {
            get
            {
                if (sName == null)
                    sName = Marshal.PtrToStringAnsi(IL2Import.il2cpp_method_get_name(ptr));

                return sName;
            }
        }
        private string sName = null;

        public int Token => IL2Import.il2cpp_method_get_token(ptr);
        public bool IsStatic => HasFlag(IL2BindingFlags.METHOD_STATIC);

        public IL2ReturnType ReturnType => new IL2ReturnType(IL2Import.il2cpp_method_get_return_type(ptr));
        public IL2Param[] GetParameters()
        {
            if (Parameters == null)
            {
                Parameters = new List<IL2Param>();
                uint param_count = IL2Import.il2cpp_method_get_param_count(ptr);
                for (uint i = 0; i < param_count; i++)
                    Parameters.Add(new IL2Param(IL2Import.il2cpp_method_get_param(ptr, i), Marshal.PtrToStringAnsi(IL2Import.il2cpp_method_get_param_name(ptr, i))));
            }

            return Parameters.ToArray();
        }
        private List<IL2Param> Parameters = null;

        public IL2BindingFlags Flags
        {
            get
            {
                uint f = 0;
                return (IL2BindingFlags)IL2Import.il2cpp_method_get_flags(ptr, ref f);
            }
        }

        public bool HasFlag(IL2BindingFlags flag) => ((Flags & flag) != 0);

        public IL2Object Invoke() => Invoke(IntPtr.Zero, new IntPtr[] { IntPtr.Zero });
        public IL2Object Invoke(IntPtr obj, bool isVirtual = false, bool ex = true) => Invoke(obj, new IntPtr[] { IntPtr.Zero }, isVirtual: isVirtual, ex: ex);
        public IL2Object Invoke(params IntPtr[] paramtbl)
        {
            return Invoke(IntPtr.Zero, paramtbl);
        }
        public IL2Object Invoke(IL2Object obj) => Invoke(obj.ptr, new IntPtr[] { IntPtr.Zero });
        public IL2Object Invoke(params IL2Object[] paramtbl)
        {
            return Invoke(IntPtr.Zero, IL2Import.IL2CPPObjectArrayToIntPtrArray(paramtbl));
        }
        public IL2Object Invoke(IntPtr obj, IL2Object[] paramtbl, bool isVirtual = false, bool ex = true) => Invoke(obj, IL2Import.IL2CPPObjectArrayToIntPtrArray(paramtbl), isVirtual, ex);
        public IL2Object Invoke(IL2Object obj, IntPtr[] paramtbl, bool isVirtual = false, bool ex = true) => Invoke(obj.ptr, paramtbl, isVirtual, ex);
        public IL2Object Invoke(IntPtr obj, IntPtr[] paramtbl, bool isVirtual = false, bool ex = true)
        {
            IntPtr returnval = InvokeMethod(ptr, obj, paramtbl, isVirtual, ex);
            if (returnval == IntPtr.Zero)
                return null;
            return new IL2Object(returnval, ReturnType);
        }

        unsafe public static IntPtr InvokeMethod(IntPtr method, IntPtr obj, IntPtr[] paramtbl, bool isVirtual = false, bool ex = true)
        {
            if (method == IntPtr.Zero)
                return IntPtr.Zero;
            IntPtr[] intPtrArray;
            IntPtr returnval = IntPtr.Zero;
            intPtrArray = ((paramtbl != null) ? paramtbl : new IntPtr[0]);
            IntPtr intPtr = Marshal.AllocHGlobal(intPtrArray.Length * sizeof(void*));
            try
            {
                void** pointerArray = (void**)intPtr.ToPointer();
                for (int i = 0; i < intPtrArray.Length; i++)
                    pointerArray[i] = intPtrArray[i].ToPointer();

                IntPtr @m = isVirtual ? IL2Import.il2cpp_object_get_virtual_method(obj, method) : method;

                IntPtr err = IntPtr.Zero;
                returnval = IL2Import.il2cpp_runtime_invoke(@m, obj, pointerArray, new IntPtr(&err));
                if (err != IntPtr.Zero && ex)
                {
                    Console.WriteLine("Error: " + IL2Import.BuildMessage(err));
                    Console.WriteLine("Src: " + new IL2Method(@m).Name);
                }
            }
            finally
            {
                Marshal.FreeHGlobal(intPtr);
            }
            return returnval;
        }

    }
}
