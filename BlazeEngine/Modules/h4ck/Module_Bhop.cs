using System;
using CustomQuickMenu;
using UnityEngine;
using VRC;

public class Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5
{
    public static void \u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5()
    {
        if (BitUtils.GetBit(StatusBuff.enabledMods, Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ.\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5))
        {
            ((QMToggleButton)BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5").GetValue(null)).btnOn.SetActive(false);
            ((QMToggleButton)BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5").GetValue(null)).btnOff.SetActive(true);
            BitUtils.ClearBit(ref StatusBuff.enabledMods, Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ.\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5);
            return;
        }
        ((QMToggleButton)BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5").GetValue(null)).btnOn.SetActive(true);
        ((QMToggleButton)BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5").GetValue(null)).btnOff.SetActive(false);
        BitUtils.SetBit(ref StatusBuff.enabledMods, Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ.\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5);
    }

    public static void \u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ()
    {
        if ((bool)BlazeEngineAssembly.assemblyUnityCore.GetType("UnityEngine.Input").GetMethod("GetKey").Invoke(null, new object[] { KeyCode.Space }))
        {
            if (!(bool)BlazeEngineAssembly.assemblyUnityCore.GetType("UnityEngine.Input").GetMethod("GetKeyDown").Invoke(null, new object[] { KeyCode.Space }))
            {
                if (!Player.Instance.vrcPlayer.GetComponent<PlayerModComponentJump>().vrcInput.bValue || Player.Instance.vrcPlayer.GetComponent<PlayerModComponentJump>().vrcInput.bValuePrev)
                {
                    Player.Instance.vrcPlayer.GetComponent<PlayerModComponentJump>().vrcInput.bValue = true;
                    Player.Instance.vrcPlayer.GetComponent<PlayerModComponentJump>().vrcInput.bValuePrev = false;
                }
                else if (!Player.Instance.GetComponent<CharacterController>().isGrounded)
                {
                    Player.Instance.vrcPlayer.GetComponent<PlayerModComponentJump>().vrcInput.bValue = false;
                    Player.Instance.vrcPlayer.GetComponent<PlayerModComponentJump>().vrcInput.bValuePrev = true;
                }
            }
        }
    }
}
