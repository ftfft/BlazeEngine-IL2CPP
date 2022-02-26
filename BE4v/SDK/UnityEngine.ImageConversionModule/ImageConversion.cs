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
            IL2Array<byte> result = null;
            if (data != null)
            {
                result = new IL2Array<byte>(data.Length, IL2SystemClass.Byte);
                for (int i = 0; i < data.Length; i++)
                {
                    result[i] = data[i];
                }
            }
            return LoadImage(tex, result.ptr);
        }
        
        unsafe public static bool LoadImage(this Texture2D tex, IntPtr data)
        {
            return Instance_Class.GetMethod(nameof(LoadImage), x => x.GetParameters().Length == 2).Invoke(new IntPtr[] { tex.ptr, data }).GetValuå<bool>();
        }

        public static IL2Class Instance_Class = Assembler.list["UnityEngine.ImageConversionModule"].GetClass("ImageConversion", "UnityEngine");
    }
}
