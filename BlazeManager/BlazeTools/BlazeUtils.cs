using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL.il2cpp;

public static class BlazeUtils
{
    public static IL2String IL2String(this string str) => new IL2String(str);
    public static IL2String IL2String(this IntPtr ptr) => new IL2String(ptr);
}
