using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

namespace System.IO
{
    public abstract class IL2Stream : IL2Base
    {
        public IL2Stream(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("Stream", "System.IO");
    }
}
