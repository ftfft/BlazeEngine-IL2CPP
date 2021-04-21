using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace Steamworks
{
    public class SocketInterface : IL2Base
    {
        public SocketInterface(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static IL2Class Instance_Class = Assembler.list["Steamworks"].GetClass("SocketInterface", "Steamworks");
    }
}
