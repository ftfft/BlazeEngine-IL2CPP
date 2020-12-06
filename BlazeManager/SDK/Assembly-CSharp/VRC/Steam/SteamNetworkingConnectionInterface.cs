using System;
using System.Linq;
using BlazeIL.il2cpp;

namespace VRC.Steam
{
    public class SteamNetworkingConnectionInterface : ConnectionInterface
    {
        public SteamNetworkingConnectionInterface(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClasses().First(x => x.GetFields().Where(y => y.ReturnType.Name == "Steamworks.SteamId").Count() == 1);
    }
}
