using System;
using BlazeIL;
using BlazeIL.il2cpp;
using IL2ExitGames.Client.Photon;

namespace IL2Photon.Realtime
{
    public class AppSettings : IL2Base
	{
		public AppSettings(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public bool IsBestRegion
		{
			get => Instance_Class.GetProperty(nameof(IsBestRegion)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
			set => Instance_Class.GetProperty(nameof(IsBestRegion)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
		}
		
		public bool IsMasterServerAddress
		{
			get => Instance_Class.GetProperty(nameof(IsMasterServerAddress)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
			set => Instance_Class.GetProperty(nameof(IsMasterServerAddress)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
		}
		
		public bool IsDefaultNameServer
		{
			get => Instance_Class.GetProperty(nameof(IsDefaultNameServer)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
			set => Instance_Class.GetProperty(nameof(IsDefaultNameServer)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
		}
		
		public bool IsDefaultPort
		{
			get => Instance_Class.GetProperty(nameof(IsDefaultPort)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
			set => Instance_Class.GetProperty(nameof(IsDefaultPort)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
		}
		
		public string AppIdRealtime
		{
			get => Instance_Class.GetField(nameof(AppIdRealtime)).GetValue(ptr).unbox_ToString().ToString();
			set => Instance_Class.GetField(nameof(AppIdRealtime)).SetValue(ptr, new IL2String(value).ptr);
		}


		public string AppIdChat
		{
			get => Instance_Class.GetField(nameof(AppIdChat)).GetValue(ptr).unbox_ToString().ToString();
			set => Instance_Class.GetField(nameof(AppIdChat)).SetValue(ptr, new IL2String(value).ptr);
		}


		public string AppIdVoice
		{
			get => Instance_Class.GetField(nameof(AppIdVoice)).GetValue(ptr).unbox_ToString().ToString();
			set => Instance_Class.GetField(nameof(AppIdVoice)).SetValue(ptr, new IL2String(value).ptr);
		}


		public string AppVersion
		{
			get => Instance_Class.GetField(nameof(AppVersion)).GetValue(ptr).unbox_ToString().ToString();
			set => Instance_Class.GetField(nameof(AppVersion)).SetValue(ptr, new IL2String(value).ptr);
		}


		public bool UseNameServer
		{
			get => Instance_Class.GetField(nameof(UseNameServer)).GetValue(ptr).unbox_Unmanaged<bool>();
			set => Instance_Class.GetField(nameof(UseNameServer)).SetValue(ptr, value.MonoCast());
		}

		public string FixedRegion
		{
			get => Instance_Class.GetField(nameof(FixedRegion)).GetValue(ptr).unbox_ToString().ToString();
			set => Instance_Class.GetField(nameof(FixedRegion)).SetValue(ptr, new IL2String(value).ptr);
		}


		public string Server
		{
			get => Instance_Class.GetField(nameof(Server)).GetValue(ptr).unbox_ToString().ToString();
			set => Instance_Class.GetField(nameof(Server)).SetValue(ptr, new IL2String(value).ptr);
		}

		public int Port
		{
			get => Instance_Class.GetField(nameof(Port)).GetValue(ptr).unbox_Unmanaged<int>();
			set => Instance_Class.GetField(nameof(Port)).SetValue(ptr, value.MonoCast());
		}

		public ConnectionProtocol Protocol
		{
			get => Instance_Class.GetField(nameof(Protocol)).GetValue(ptr).unbox_Unmanaged<ConnectionProtocol>();
			set => Instance_Class.GetField(nameof(Protocol)).SetValue(ptr, value.MonoCast());
		}


		public bool EnableLobbyStatistics
		{
			get => Instance_Class.GetField(nameof(EnableLobbyStatistics)).GetValue(ptr).unbox_Unmanaged<bool>();
			set => Instance_Class.GetField(nameof(EnableLobbyStatistics)).SetValue(ptr, value.MonoCast());
		}

		public DebugLevel NetworkLogging
        {
			get => Instance_Class.GetField(nameof(NetworkLogging)).GetValue(ptr).unbox_Unmanaged<DebugLevel>();
			set => Instance_Class.GetField(nameof(NetworkLogging)).SetValue(ptr, value.MonoCast());
        }

		public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("AppSettings", "Photon.Realtime");
    }
}