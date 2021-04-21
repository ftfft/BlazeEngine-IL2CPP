using SharpDisasm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE4v.SDK.CPP2IL
{
    public class IL2Base
    {
        public IntPtr ptr { get; set; }
        public IL2Base(IntPtr ptr) => this.ptr = ptr;
        public override bool Equals(object obj)
        {
            if (obj == null) return this == null;
            if (obj is IL2Base b) return b.ptr == ptr;
            return false;
        }
        public T MonoCast<T>() => ptr.MonoCast<T>();
        public override int GetHashCode() => ptr.GetHashCode();
        public static bool operator !=(IL2Base x, IL2Base y) => !(x == y);
        public static bool operator ==(IL2Base x, IL2Base y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return x.ptr == y.ptr;
        }
        unsafe public Disassembler GetDisassembler(int @size = 0x1000)
        {
            return new Disassembler(*(IntPtr*)ptr, @size, ArchitectureMode.x86_64, unchecked((ulong)(*(IntPtr*)ptr).ToInt64()), true, Vendor.Intel);
        }
    }
}
