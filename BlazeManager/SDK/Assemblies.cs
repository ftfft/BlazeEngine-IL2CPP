using System.Collections.Generic;
using BlazeIL;
using BlazeIL.il2cpp;

public class Assemblies
{
    public static Dictionary<string, IL2Assembly> a
    {
        get => b;
        set
        {
            b = value;
            foreach (string name in new string[] {
                "Assembly-CSharp", "mscorlib", "System.Core", "VRCCore-Standalone", "VRCSDK2",
                "UnityEngine.CoreModule", "UnityEngine.UnityAnalyticsModule", "UnityEngine.AnimationModule",
                "UnityEngine.PhysicsModule", "UnityEngine.UI", "UnityEngine.IMGUIModule", "Photon3Unity3D",
                "VRCSDKBase", "VRCSDK3", "VRC.Udon", "Facepunch.Steamworks.Win64", "Transmtn"
            })
                b.Add(name, IL2Cmds.GetAssembly(name));
        }
    }

    private static Dictionary<string, IL2Assembly> b;
}