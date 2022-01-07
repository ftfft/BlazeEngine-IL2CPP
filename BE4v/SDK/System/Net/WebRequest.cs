using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

namespace System.Net
{
    public class IL2WebRequest : IL2Base
    {
        public IL2WebRequest(IntPtr ptr) : base(ptr) => base.ptr = ptr;


		public static IL2Class Instance_Class = Assembler.list["System"].GetClass("WebRequest", "System.Net");
    }
}
