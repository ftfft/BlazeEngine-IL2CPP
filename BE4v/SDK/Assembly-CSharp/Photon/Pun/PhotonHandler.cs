using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using IL2Photon.Realtime;

namespace IL2Photon.Pun
{
    public class PhotonHandler : ConnectionHandler
    {
        public PhotonHandler(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.BaseType?.FullName == ConnectionHandler.Instance_Class.FullName);
    }
}
