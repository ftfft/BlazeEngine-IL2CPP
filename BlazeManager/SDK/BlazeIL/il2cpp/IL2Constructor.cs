using System;
using BlazeIL.il2reflection;

namespace BlazeIL.il2cpp
{
    public class IL2Constructor : IL2Method
    {
        internal IL2Constructor(IntPtr ptr) : base(ptr) => base.ptr = ptr;
    }
}
