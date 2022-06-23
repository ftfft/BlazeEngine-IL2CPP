using System;
using System.Linq;
using IL2CPP_Core.Objects;
using UnityEngine;

namespace VRC.UI.Elements
{
    public class QuickMenu : UIMenu
    {
        public QuickMenu(IntPtr ptr) : base(ptr) { }

        unsafe static QuickMenu()
        {
            Instance_Class = IL2CPP.AssemblyList["VRC.UI.Elements"].GetClasses()
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