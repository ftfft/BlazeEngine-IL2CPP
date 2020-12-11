using System;
using BlazeIL.il2cpp;

namespace IL2ExitGames.Client.Photon
{
    public class EventData : IL2Base
    {
        public EventData(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public int Sender
        {
            get => Instance_Class.GetProperty(nameof(Sender)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<int>();
        }
        
        public IL2Object CustomData
        {
            get => Instance_Class.GetProperty(nameof(CustomData)).GetGetMethod().Invoke(ptr);
        }
        
        public byte Code
        {
            get => Instance_Class.GetField(nameof(Code)).GetValue(ptr).unbox_Unmanaged<byte>();
        }

        public new IL2String ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.unbox_ToString();
        }

        public static IL2Type Instance_Class = Assemblies.a["Photon3Unity3D"].GetClass("EventData", "ExitGames.Client.Photon");
        // public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.photon3unity3d]].GetClass("EventData", "ExitGames.Client.Photon");
    }
}