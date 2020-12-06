using System;
using BlazeIL.il2cpp;
using ExitGames.Client.Photon;

namespace Photon.Realtime
{

    public class RoomInfo : IL2Base
    {
        public RoomInfo(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public Hashtable CustomProperties
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(CustomProperties));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == Hashtable.Instance_Class.FullName)).Name = nameof(CustomProperties);
                return property?.GetGetMethod().Invoke(ptr)?.unbox<Hashtable>();
            }
        }

        public new IL2String ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.unbox_ToString();
        }

        public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass(Room.Instance_Class.BaseType.FullName);
    }
}