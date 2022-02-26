using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class PlayerNet : VRCNetworkBehaviour
{
    public PlayerNet(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	public short Ping
	{
		get
		{
			IL2Property property = Instance_Class.GetProperty(nameof(Ping));
			if (property == null)
            {
				(property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == typeof(short).FullName)).Name = nameof(Ping);
				if (property == null)
					return default;
			}
			return property.GetGetMethod().Invoke(ptr).GetValuе<short>();
		}
	}

	// FPS
	public byte ApproxDeltaTimeMS
	{
		get
		{
			IL2Property property = Instance_Class.GetProperty(nameof(ApproxDeltaTimeMS));
			if (property == null)
			{
				(property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == typeof(byte).FullName)).Name = nameof(ApproxDeltaTimeMS);
				if (property == null)
					return default;
			}
			return property.GetGetMethod().Invoke(ptr).GetValuе<byte>();
		}
	}

	public static new IL2Class Instance_Class = Assembler.list["acs"].GetClass(VRC.Player.Instance_Class.GetField("_playerNet")?.ReturnType.Name);
}