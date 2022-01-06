using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using System;
using System.Linq;

namespace UnityEngine
{
    public static class ImageConversion
    {
        public static byte[] EncodeToPNG(this Texture2D tex)
        {
            return Instance_Class.GetMethod(nameof(EncodeToPNG)).Invoke(new IntPtr[] { tex.ptr })?.UnboxArraó<byte>();
        }
        
        public static void EncodeToPNG_Save(this Texture2D tex, string szFile)
        {
            IntPtr ptr = Instance_Class.GetMethod(nameof(EncodeToPNG)).Invoke(new IntPtr[] { tex.ptr }).ptr;
            System.IO.IL2File.WriteAllBytes(szFile, ptr);
        }

        unsafe public static bool LoadImage(this Texture2D tex, byte[] data)
        {
            IntPtr result = IntPtr.Zero;
            if (data != null)
            {
                IntPtr[] ptrs = new IntPtr[data.Length];
                unsafe
                {
                    for (int i = 0; i < data.Length; i++)
                    {
                        fixed (byte* pointer = &data[i])
                        {
                            ptrs[i] = new IntPtr(pointer);
                        }
                    }
                }
                result = ptrs.ArrayToIntPtr(IL2SystemClass.Byte);
            }
            return Instance_Class.GetMethod(nameof(LoadImage), x => x.GetParameters().Length == 2).Invoke(new IntPtr[] { tex.ptr, result }).GetValuå<bool>();
        }

        public static IL2Class Instance_Class = Assembler.list["UnityEngine.ImageConversionModule"].GetClass("ImageConversion", "UnityEngine");
    }
}
