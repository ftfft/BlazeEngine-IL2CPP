using System;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using VRC.Core;
using BE4v.SDK.CPP2IL;
using VRC.UI.Core;


namespace VRC.UI.Elements
{
    public class MenuStateController : MonoBehaviour
    {
        public MenuStateController(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public unsafe void PushPage(string pageName, UIContext uiContext = null, bool clearPageStack = false)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(PushPage));
            if (method == null)
            {
                (method = Instance_Class.GetMethods().LastOrDefault(x => x.GetParameters().Length == 3 && x.GetParameters()[0].ReturnType.Name == typeof(string).FullName && x.GetParameters()[2].ReturnType.Name == typeof(bool).FullName)).Name = nameof(PushPage);
                if (method == null)
                    return;
            }

            IntPtr uiContextPtr = IntPtr.Zero;
            if (uiContext != null)
                uiContextPtr = uiContext.ptr;

            method.Invoke(ptr, new IntPtr[] { new IL2String(pageName).ptr, uiContextPtr, new IntPtr(&clearPageStack) });
        }


        public unsafe UIPage[] menuRootPages
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(menuRootPages));
                if (field == null)
                {
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == UIPage.Instance_Class.FullName + "[]")).Name = nameof(menuRootPages);
                    if (field == null)
                        return null;
                }
                return field.GetValue(ptr).UnboxArray<UIPage>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(menuRootPages));
                if (field == null)
                {
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == UIPage.Instance_Class.FullName + "[]")).Name = nameof(menuRootPages);
                    if (field == null)
                        return;
                }
                field.SetValue(ptr, value.Select(x => x.ptr).ArrayToIntPtr(UIPage.Instance_Class));
            }
        }

        public unsafe IL2Dictionary<string, UIPage> _uiPages
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(_uiPages));
                if (field == null)
                {
                    (field = Instance_Class.GetField(x => x.ReturnType.Name.StartsWith("System.Collections.Generic.Dictionary"))).Name = nameof(_uiPages);
                    if (field == null)
                        return null;
                }
                return new IL2Dictionary<string, UIPage>(field.GetValue(ptr).ptr);
            }
            set
            {

                IL2Field field = Instance_Class.GetField(nameof(_uiPages));
                if (field == null)
                {
                    (field = Instance_Class.GetField(x => x.ReturnType.Name.StartsWith("System.Collections.Generic.Dictionary"))).Name = nameof(_uiPages);
                    if (field == null)
                        return;
                }
                field.SetValue(ptr, value.ptr);
            }
        }

        public static new IL2Class Instance_Class = Assembler.list["VRC.UI.Elements"].GetClasses().FirstOrDefault(y => y.FullName == UIMenu.Instance_Class.GetProperties().FirstOrDefault(x => x.GetSetMethod() == null).GetGetMethod().ReturnType.Name);
    }
}