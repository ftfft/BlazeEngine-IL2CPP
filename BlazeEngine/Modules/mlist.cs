using System;
using System.Linq;
using System.Reflection;

public enum Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ
{
    none = 0,
    // NoClip
    \u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5,
    // Fly
    \u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5,
    // Jump
    \u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5,
    // SH
    \u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5,
    // JH
    \u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5,
    // BHop
    \u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5Ǆ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5ǅ\u01C5\u01C5\u01C5\u01C5\u01C5\u01C5,
}

public class BlazeEngineAssembly
{
    public static readonly Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == "BlazeEngine");
    public static readonly Assembly assemblyUnityCore = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == "UnityEngine.CoreModule");
    public static readonly Assembly assemblyUnityPhysics = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == "UnityEngine.PhysicsModule");
}
