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

        public static IL2Class Instance_Class = Assembler.list["UnityEngine.ImageConversionModule"].GetClass("ImageConversion", "UnityEngine");
    }
}
