using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

public static class SDKUtils
{
    unsafe public static IntPtr ArrayToIntPtr(this IEnumerable<IntPtr> array, IL2Class typeobject = null)
    {
        return ArrayToIntPtr(array.ToArray(), typeobject);
    }
    
    unsafe public static IntPtr ArrayToIntPtr(this IntPtr[] array, IL2Class typeobject = null)
    {
        if (typeobject == null)
            typeobject = Assembler.list["mscorlib"].GetClass("Object", "System");

        int length = array.Count();
        IntPtr result = Import.Object.il2cpp_array_new(typeobject.ptr, length);
        if (typeobject == IL2SystemClass.Byte)
        {
            for (int i = 0; i < length; i++)
            {
                *(IntPtr*)((IntPtr)((long*)result + 4) + i * sizeof(byte)) = array[i];
            }
        }
        else
        {
            for (int i = 0; i < length; i++)
            {
                *(IntPtr*)((IntPtr)((long*)result + 4) + i * IntPtr.Size) = array[i];
            }
        }
        return result;
    }

    public static T[] IntPtrToStructureArray<T>(IntPtr ptr, uint len)
    {
        IntPtr iter = ptr;
        T[] array = new T[len];
        for (uint i = 0; i < len; i++)
        {
            array[i] = (T)Marshal.PtrToStructure(iter, typeof(T));
            iter += Marshal.SizeOf(typeof(T));
        }
        return array;
    }
    public static IntPtr[] IL2ObjecToIntPtr(IL2Object[] objtbl) => objtbl.Select(x => x.ptr).ToArray();
    public static bool IsUnmanaged(this Type type)
    {
        // primitive, pointer or enum -> true
        if (type.IsPrimitive || type.IsPointer || type.IsEnum)
            return true;

        // not a struct -> false
        if (!type.IsValueType)
            return false;

        // otherwise check recursively
        return type
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .All(f => IsUnmanaged(f.FieldType));
    }

    public unsafe static string BuildMessage(IntPtr exception)
    {
        byte[] ourMessageBytes = new byte[65536];
        fixed (byte* message = &ourMessageBytes[0])
        {
            Import.Exception.il2cpp_format_exception(exception, (void*)message, ourMessageBytes.Length);
            string text = System.Text.Encoding.UTF8.GetString(ourMessageBytes, 0, Array.IndexOf<byte>(ourMessageBytes, 0));
            return text;
        }
    }

    public static void RedPrefix(this string message, string prefix)
    {
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(prefix);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("] " + message);
    }
    
    public static void GreenPrefix(this string message, string prefix)
    {
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(prefix);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("] " + message);
    }

    public static void WriteMessage(this string message, string prefix)
    {
        Console.WriteLine($"[{prefix}] {message}");
    }

    public static void WriteMessage(this string message)
    {
        Console.WriteLine(message);
    }

}