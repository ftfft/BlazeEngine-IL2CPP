using System;
using UnityEngine;
using BE4v.SDK.CPP2IL;

namespace IL2Photon.Realtime
{
    public class ConnectionHandler : MonoBehaviour
	{
		public ConnectionHandler(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public static new IL2Class Instance_Class = Assembler.list["acs"].GetClass("ConnectionHandler", "Photon.Realtime");
    }
}