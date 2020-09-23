using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazeIL.il2cpp
{
    public class IL2ReturnType : IL2Base
    {
        internal IL2ReturnType(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public string Name => IL2Import.il2cpp_type_get_name(ptr);
    }
}
