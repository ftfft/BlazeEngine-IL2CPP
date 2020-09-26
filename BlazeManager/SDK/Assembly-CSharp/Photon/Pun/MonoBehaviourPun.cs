using System;
using System.Linq;
using UnityEngine;
using BlazeIL.il2cpp;

namespace Photon.Pun
{
    public class MonoBehaviourPun : MonoBehaviour
    {
        public MonoBehaviourPun(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        private static IL2Property propertyPhotonView = null;
        public PhotonView photonView
		{
			get
            {
                if (propertyPhotonView == null)
                {
                    propertyPhotonView = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == PhotonView.Instance_Class.FullName);
                    if (propertyPhotonView == null)
                        return default;
                }

                return propertyPhotonView.GetGetMethod().Invoke(ptr)?.Unbox<PhotonView>();
            }
		}

		public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("MonoBehaviourPun", "Photon.Pun");
    }
}
