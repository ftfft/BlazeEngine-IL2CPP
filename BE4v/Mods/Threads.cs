using System;
using UnityEngine;
using BE4v.Mods.Core;
using BE4v.MenuEdit.Construct;

namespace BE4v.Mods
{
    public class Threads : IUpdate
    {
        public static bool isCtrl = false;

        public static long timestamp = 0;

        public void Update()
        {
            if (!isLoadedCharacter)
            {
                isLoadedCharacter = true;
                Application.targetFrameRate = 101;
                LoadSprites.DownloadAll();

                GameObject gameObject = new GameObject("BE4V_GUI");
                gameObject.AddComponent<OVRLipSyncMicInput>();
                UnityEngine.Object.DontDestroyOnLoad(gameObject);
            }
            if (--NetworkSanity.Sanitizers.OwnershipTransfer.fps < 0)
            {
                NetworkSanity.Sanitizers.OwnershipTransfer.fps = 5;
                NetworkSanity.Sanitizers.OwnershipTransfer.limit.Clear();
            }
            timestamp = UnixTimeNow();
            if (Input.GetKeyDown(KeyCode.I))
            {
                float volume = USpeaker.LocalGain;
                if (volume <= 1f)
                {
                    USpeaker.LocalGain = float.MaxValue;
                    "Enabled Max Volume".RedPrefix("MaxGain");
                }
                else
                {
                    USpeaker.LocalGain = 1f;
                    "Disabled Max Volume".RedPrefix("MaxGain");
                }
                return;
            }
        }

        public static void UpdatePlayers()
        {
            NetworkSanity.NetworkSanity.players = VRC.PlayerManager.PlayersCopy;
            int len = NetworkSanity.NetworkSanity.players.Length;
            if (len > 0)
            {
                VRC.PlayerManager.MasterId = NetworkSanity.NetworkSanity.players[0].PhotonPlayer.ActorNumber;
                if (VRC.PlayerManager.MasterId < 0 && len > 1)
                {
                    VRC.PlayerManager.MasterId = NetworkSanity.NetworkSanity.players[1].PhotonPlayer.ActorNumber;
                 }
            }
            else
                VRC.PlayerManager.MasterId = 0;
        }

        public static long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }

        private static bool isLoadedCharacter = false;
    }
}
