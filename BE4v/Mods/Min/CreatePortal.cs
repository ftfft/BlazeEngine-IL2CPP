using UnityEngine;
using VRC;
using BE4v.Mods.Core;

namespace BE4v.Mods.Min
{
    public class CreatePortal : IUpdate
    {
        public void Update()
        {
            if (!Threads.isCtrl) return;
            if (Input.GetKeyDown(KeyCode.T))
            {
                Player player = Player.Instance;
                if (player == null) return;
                UserUtils.SpawnPortal(player.transform, ClientConsole.worldId, ClientConsole.instanceId);
            }
        }
    }
}
