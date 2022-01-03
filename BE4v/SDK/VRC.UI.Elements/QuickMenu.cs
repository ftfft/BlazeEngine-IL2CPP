using System;
using System.Linq;
using UnityEngine;
using VRC.Core;
using BE4v.SDK.CPP2IL;
using UnityEngine.UI;
using System.CodeDom;
using System.Diagnostics.PerformanceData;

namespace VRC.UI.Elements
{
    public class QuickMenu : UIMenu
    {
        public QuickMenu(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        unsafe static QuickMenu()
        {
            Instance_Class = Assembler.list["VRC.UI.Elements"].GetClasses()
            .FirstOrDefault(x =>
                x.GetFields(y => y.ReturnType.Name == "UnityEngine.Vector3").Length > 9 &&
                x.GetFields(y => y.ReturnType.Name == GameObject.Instance_Class.FullName).Length > 6
            );

            if (Instance_Class == null)
            {
                throw new Exception("[QuickMenu] InstanceClass not found!");
            }
        }

        public static QuickMenu Instance
        {
            get
            {
                return FindObjectOfType<QuickMenu>();
            }
        }

        public static new IL2Class Instance_Class;
    }
}