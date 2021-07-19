using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using System;
using System.Linq;


namespace IL2Photon.Realtime
{
    public class RaiseEventOptions : IL2Base
    {
        public RaiseEventOptions(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public RaiseEventOptions() : base(IntPtr.Zero)
        {
            ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetMethod(".ctor").Invoke(ptr);
        }

        unsafe public EventCaching CachingOption
        {
            get => Instance_Class.GetField(x => x.Token == 0x10).GetValue(ptr).GetValuе<EventCaching>();
            set => Instance_Class.GetField(x => x.Token == 0x10).SetValue(ptr, new IntPtr(&value));
        }
        
        unsafe public byte InterestGroup
        {
            get => Instance_Class.GetField(x => x.Token == 0x11).GetValue(ptr).GetValuе<byte>();
            set => Instance_Class.GetField(x => x.Token == 0x11).SetValue(ptr, new IntPtr(&value));
        }

        /*public int[] TargetActors
        {
            get => Instance_Class.GetField(x => x.Token == 0x18).GetValue(ptr)?.UnboxArraу<int>();
            set => Instance_Class.GetField(x => x.Token == 0x18).SetValue(ptr, (value == null) ? IntPtr.Zero : value.Select(x => CreateNewObject(x, IL2SystemClass.Int32)).ToArray().ArrayToIntPtr(IL2SystemClass.Int32));
        }
        
        public ReceiverGroup Receivers
        {
            get => Instance_Class.GetField(x => x.Token == 0x20).GetValue(ptr).GetValuе<ReceiverGroup>();
            set => Instance_Class.GetField(x => x.Token == 0x20).SetValue(ptr, value.MonoCast());
        }
        */
        public static IL2Class Instance_Class = Assembler.list["acs"].GetClass(LoadBalancingClient.Instance_Class?.GetMethods(x => x.GetParameters().Length == 4 && x.GetParameters()[0].ReturnType.Name == typeof(byte).FullName).First().GetParameters()[2].ReturnType.Name);
    }
}
