using System;
using BlazeIL.il2cpp;

public class PlayerNet : VRCNetworkBehaviour
{
    public PlayerNet(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("PlayerNet");
}