using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL.il2cpp;

public static class BlazeUtils
{
    public static IL2String IL2String(this string str) => new IL2String(str);
    public static IL2String IL2String(this IntPtr ptr) => new IL2String(ptr);

    public static bool IsBase64(this string base64String)
    {
         if (string.IsNullOrEmpty(base64String) || base64String.Length % 4 != 0
            || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
            return false;
        try
        {
            Convert.FromBase64String(base64String);
            return true;
        }
        catch { }
        return false;
    }
}
