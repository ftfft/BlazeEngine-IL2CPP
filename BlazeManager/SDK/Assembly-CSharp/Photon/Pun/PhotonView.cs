using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;

namespace Photon.Pun
{
    public class PhotonView : MonoBehaviour
    {
        public PhotonView(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public int viewIdField
        {
            get => Instance_Class.GetField(nameof(viewIdField)).GetValue(ptr).unbox_Unmanaged<int>();
        }

        public static PhotonView Find(int viewID)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(Find));
            if (method == null)
                (method = Instance_Class.GetMethod(x => x.ReturnType.Name == Instance_Class.FullName && x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == typeof(int).FullName)).Name = nameof(Find);
            return method?.Invoke(new IntPtr[] { viewID.MonoCast() }).unbox<PhotonView>();
        }

        public void RPC(string command, RpcTarget target, params IntPtr[] objects)
        {
            RpcSecure(command, target, false, objects);
        }

        public void RpcSecure(string command, RpcTarget target, bool encrypt, params IntPtr[] objects) 
        {
            PhotonNetwork.RPC(this, command, target, encrypt, objects);
        }

        public void RPC(string command, Photon.Realtime.Player targetPlayer, params IntPtr[] objects)
        {
            RpcSecure(command, targetPlayer, false, objects);
        }

        public void RpcSecure(string command, Photon.Realtime.Player targetPlayer, bool encrypt, params IntPtr[] objects) 
        {
            PhotonNetwork.RPC(this, command, targetPlayer, encrypt, objects);
        }

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PhotonView", "Photon.Pun");
    }
}
