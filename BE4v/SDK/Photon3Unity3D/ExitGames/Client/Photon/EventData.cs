using System;
using BE4v.SDK.CPP2IL;

namespace IL2ExitGames.Client.Photon
{
    public class EventData : IL2Base
    {
        public EventData(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public int Sender
        {
            get => Instance_Class.GetProperty(nameof(Sender)).GetGetMethod().Invoke(ptr).GetValuе<int>();
        }
        
        public IL2Object CustomData
        {
            get => Instance_Class.GetProperty(nameof(CustomData)).GetGetMethod().Invoke(ptr);
        }
        
        public byte Code
        {
            get => Instance_Class.GetField(nameof(Code)).GetValue(ptr).GetValuе<byte>();
        }

        public override string ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.GetValue<string>();
        }

        public static IL2Class Instance_Class = Assembler.list["Photon"].GetClass("EventData", "ExitGames.Client.Photon");
    }
}