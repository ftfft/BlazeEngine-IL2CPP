using System;
using BlazeIL.il2cpp;

namespace BlazeTools
{
    class IL2SystemClass
    {
        public static IL2Type Int32 = Assemblies.a["mscorlib"].GetClass("Int32", "System");
        public static IL2Type Byte = Assemblies.a["mscorlib"].GetClass("Byte", "System");
        public static IL2Type Boolean = Assemblies.a["mscorlib"].GetClass("Boolean", "System");
        public static IL2Type Single = Assemblies.a["mscorlib"].GetClass("Single", "System");
        public static IL2Type Object = Assemblies.a["mscorlib"].GetClass("Object", "System");
        public static IL2Type String = Assemblies.a["mscorlib"].GetClass("String", "System");
        public static IL2Type Type = Assemblies.a["mscorlib"].GetClass("Type", "System");
        public static IL2Type action_1 = Assemblies.a["mscorlib"].GetClass("Action`1", "System");
        public static IL2Type vector3 = Assemblies.a["UnityEngine.CoreModule"].GetClass("Vector3", "UnityEngine");
        public static IL2Type quaternion = Assemblies.a["UnityEngine.CoreModule"].GetClass("Quaternion", "UnityEngine");
        public static IL2Type spawnOrientation = Assemblies.a["VRCSDKBase"].GetClass("SpawnOrientation", "VRC.SDKBase.VRC_SceneDescriptor");
        // <-- Attr's --> //
        public static IL2Type compilerGenerated = Assemblies.a["mscorlib"].GetClass("CompilerGeneratedAttribute", "System.Runtime.CompilerServices");
    }
}
