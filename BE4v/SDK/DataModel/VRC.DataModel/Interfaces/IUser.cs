﻿using System;
using System.Linq;
using VRC.UI.Elements.Menus;
using IL2CPP_Core.Objects;

namespace VRC.DataModel.Interfaces
{
    public interface IUser
    {
        string UserId { get; set; }
    }

    public static class ClassIUser
    {
        static ClassIUser()
        {
            IL2Field[] fields = SelectedUserMenuQM.Instance_Class.GetFields(y => y.ReturnType != null);
            IL2Class[] classes = IL2CPP.AssemblyList["DataModel"].GetClasses().Where(x => x.IsInterface).ToArray();
            foreach(var field in fields)
            {
                Instance_Class = classes.FirstOrDefault(x => x.FullName == field.ReturnType.Name);
                if (Instance_Class != null)
                    break;
            }
        }

        public static IL2Property UserId
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(UserId));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == typeof(string).FullName)).Name = nameof(UserId);
                return property;
            }
        }

        public static IL2Class Instance_Class;
    }
}