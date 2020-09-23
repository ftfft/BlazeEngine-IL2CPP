using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BlazeIL;
using BlazeIL.il2cpp;

unsafe public static class Execute
{
    [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public extern static IntPtr il2cpp_class_get_type(IntPtr klass);
    [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
    public extern static IntPtr il2cpp_type_get_object(IntPtr type);

    public static IntPtr find_typeof_to_type(Type type)
    {
        IntPtr klass = IntPtr.Zero;
        try
        {
            klass = ((IL2Type)type.GetField("Instance_Class").GetValue(null)).ptr;
            return il2cpp_type_get_object(il2cpp_class_get_type(klass));
        }
        catch
        {
            return IntPtr.Zero;
        }
    }

    public static IntPtr IntPtrArrayToIntPtr(this IntPtr[] intPtrArray)
    {
        IntPtr intPtr = Marshal.AllocHGlobal(intPtrArray.Length * sizeof(void*));
        try
        {
            void** pointerArray = (void**)intPtr.ToPointer();
            for (int i = 0; i < intPtrArray.Length; i++)
                pointerArray[i] = intPtrArray[i].ToPointer();
            return (IntPtr)pointerArray;
        }
        finally
        {
            Marshal.FreeHGlobal(intPtr);
        }
    }

    public static bool CheckOrSetField(string property, IL2Type il2type, ref IL2Field il2field)
    {
        if (il2field == null)
            il2field = il2type.GetField(property);

        return il2field != null;
    }
    public static bool CheckOrSetProperty(string property, IL2Type il2type, ref IL2Property il2property)
    {
        if (il2property == null)
            il2property = il2type.GetProperty(property);

        return il2property != null;
    }

    public static T[] IntPtrToArray<T>(IntPtr ptr, uint len)
    {
        IntPtr iter = ptr;
        T[] arr = new T[len];

        for (uint i = 0; i < len; i++)
        {
            arr[i] = (T)Marshal.PtrToStructure(iter, typeof(T));
            iter += Marshal.SizeOf(typeof(T));
        }
        return arr;
    }

    private static IL2Type typeObject = Assemblies.a["mscorlib"].GetClass("Object", "System");
    public static IntPtr ArrayToIntPtr(this IntPtr[] array, IL2Type typeobject = null)
    {
        if (typeobject == null)
            typeobject = typeObject;

        int length = array.Length;
        IntPtr result = IL2Import.il2cpp_array_new(typeobject.ptr, length);
        for (int i = 0; i < length; i++)
        {
            *(IntPtr*)((IntPtr)((long*)result + 4) + i * IntPtr.Size) = array[i];
        }
        return result;
    }

    public static IntPtr[] IntPtrToArray(this IntPtr ptr)
    {
        long length = *((long*)ptr + 3);
        IntPtr[] result = new IntPtr[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = *(IntPtr*)((IntPtr)((long*)ptr + 4) + i * IntPtr.Size);
        }

        return result;
    }
}
