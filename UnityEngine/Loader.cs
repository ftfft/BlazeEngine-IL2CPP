using System;
using System.Collections.Generic;
using BlazeIL;
using BlazeIL.il2cpp;

public class Loader
{
    public static void Loading()
    {
        Assemblies.a = new Dictionary<string, IL2Assembly>();
        foreach (string name in new string[] {
            "SharpDisasm", "MonoEngine", "UnityEngine.CoreModule", "UnityEngine.PhysicsModule",
            "UnityEngine.UI", "UnityEngine.UnityAnalyticsModule", "VRCCore-Standalone", "VRCSDK2",
            "Assembly-CSharp"
        })
            BlazeSDK.Main.LoadModule(Environment.CurrentDirectory + "\\BlazeEngine\\MonoLib\\" + name + ".dll", string.Empty, string.Empty, true, true);

        InvocationDelegate method = IL2Tools.GetMethodInvoker(Activator.CreateInstance("MonoEngine", "MonoEngine._Shell").Unwrap().GetType().GetMethod("StartModule"));
        method(null, null);
    }
}
