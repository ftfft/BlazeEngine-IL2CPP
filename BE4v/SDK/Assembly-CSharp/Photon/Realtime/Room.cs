using System;
using System.Linq;
using BE4v.SDK.CPP2IL;

namespace IL2Photon.Realtime
{
    public class Room : RoomInfo
    {
        public Room(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public LoadBalancingClient LoadBalancingClient
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(LoadBalancingClient));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == LoadBalancingClient.Instance_Class.FullName)).Name = nameof(LoadBalancingClient);
                return property?.GetGetMethod().Invoke(ptr)?.GetValue<LoadBalancingClient>();
            }
        }

        private static IL2Method methodSetMasterClient = null;
        public bool SetMasterClient(Player masterClientPlayer)
        {
            if (methodSetMasterClient == null)
            {
                methodSetMasterClient = Instance_Class.GetMethods().First(x => !x.IsStatic && x.IsPublic && x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == Player.Instance_Class.FullName && x.ReturnType.Name == typeof(bool).FullName);
                if (methodSetMasterClient == null)
                    return default;
            }
            return methodSetMasterClient.Invoke(ptr, new IntPtr[]{ masterClientPlayer.ptr }).GetValuå<bool>();
        }

        public override string ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.GetValue<string>();
        }

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClass(Player.Instance_Class.GetFields().First(x => x.ReturnType.Name.Length > 64).ReturnType.Name);
    }
}