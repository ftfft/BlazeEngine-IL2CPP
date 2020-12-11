using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;
using BlazeIL.il2cpp;

namespace TMPro
{
    public class TextMeshProUGUI : TMP_Text
    {
        public TextMeshProUGUI(IntPtr ptr) : base(ptr) => base.ptr = ptr;


        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.unitytextmeshpro]].GetClass("TextMeshProUGUI", "TMPro");
    }
}
