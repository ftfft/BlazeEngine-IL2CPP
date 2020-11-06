using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;

namespace Photon.Pun
{
    public class PhotonView : Component
    {
        public PhotonView(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public int viewIdField
        {
            get
            {
                if (!fields.ContainsKey(nameof(viewIdField)))
                {
                    fields.Add(nameof(viewIdField), Instance_Class.GetField("viewIdField"));
                    if (!fields.ContainsKey(nameof(viewIdField)))
                        return default;
                }

                return fields[nameof(viewIdField)].GetValue(ptr).unbox_Unmanaged<int>();
            }
        }
        public static PhotonView Find(int viewId)
        {
            if (!methods.ContainsKey(nameof(Find)))
            {
                methods.Add(nameof(Find), Instance_Class.GetMethods().First(x =>
                    x.IsStatic &&
                    x.ReturnType.Name == Instance_Class.FullName &&
                    x.GetParameters()[0].ReturnType.Name == typeof(int).FullName
                ));
                if (!methods.ContainsKey(nameof(Find)))
                    return null;
            }
            return methods[nameof(Find)].Invoke(new IntPtr[] { viewId.MonoCast() })?.unbox<PhotonView>();
        }

        public void RPC(string command, TargetType target, params IntPtr[] objects)
        {
            PhotonNetwork.RPCSecure(this, command, target, false, objects);
        }

        public void RpcSecure(string command, TargetType target, bool encrypt, params IntPtr[] objects) 
        {
            PhotonNetwork.RPCSecure(this, command, target, encrypt, objects);
        }

        public void RpcSecure(string command, PhotonPlayer target, bool encrypt, params IntPtr[] objects) 
        {
            if (!methods.ContainsKey(nameof(RpcSecure)))
            {
                methods.Add(nameof(RpcSecure), Instance_Class.GetMethods().First(x =>
                    x.GetParameters().Length == 4 &&
                    x.GetParameters()[0].ReturnType.Name == typeof(string).FullName &&
                    x.GetParameters()[1].ReturnType.Name == PhotonPlayer.Instance_Class.FullName &&
                    x.GetParameters()[2].ReturnType.Name == typeof(bool).FullName &&
                    x.GetParameters()[3].ReturnType.Name == typeof(object[]).FullName
                ));
                if (!methods.ContainsKey(nameof(RpcSecure)))
                    return;
            }
            methods[nameof(RpcSecure)].Invoke(ptr, new IntPtr[] { new IL2String(command).ptr, target.ptr, encrypt.MonoCast(), objects.ArrayToIntPtr() });
        }

        public static Dictionary<string, IL2Property> properties = new Dictionary<string, IL2Property>();
        public static Dictionary<string, IL2Method> methods = new Dictionary<string, IL2Method>();
        public static Dictionary<string, IL2Field> fields = new Dictionary<string, IL2Field>();

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PhotonView", "Photon.Pun");
    }
}
