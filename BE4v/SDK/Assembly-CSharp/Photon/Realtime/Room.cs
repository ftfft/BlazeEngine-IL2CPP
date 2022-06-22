using System;
using System.Linq;
using IL2CPP_Core.Objects;

namespace IL2Photon.Realtime
{
    public class Room : RoomInfo
    {
        public Room(IntPtr ptr) : base(ptr) { }

        public LoadBalancingClient LoadBalancingClient
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(LoadBalancingClient));
                if (property == null)
                    (property = Instance_Class.GetProperty(LoadBalancingClient.Instance_Class)).Name = nameof(LoadBalancingClient);
                return property?.GetGetMethod().Invoke(this)?.GetValue<LoadBalancingClient>();
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
            return methodSetMasterClient.Invoke<bool>(this, new IntPtr[]{ masterClientPlayer.Pointer }).GetValue();
        }

        public override string ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(this)?.GetValue<IL2String>().ToString();
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClass(Player.Instance_Class.GetFields().First(x => x.ReturnType.Name.Length > 64).ReturnType.Name);
    }
}