using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE4v.SDK.CPP2IL
{
    public static class IL2Utils
    {
        public static bool CheckIsObfus(string text)
        {
            if (text.Length < 30) return false;
            if (string.IsNullOrEmpty(text)) return true;
            text = text.Replace(text[0] + "" + text[1], string.Empty);
            if (string.IsNullOrEmpty(text)) return true;
            text = text.Replace(text[0] + "" + text[1], string.Empty);
            return string.IsNullOrEmpty(text);
        }

        public static IL2Class FindClass_ByPropertyName(this IL2Class[] klass, string @name)
        {
            int length = klass.Length;
            for (int i = 0; i < length; i++)
            {
                if (klass[i].GetProperty(@name) != null)
                    return klass[i];
            }
            return null;
        }
        
        public static IL2Class FindClass_ByMethodName(this IL2Class[] klass, string @name)
        {
            int length = klass.Length;
            for (int i = 0; i < length; i++)
            {
                if (klass[i].GetMethod(@name) != null)
                    return klass[i];
            }
            return null;
        }
        
        public static IL2Class FindClass_ByFieldName(this IL2Class[] klass, string @name)
        {
            int length = klass.Length;
            for (int i = 0; i < length; i++)
            {
                if (klass[i].GetField(@name) != null)
                    return klass[i];
            }
            return null;
        }

        public static IL2Class FindClass_ByNesestTypedName(this IL2Class[] klass, string @name)
        {
            int length = klass.Length;
            for (int i = 0; i < length; i++)
            {
                if (klass[i].GetNestedType(@name) != null)
                    return klass[i];
            }
            return null;
        }
    }
}
