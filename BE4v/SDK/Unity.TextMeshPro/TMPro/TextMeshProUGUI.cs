using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using BE4v.SDK.CPP2IL;

namespace TMPro
{
    public class TextMeshProUGUI : TMP_Text
    {
        public TextMeshProUGUI(IntPtr ptr) : base(ptr) => base.ptr = ptr;


        public static new IL2Class Instance_Class = Assembler.list["Unity.TextMeshPro"].GetClass("TextMeshProUGUI", "TMPro");
    }
}
