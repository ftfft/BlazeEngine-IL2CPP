using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE4v.SDK.CPP2IL
{
    public class IL2Param : IL2Base
    {
        public string Name { get; private set; }
        internal IL2Param(IntPtr ptr, string name) : base(ptr)
        {
            base.ptr = ptr;

            Name = name;
        }

        public IL2ClassType ReturnType => new IL2ClassType(ptr);
    }
}
