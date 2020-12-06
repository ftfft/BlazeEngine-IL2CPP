using System;
using System.Linq;
using BlazeIL.il2cpp;

namespace Photon.Realtime
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
                return property?.GetGetMethod().Invoke(ptr)?.unbox<LoadBalancingClient>();
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
            return methodSetMasterClient.Invoke(ptr, new IntPtr[]{ masterClientPlayer.ptr }).unbox_Unmanaged<bool>();
        }

        public new IL2String ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.unbox_ToString();
        }

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass(Player.Instance_Class.GetFields().First(x => x.ReturnType.Name.Length > 64).ReturnType.Name);
    }
}