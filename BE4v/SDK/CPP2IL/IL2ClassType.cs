using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE4v.SDK.CPP2IL
{
    public class IL2ClassType : IL2Base
    {
        internal IL2ClassType(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public string Name
        {
            get => Import.Object.il2cpp_type_get_name(ptr);
        }
    }
}
