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
                x.BaseType?.FullName == UIMenu.Instance_Class.FullName
                && x.GetProperties().Length > 0
            );

            if (Instance_Class == null)
            {
                throw new Exception("[QuickMenu] InstanceClass not found!");
            }
        }

        private static QuickMenu _instance = null;
        public static QuickMenu Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.FindObjectsOfTypeAll<QuickMenu>().FirstOrDefault();
                }
                return _instance;
            }
        }

        public static new IL2Class Instance_Class;
    }
}