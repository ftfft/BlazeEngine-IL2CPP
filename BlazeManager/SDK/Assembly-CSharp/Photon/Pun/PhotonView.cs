using System;
using System.Collections.Generic;
using UnityEngine;
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

        public static Dictionary<string, IL2Property> properties = new Dictionary<string, IL2Property>();
        public static Dictionary<string, IL2Method> methods = new Dictionary<string, IL2Method>();
        public static Dictionary<string, IL2Field> fields = new Dictionary<string, IL2Field>();

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PhotonView", "Photon.Pun");
    }
}
