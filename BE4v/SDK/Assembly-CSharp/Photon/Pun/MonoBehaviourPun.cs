using System;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace IL2Photon.Pun
{
    public class MonoBehaviourPun : MonoBehaviour
    {
        public MonoBehaviourPun(IntPtr ptr) : base(ptr) { }

        public PhotonView photonView
        {
			get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(photonView));
                if (property == null)
                    (property = Instance_Class.GetProperty(PhotonView.Instance_Class)).Name = nameof(photonView);
                return property?.GetGetMethod().Invoke()?.GetValue<PhotonView>();
            }
		}

        public static new IL2Class Instance_Class = VRCNetworkBehaviour.Instance_Class.BaseType;
    }
}
