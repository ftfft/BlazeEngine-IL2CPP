using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL.il2cpp;
using BlazeIL.cpp2il.IL;
using SharpDisasm;
using SharpDisasm.Udis86;

namespace BlazeIL.cpp2il
{
    unsafe public static class disasm
    {
        public static Disassembler GetDisassembler(IL2Base @base, int @size = 0x1000) => new Disassembler(*(IntPtr*)@base.ptr, @size, ArchitectureMode.x86_64, unchecked((ulong)(*(IntPtr*)@base.ptr).ToInt64()), true, Vendor.Intel);
    }
}
