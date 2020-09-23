using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL.il2cpp;

public class PhotonSettings : IL2Base
{
    public PhotonSettings(IntPtr ptr) : base(ptr) => base.ptr = ptr;


    public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClasses().Where(x => x.FullName != "Photon.Realtime.AppSettings").First(x => x.GetFields().Where(y => y.ReturnType.Name == "ExitGames.Client.Photon.ConnectionProtocol").Count() == 1);
}
