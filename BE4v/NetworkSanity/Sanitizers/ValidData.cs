using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using IL2ExitGames.Client.Photon;
using NetworkSanity.Core;
using IL2Photon.Realtime;
using VRC.Core;
using VRC.SDKBase;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using BE4v.Patch;
using BE4v.Mods;
using BE4v.Serilize;

namespace NetworkSanity.Sanitizers
{
    internal class ValidData  //: ISanitizer
    {
        private readonly RateLimiter _rateLimiter = new RateLimiter();
        private readonly Dictionary<int, (long, int)> limit = new Dictionary<int, (long, int)>();

        public bool OnPhotonEvent(EventData eventData)
        {
            return IsValidClient(eventData);
        }

        public bool VRCNetworkingClientOnPhotonEvent(EventData eventData)
        {
            return _rateLimiter.IsRateLimited(eventData.Sender);
        }

        private bool IsValidClient(EventData eventData)
        {
            return false;
        }

    }
}