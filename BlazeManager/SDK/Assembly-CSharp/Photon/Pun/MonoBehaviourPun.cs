using System;
using System.Collections.Generic;
using UnityEngine;
using BlazeIL.il2cpp;

namespace Photon.Pun
{
    public class MonoBehaviourPun : MonoBehaviour
    {
        public MonoBehaviourPun(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public PhotonView photonView
		{
			get
            {
                if (!properties.ContainsKey(nameof(photonView)))
                {
                    properties.Add(nameof(photonView), Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == PhotonView.Instance_Class.FullName));
                    if (!properties.ContainsKey(nameof(photonView)))
                        return null;
                }
                return properties[nameof(photonView)].GetGetMethod().Invoke(ptr)?.unbox<PhotonView>();
            }
		}

        public static Dictionary<string, IL2Property> properties = new Dictionary<string, IL2Property>();
        public static Dictionary<string, IL2Method> methods = new Dictionary<string, IL2Method>();
        public static Dictionary<string, IL2Field> fields = new Dictionary<string, IL2Field>();

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("MonoBehaviourPun", "Photon.Pun");
    }
}
