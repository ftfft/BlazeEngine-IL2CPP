using BE4v.SDK.CPP2IL;
using System;
// using IL2ExitGames.Client.Photon;

namespace IL2Photon.Realtime
{

    public class RoomInfo : IL2Base
    {
        public RoomInfo(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        /*
        public Hashtable CustomProperties
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(CustomProperties));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == Hashtable.Instance_Class.FullName)).Name = nameof(CustomProperties);
                return property?.GetGetMethod().Invoke(ptr)?.GetValuå<Hashtable>();
            }
        }
        */
        public override string ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.GetValue<string>();
        }

        public static IL2Class Instance_Class = Assembler.list["acs"].GetClass(Room.Instance_Class.BaseType.FullName);
    }
}