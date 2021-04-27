using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using BE4v.SDK.CPP2IL;
using UnityEngine;

namespace TMPro
{
    public abstract class TMP_Asset : ScriptableObject
    {
        public TMP_Asset(IntPtr ptr) : base(ptr) => base.ptr = ptr;


        public static new IL2Class Instance_Class = Assembler.list["Unity.TextMeshPro"].GetClass("TMP_Asset", "TMPro");
    }
}
