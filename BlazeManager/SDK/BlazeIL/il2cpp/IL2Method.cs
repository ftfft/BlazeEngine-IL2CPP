using System;
using BlazeIL.il2reflection;
using System.Reflection;

namespace BlazeIL.il2cpp
{
    public class IL2Method : IL2MethodBody
    {
        internal IL2Method(IntPtr ptr) : base(ptr) => base.ptr = ptr;
    }
}
