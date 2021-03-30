using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace Steamworks
{
    public static class SteamClient
    {
        public static IL2Class Instance_Class = Assembler.list["Steamworks"].GetClass("SteamClient", "Steamworks");
    }
}
