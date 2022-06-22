using System;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace IL2Photon.Realtime
{
    public class ConnectionHandler : MonoBehaviour
	{
		public ConnectionHandler(IntPtr ptr) : base(ptr) { }

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass("ConnectionHandler", "Photon.Realtime");
    }
}