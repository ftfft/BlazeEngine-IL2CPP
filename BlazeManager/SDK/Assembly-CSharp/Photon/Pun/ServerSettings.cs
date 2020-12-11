using System;
using BlazeIL.il2cpp;
using IL2Photon.Realtime;

namespace IL2Photon.Pun
{
    public class ServerSettings : UnityEngine.Object
    {
        public ServerSettings(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public AppSettings AppSettings
        {
            get => Instance_Class.GetField(nameof(AppSettings)).GetValue(ptr)?.unbox<AppSettings>();
            set => Instance_Class.GetField(nameof(AppSettings)).SetValue(ptr, value.ptr);
        }

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("ServerSettings", "Photon.Pun");
    }
}
