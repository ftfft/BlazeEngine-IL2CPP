using System;
using UnityEngine;
using CustomQuickMenu;
using VRC;

public class Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5
{
    public static void \u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5()
    {
        if (BitUtils.GetBit(StatusBuff.enabledMods, Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ.\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5))
        {
            ((QMToggleButton)BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetValue(null)).btnOn.SetActive(false);
            ((QMToggleButton)BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetValue(null)).btnOff.SetActive(true);
            BitUtils.ClearBit(ref StatusBuff.enabledMods, Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ.\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5);
            return;
        }
        ((QMToggleButton)BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetValue(null)).btnOn.SetActive(true);
        ((QMToggleButton)BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetValue(null)).btnOff.SetActive(false);
        BitUtils.SetBit(ref StatusBuff.enabledMods, Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ.\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5);
    }
    public static void \u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5()
    {
        if (BitUtils.GetBit(StatusBuff.enabledMods, Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ.\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5))
        {
            ((QMToggleButton)BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5").GetValue(null)).btnOn.SetActive(false);
            ((QMToggleButton)BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5").GetValue(null)).btnOff.SetActive(true);

            BitUtils.ClearBit(ref StatusBuff.enabledMods, Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ.\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5);
            BlazeEngineAssembly.assemblyUnityPhysics.GetType("UnityEngine.Physics").GetProperty("gravity").GetSetMethod().Invoke(null, new object[] { new Vector3(0, -9.5f, 0) });
            Player.Instance.GetComponent<Collider>().enabled = true;
            return;
        }
        ((QMToggleButton)BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5").GetValue(null)).btnOn.SetActive(true);
        ((QMToggleButton)BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5").GetValue(null)).btnOff.SetActive(false);

        BitUtils.SetBit(ref StatusBuff.enabledMods, Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ.\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5);
        BlazeEngineAssembly.assemblyUnityPhysics.GetType("UnityEngine.Physics").GetProperty("gravity").GetSetMethod().Invoke(null, new object[] { Vector3.zero });
        if (BitUtils.GetBit(StatusBuff.enabledMods, Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ.\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5))
        {
            Player.Instance.GetComponent<Collider>().enabled = false;
        }
    }

    public static void \u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ()
    {
        if (BitUtils.GetBit(StatusBuff.enabledMods, Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ.\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5))
        {
            Player.Instance.GetComponent<Collider>().enabled = false;
            float MultiSpeed = (bool)typeof(Input).GetMethod("GetKey").Invoke(null, new object[] { KeyCode.LeftShift }) ? 2.5F : 1F;
            //                if (ModuleStatus.isModuleSpeed_Enabled)
            //                    MultiSpeed *= JsonUtils.jVault.multiSpeed;
            float calcTimes = MultiSpeed * Time.deltaTime;
            // NoClipMode
            if ((bool)BlazeEngineAssembly.assemblyUnityCore.GetType("UnityEngine.Input").GetMethod("GetKey").Invoke(null, new object[] { KeyCode.E }))
            {
                Player.Instance.transform.position += new Vector3(0, 1f, 0) * ((float)BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5").GetValue(null) * calcTimes);
            }
            else if ((bool)BlazeEngineAssembly.assemblyUnityCore.GetType("UnityEngine.Input").GetMethod("GetKey").Invoke(null, new object[] { KeyCode.Q }))
            {
                Player.Instance.transform.position -= new Vector3(0, 1f, 0) * ((float)BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5").GetValue(null) * calcTimes);
            }

            Vector3 moveControl = Player.Instance.transform.position;
            if (Math.Abs((float)BlazeEngineAssembly.assemblyUnityCore.GetType("UnityEngine.Input").GetMethod("GetAxis").Invoke(null, new object[] { "Vertical" })) > 0f)
            {
                moveControl += calcTimes * (float)BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5").GetValue(null) * Camera.main.transform.forward * (float)BlazeEngineAssembly.assemblyUnityCore.GetType("UnityEngine.Input").GetMethod("GetAxis").Invoke(null, new object[] { "Vertical" });
            }
            if (Math.Abs((float)BlazeEngineAssembly.assemblyUnityCore.GetType("UnityEngine.Input").GetMethod("GetAxis").Invoke(null, new object[] { "Horizontal" })) > 0f)
            {
                moveControl += calcTimes * (float)BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5").GetValue(null) * Camera.main.transform.right * (float)BlazeEngineAssembly.assemblyUnityCore.GetType("UnityEngine.Input").GetMethod("GetAxis").Invoke(null, new object[] { "Horizontal" });
            }
            UserUtils.TeleportTo(moveControl);
        }
        else
        {
            Player.Instance.GetComponent<Collider>().enabled = true;
            if ((bool)BlazeEngineAssembly.assemblyUnityCore.GetType("UnityEngine.Input").GetMethod("GetKey").Invoke(null, new object[] { KeyCode.Q }))
            {
                BlazeEngineAssembly.assemblyUnityPhysics.GetType("UnityEngine.Physics").GetProperty("gravity").GetSetMethod().Invoke(null, new object[] { new Vector3(0, -9.5f, 0) });
                BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5").SetValue(null, 10);
            }
            else if ((bool)BlazeEngineAssembly.assemblyUnityCore.GetType("UnityEngine.Input").GetMethod("GetKey").Invoke(null, new object[] { KeyCode.E }))
            {
                BlazeEngineAssembly.assemblyUnityPhysics.GetType("UnityEngine.Physics").GetProperty("gravity").GetSetMethod().Invoke(null, new object[] { new Vector3(0, 9.5f, 0) });
                BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5").SetValue(null, 10);
            }
            else if ((int)BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5").GetValue(null) >= 0)
            {
                if (VRC.Player.Instance.GetComponent<CharacterController>().velocity[1] != 0.0)
                {
                    BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5").SetValue(null, 10);
                    BlazeEngineAssembly.assemblyUnityPhysics.GetType("UnityEngine.Physics").GetProperty("gravity").GetSetMethod().Invoke(null, new object[] { new Vector3(0, -VRC.Player.Instance.GetComponent<CharacterController>().velocity[1] * 2.0f) });
                }
                else
                {
                    BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5").SetValue(null, ((int)BlazeEngineAssembly.assembly.GetType("Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5").GetField("\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5").GetValue(null)) -1);
                    BlazeEngineAssembly.assemblyUnityPhysics.GetType("UnityEngine.Physics").GetProperty("gravity").GetSetMethod().Invoke(null, new object[] { Vector3.zero });
                }
            }
        }
    }
    public static object \u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5;

    public static object \u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5;
}