using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NetworkSanity.Core;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using IL2ExitGames.Client.Photon;
using IL2Photon.Realtime;

namespace NetworkSanity
{
    public static class NetworkSanity
    {
        public static List<int> userList = new List<int>();

        public static void Start()
        {
            IEnumerable<Type> types;
            try
            {
                types = Assembly.GetExecutingAssembly().GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                types = e.Types.Where(t => t != null);
            }
            List<ISanitizer> sanitar = new List<ISanitizer>();
            foreach (var t in types)
            {
                if (t.IsAbstract)
                    continue;
                if (!typeof(ISanitizer).IsAssignableFrom(t))
                    continue;

                var sanitizer = Activator.CreateInstance(t) as ISanitizer;
                sanitar.Add(sanitizer);
                $"Add Interface: {t.Name}".GreenPrefix("Sanitizer");
            }
            Sanitizers = sanitar.ToArray();
        }

        public static class LoadBalancingClient
        {
            public static bool OnEvent(IntPtr eventDataPtr)
            {
                if (eventDataPtr == IntPtr.Zero)
                    return false;

                var eventData = new EventData(eventDataPtr);

                int sender = eventData.Sender;
                if (sender < 1) return true;
                int eventCode = eventData.Code;
                if (eventCode == EventCode.Leave)
                {
                    if (userList.Contains(sender))
                        userList.Remove(sender);

                    return true;
                }

                foreach (var i in Sanitizers)
                {
                    if (i.OnPhotonEvent(eventData))
                        return false;
                }
                return true;
            }
        }

        public static class VRCNetworkingClient
        {
            public static bool OnEvent(IntPtr eventDataPtr)
            {
                if (eventDataPtr == IntPtr.Zero)
                    return false;

                var eventData = new EventData(eventDataPtr);

                int sender = eventData.Sender;
                if (sender < 1) return true;
                int eventCode = eventData.Code;
                if (eventCode == EventCode.Leave)
                {
                    if (userList.Contains(sender))
                        userList.Remove(sender);

                    return true;
                }

                foreach (var i in Sanitizers)
                {
                    if (i.VRCNetworkingClientOnPhotonEvent(eventData))
                        return false;
                }

                return true;
            }
        }
        
        public static class PhotonNetwork
        {
            public static bool OnEvent(IntPtr eventDataPtr)
            {
                if (eventDataPtr == IntPtr.Zero)
                    return false;

                var eventData = new EventData(eventDataPtr);

                int sender = eventData.Sender;
                if (sender < 1) return true;
                int eventCode = eventData.Code;
                if (eventCode == EventCode.Leave)
                {
                    if (userList.Contains(sender))
                        userList.Remove(sender);

                    return true;
                }

                foreach (var i in Sanitizers)
                {
                    if (i.OnPhotonEvent(eventData))
                        return false;
                }

                return true;
            }
        }

        private static ISanitizer[] Sanitizers = new ISanitizer[0];

        public static string github_thx = "https://github.com/RequiDev/NetworkSanity/";
    }
}
