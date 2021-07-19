using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

namespace VRC.SDKBase.Validation.Performance
{
    public static class AvatarPerformance
    {


        public static IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod(PerformanceScannerSet.Instance_Class) != null);
    }
}
