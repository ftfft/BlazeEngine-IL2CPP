using System;
using System.Linq;
using BlazeTools;
using BlazeIL;
using BlazeIL.il2cpp;

namespace IL2Photon.Realtime
{
    public class RaiseEventOptions : IL2Base
    {
        public RaiseEventOptions(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public RaiseEventOptions() : base(IntPtr.Zero)
        {
            ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetConstructor().Invoke(ptr);
        }

        public EventCaching CachingOption
        {
            get => Instance_Class.GetField(x => x.Token == 0x10).GetValue(ptr).unbox_Unmanaged<EventCaching>();
            set => Instance_Class.GetField(x => x.Token == 0x10).SetValue(ptr, value.MonoCast());
        }
        
        public byte InterestGroup
        {
            get => Instance_Class.GetField(x => x.Token == 0x11).GetValue(ptr).unbox_Unmanaged<byte>();
            set => Instance_Class.GetField(x => x.Token == 0x11).SetValue(ptr, value.MonoCast());
        }

        public int[] TargetActors
        {
            get => Instance_Class.GetField(x => x.Token == 0x18).GetValue(ptr)?.unbox_ToArray_Unmanaged<int>();
            set => Instance_Class.GetField(x => x.Token == 0x18).SetValue(ptr, (value == null) ? IntPtr.Zero : value.Select(x => IL2Import.CreateNewObject(x, IL2SystemClass.Int32)).ToArray().ArrayToIntPtr(IL2SystemClass.Int32));
        }
        
        public ReceiverGroup Receivers
        {
            get => Instance_Class.GetField(x => x.Token == 0x20).GetValue(ptr).unbox_Unmanaged<ReceiverGroup>();
            set => Instance_Class.GetField(x => x.Token == 0x20).SetValue(ptr, value.MonoCast());
        }

        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass(LoadBalancingClient.Instance_Class?.GetMethods(x => x.GetParameters().Length == 4 && x.GetParameters()[0].ReturnType.Name == "System.Byte").First().GetParameters()[2].ReturnType.Name);
    }
}
