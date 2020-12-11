using System;
using BlazeIL.il2cpp;

namespace VRC.Steam
{
    public class ConnectionInterface : IL2Base
    {
        public ConnectionInterface(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass(SteamNetworkingConnectionInterface.Instance_Class.BaseType.FullName);
    }
}
