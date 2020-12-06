namespace VRC.Management
{
    public class ModNetworkEvent
	{
		public const byte Enforce_Moderation = 1;

		public const byte Alert = 2;

		public const byte Warn = 3;

		public const byte Kick = 4;

		public const byte Vote_Kick = 5;

		public const byte Public_Ban = 6;

		public const byte Ban = 7;

		public const byte Mic_Off = 8;

		public const byte Mic_Volume_Adjust = 9;

		public const byte Friend_Change = 10;

		public const byte Warp_To_Instance = 11;

		public const byte Teleport_User = 12;

		public const byte Query = 13;

		public const byte Request_PlayerMods = 20;

		public const byte Reply_PlayerMods = 21;

		public const byte Block_User = 22;

		public const byte Mute_User = 23;
	}
}