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
    internal class OwnershipTransfer // : ISanitizer
    {
        private readonly RateLimiter _rateLimiter = new RateLimiter();
        private readonly Dictionary<int, (long, int)> limit = new Dictionary<int, (long, int)>();

        // OwnershipRequest 209
        // OwnershipTransfer 210
        public bool OnPhotonEvent(EventData eventData)
        {
            /*
            if (eventData.CustomData != null)
            {
                byte[] bytes = new IL2Array<byte>(eventData.CustomData.ptr).ToBytesArray();
                if (bytes.Length == 8)
                {

                    var i1 = BitConverter.ToInt32(bytes, 0);
                    var i2 = BitConverter.ToInt32(bytes, 4);
                    Console.WriteLine($"Sender: {eventData.Sender} code: {eventData.Code} ownership: arg1 {i1} arg2 {i2}");
                }
            }
            */
            if (eventData.Code != 209 && eventData.Code != 210)
                return false;

            return true;
            // return IsOwnershipTransfer(eventData);
        }

        public bool VRCNetworkingClientOnPhotonEvent(EventData eventData)
        {
            if (eventData.Code != 209 && eventData.Code != 210)
                return false;

            return true;
            //return _rateLimiter.IsRateLimited(eventData.Sender);
        }

        private bool IsOwnershipTransfer(EventData eventData)
        {
            return true;
            IL2Object obj = eventData.CustomData;
            if (obj == null)
            {
                _rateLimiter.BlacklistUser(eventData.Sender, eventData.Code, "CustomData == null");
                return true;
            }

            byte[] bytes = new IL2Array<byte>(eventData.CustomData.ptr).ToBytesArray();
            if (bytes.Length != 8)
            {
                _rateLimiter.BlacklistUser(eventData.Sender, eventData.Code, "len != 8");
                return true;
            }

            int transObj = BitConverter.ToInt32(bytes, 0);
            int sender = BitConverter.ToInt32(bytes, 4);
            /*
            if (transObj.ToString().StartsWith(sender.ToString()))
            {
                for (int i = 1; i <= 4; i++)
                {
                    if (transObj.ToString() == sender + "0000" + i)
                    {
                        return true;
                    }
                }
            }
            */
            if (transObj <= 0 || transObj > 100000)
            {
                return true;
            }

            // [Debug 210] Sender: 521 | TransObject: 62800004 | Sender: 628
            $"Sender: {eventData.Sender} | TransObject: {transObj} | Sender: {sender}".RedPrefix("Debug " + eventData.Code);
            /*
            int sender = eventData.Sender;
            var argObject = BitConverter.ToInt32(bytes, 0);
            var argSender = BitConverter.ToInt32(bytes, 4);
            if (argObject <= 0)
            {
                _rateLimiter.BlacklistUser(eventData.Sender, eventData.Code, "object <= 0  |" + argObject + "|" + argSender);
                return true;
            }
            for (int i=0;i<=5;i++)
            {
                if (argSender.ToString() == argObject + "0000" + i)
                {
                    return true;
                }
            }
            /*
            if (!limit.ContainsKey(sender))
            {
                limit.Add(sender, (Threads.timestamp, 0));
            }
            else
            {
                if (limit[sender].Item1 != Threads.timestamp)
                {
                    limit.Remove(sender);
                    return true;
                }
                limit[sender] = (limit[sender].Item1, limit[sender].Item2 + 1);
                if (limit[sender].Item2 > 5)
                {
                    _rateLimiter.BlacklistUser(eventData.Sender);
                    return true;
                }
            }
            */
            return false;
        }

    }
}