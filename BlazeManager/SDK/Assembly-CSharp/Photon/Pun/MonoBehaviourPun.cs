using System;
using UnityEngine;
using BlazeIL.il2cpp;

namespace IL2Photon.Pun
{
    public class MonoBehaviourPun : MonoBehaviour
    {
        public MonoBehaviourPun(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public PhotonView photonView
        {
			get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(photonView));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == PhotonView.Instance_Class.FullName)).Name = nameof(photonView);
                return property?.GetGetMethod().Invoke()?.unbox<PhotonView>();
            }
		}

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("MonoBehaviourPun", "Photon.Pun");
    }
}
