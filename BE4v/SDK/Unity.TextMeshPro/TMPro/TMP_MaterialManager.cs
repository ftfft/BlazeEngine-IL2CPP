using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using BE4v.SDK.CPP2IL;
using UnityEngine;

namespace TMPro
{
    public static class TMP_MaterialManager
    {
        public static Material GetBaseMaterial(Material stencilMaterial)
        {
            return Instance_Class.GetMethod(nameof(GetBaseMaterial)).Invoke(new IntPtr[] { stencilMaterial == null ? IntPtr.Zero : stencilMaterial.ptr })?.GetValue<Material>();
        }


        public static IL2Class Instance_Class = Assembler.list["Unity.TextMeshPro"].GetClass("TMP_MaterialManager", "TMPro");
    }
}
