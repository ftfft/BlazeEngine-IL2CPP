using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL.il2cpp;

public class SteamNetworks : IL2Base
{
    public SteamNetworks(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClasses().First(x => x.GetFields().Where(y => y.ReturnType.Name == "Steamworks.SteamId").Count() == 1);
}
