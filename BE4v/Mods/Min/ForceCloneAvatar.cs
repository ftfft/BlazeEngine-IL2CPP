using UnityEngine;
using VRC;
using BE4v.Mods.Core;

namespace BE4v.Mods.Min
{
    public class ForceCloneAvatar : IUpdate
    {
        public void Update()
        {
            MenuEdit.BE4V_SelectedMenu.ForceCloneAvatar.Update();
        }
    }
}
