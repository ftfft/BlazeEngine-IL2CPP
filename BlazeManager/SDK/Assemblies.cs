using System;
using System.Collections.Generic;
using System.Xml.Schema;
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
            for(long l=0L;l<typeof(eAssemblies).GetFields().LongLength-1;l++)
            {
                // Console.WriteLine(LangTransfer.values[cAssemblies.offset + l]);
                b.Add(LangTransfer.values[cAssemblies.offset + l], IL2Cmds.GetAssembly(LangTransfer.values[cAssemblies.offset + l]));
            }
            /*
            foreach (string name in new string[] {
                "Assembly-CSharp", "mscorlib", "System.Core", "VRCCore-Standalone", "VRCSDK2",
                "UnityEngine.CoreModule", "UnityEngine.UnityAnalyticsModule", "UnityEngine.AnimationModule",
                "UnityEngine.PhysicsModule", "UnityEngine.UI", "UnityEngine.IMGUIModule", "Photon3Unity3D",
                "VRCSDKBase", "VRCSDK3", "VRC.Udon", "Facepunch.Steamworks.Win64", "Transmtn", "Unity.TextMeshPro"
            })
            */
        }
    }

    private static Dictionary<string, IL2Assembly> b;

    public static string isObfuscated = "fa";
}