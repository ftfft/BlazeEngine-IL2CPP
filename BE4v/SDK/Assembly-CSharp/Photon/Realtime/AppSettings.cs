using System;
using BE4v.SDK.CPP2IL;

namespace IL2Photon.Realtime
{
    public class AppSettings : IL2Base
	{
		public AppSettings(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		unsafe public bool IsBestRegion
		{
			get => Instance_Class.GetProperty(nameof(IsBestRegion)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
			set => Instance_Class.GetProperty(nameof(IsBestRegion)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool IsMasterServerAddress
		{
			get => Instance_Class.GetProperty(nameof(IsMasterServerAddress)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
			set => Instance_Class.GetProperty(nameof(IsMasterServerAddress)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool IsDefaultNameServer
		{
			get => Instance_Class.GetProperty(nameof(IsDefaultNameServer)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
			set => Instance_Class.GetProperty(nameof(IsDefaultNameServer)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool IsDefaultPort
		{
			get => Instance_Class.GetProperty(nameof(IsDefaultPort)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
			set => Instance_Class.GetProperty(nameof(IsDefaultPort)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}
		
		public string AppIdRealtime
		{
			get => Instance_Class.GetField(nameof(AppIdRealtime)).GetValue(ptr).GetValue<string>();
			set => Instance_Class.GetField(nameof(AppIdRealtime)).SetValue(ptr, new IL2String(value).ptr);
		}


		public string AppIdChat
		{
			get => Instance_Class.GetField(nameof(AppIdChat)).GetValue(ptr).GetValue<string>();
			set => Instance_Class.GetField(nameof(AppIdChat)).SetValue(ptr, new IL2String(value).ptr);
		}


		public string AppIdVoice
		{
			get => Instance_Class.GetField(nameof(AppIdVoice)).GetValue(ptr).GetValue<string>();
			set => Instance_Class.GetField(nameof(AppIdVoice)).SetValue(ptr, new IL2String(value).ptr);
		}


		public string AppVersion
		{
			get => Instance_Class.GetField(nameof(AppVersion)).GetValue(ptr).GetValue<string>();
			set => Instance_Class.GetField(nameof(AppVersion)).SetValue(ptr, new IL2String(value).ptr);
		}


		unsafe public bool UseNameServer
		{
			get => Instance_Class.GetField(nameof(UseNameServer)).GetValue(ptr).GetValuе<bool>();
			set => Instance_Class.GetField(nameof(UseNameServer)).SetValue(ptr, new IntPtr(&value));
		}

		public string FixedRegion
		{
			get => Instance_Class.GetField(nameof(FixedRegion)).GetValue(ptr).GetValue<string>();
			set => Instance_Class.GetField(nameof(FixedRegion)).SetValue(ptr, new IL2String(value).ptr);
		}


		public string Server
		{
			get => Instance_Class.GetField(nameof(Server)).GetValue(ptr).GetValue<string>();
			set => Instance_Class.GetField(nameof(Server)).SetValue(ptr, new IL2String(value).ptr);
		}

		unsafe public int Port
		{
			get => Instance_Class.GetField(nameof(Port)).GetValue(ptr).GetValuе<int>();
			set => Instance_Class.GetField(nameof(Port)).SetValue(ptr, new IntPtr(&value));
		}
		/*
		public ConnectionProtocol Protocol
		{
			get => Instance_Class.GetField(nameof(Protocol)).GetValue(ptr).GetValuе<ConnectionProtocol>();
			set => Instance_Class.GetField(nameof(Protocol)).SetValue(ptr, value.MonoCast());
		}
		*/

		unsafe public bool EnableLobbyStatistics
		{
			get => Instance_Class.GetField(nameof(EnableLobbyStatistics)).GetValue(ptr).GetValuе<bool>();
			set => Instance_Class.GetField(nameof(EnableLobbyStatistics)).SetValue(ptr, new IntPtr(&value));
		}
		/*
		public DebugLevel NetworkLogging
        {
			get => Instance_Class.GetField(nameof(NetworkLogging)).GetValue(ptr).GetValuе<DebugLevel>();
			set => Instance_Class.GetField(nameof(NetworkLogging)).SetValue(ptr, value.MonoCast());
        }
		*/
		public static IL2Class Instance_Class = Assembler.list["acs"].GetClass("AppSettings", "Photon.Realtime");
    }
}