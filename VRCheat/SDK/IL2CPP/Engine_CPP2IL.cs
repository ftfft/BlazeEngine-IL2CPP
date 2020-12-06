using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;

namespace VRCheat.SDK.IL2CPP
{
    public static class Engine_CPP2IL
    {
        public static void Start()
        {

            var domain = IL2Import.il2cpp_domain_get();

            uint count = 0;
            IntPtr assemblies = IL2Import.il2cpp_domain_get_assemblies(domain, ref count);
            IntPtr[] assembliesarr = IntPtrToStructureArray<IntPtr>(assemblies, count);
            /*foreach (IntPtr assembly in assembliesarr)
                if (assembly != IntPtr.Zero)
                    listAssemblies.Add(new IL2Assembly(IL2Import.il2cpp_assembly_get_image(assembly)));
            */
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

        unsafe public class IL2Import
        {
            // ---------------------- [ IL2CPP Domain ] ---------------------- //
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_domain_get();
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_domain_get_assemblies(IntPtr domain, ref uint count);

            // ---------------------- [ IL2CPP Assembly ] ---------------------- //
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_assembly_get_image(IntPtr assembly);

            // ---------------------- [ IL2CPP Image ] ---------------------- //
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_image_get_name(IntPtr image);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static uint il2cpp_image_get_class_count(IntPtr image);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_image_get_class(IntPtr image, uint index);

            // ---------------------- [ IL2CPP Class ] ---------------------- //
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_class_get_name(IntPtr klass);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_class_get_namespace(IntPtr method);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static uint il2cpp_class_get_flags(IntPtr klass, ref uint flags);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_class_get_methods(IntPtr klass, ref IntPtr iter);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_class_get_fields(IntPtr klass, ref IntPtr iter);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_class_get_nested_types(IntPtr klass, ref IntPtr iter);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_class_get_properties(IntPtr klass, ref IntPtr iter);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_class_get_interfaces(IntPtr klass, ref IntPtr iter);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_class_get_type(IntPtr klass);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_type_get_object(IntPtr type);

            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_class_from_system_type(IntPtr type);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_class_get_image(IntPtr klass);

            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_class_get_declaring_type(IntPtr klass);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static bool il2cpp_class_has_attribute(IntPtr klass, IntPtr attr_class);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static bool il2cpp_class_is_enum(IntPtr klass);


            // ---------------------- [ IL2CPP Method ] ---------------------- //
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_method_get_name(IntPtr method);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_method_get_return_type(IntPtr method);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static uint il2cpp_method_get_flags(IntPtr method, ref uint flags);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static uint il2cpp_method_get_param_count(IntPtr method);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_method_get_param(IntPtr method, uint index);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_method_get_param_name(IntPtr method, uint index);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static int il2cpp_method_get_token(IntPtr method);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static int il2cpp_class_get_type_token(IntPtr method);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static bool il2cpp_method_has_attribute(IntPtr method, IntPtr attr_class);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_method_get_class(IntPtr method);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_runtime_invoke(IntPtr method, IntPtr obj, void** param, IntPtr exc);

            // ---------------------- [ IL2CPP Field ] ---------------------- //
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_field_get_name(IntPtr field);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static uint il2cpp_field_get_flags(IntPtr field, ref uint flags);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_field_get_type(IntPtr field);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_field_get_parent(IntPtr field);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_field_get_value_object(IntPtr field, IntPtr obj);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static void il2cpp_field_static_set_value(IntPtr field, IntPtr value);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static void il2cpp_field_set_value(IntPtr obj, IntPtr field, IntPtr value);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static int il2cpp_field_get_offset(IntPtr field);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static bool il2cpp_field_has_attribute(IntPtr field, IntPtr attr_class);

            // ---------------------- [ IL2CPP Property ] ---------------------- //
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_property_get_name(IntPtr property);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static uint il2cpp_property_get_flags(IntPtr property);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_property_get_get_method(IntPtr property);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_property_get_set_method(IntPtr property);

            // ---------------------- [ Handlers ] ---------------------- //
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_gchandle_new(IntPtr obj, bool pinned);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static void il2cpp_gchandle_free(IntPtr handle);

            // ---------------------- [ Other's ] ---------------------- //
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static string il2cpp_type_get_name(IntPtr type);

            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_object_unbox(IntPtr obj);

            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_object_get_virtual_method(IntPtr obj, IntPtr method);

            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_method_get_object(IntPtr method);

            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_object_get_class(IntPtr str);

            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_string_new(string str);


            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static void il2cpp_format_exception(IntPtr exception, void* message, int ourMessageBytes);



            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_string_new_len(string str, int length);

            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_object_new(IntPtr klass);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_array_new(IntPtr elementTypeInfo, int length);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static IntPtr il2cpp_array_class_get(IntPtr element_class, uint rank);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static int il2cpp_array_length(IntPtr pArray);
            [DllImport("GameAssembly", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static int il2cpp_array_get_byte_length(IntPtr pArray);

            [DllImport("winmm", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
            public extern static void VRC_CreateHook(IntPtr pTarget, IntPtr pDetour, out IntPtr ppOrig);
            public static IntPtr StringToIntPtr(string str) => il2cpp_string_new(str);
            public static IntPtr StringToIntPtrRU(string str)
            {
                IntPtr result = il2cpp_string_new_len(string.Empty, str.Length);
                for (int i = 0; i < str.Length; i++)
                {
                    *(char*)(result + 0x14 + (0x2 * i)) = str[i];
                }
                return result;
            }
        }
    }
}
