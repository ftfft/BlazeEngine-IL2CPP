using System;
using System.Linq;
using IL2CPP_Core.Objects;
using VRC.Core;

namespace VRC.UI
{
    public class PageUserInfo : VRCUiPage
    {
        public PageUserInfo(IntPtr ptr) : base(ptr) { }

        public PageUserInfo() : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(Instance_Class.Pointer);
            Instance_Class.GetMethod(".ctor").Invoke(Pointer);
        }

        public APIUser user
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(user));
                if (field == null)
                    (field = Instance_Class.GetField(APIUser.Instance_Class)).Name = nameof(user);
                return field.GetValue(Pointer)?.GetValue<APIUser>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(user));
                if (field == null)
                {
                    (field = Instance_Class.GetField(APIUser.Instance_Class)).Name = nameof(user);
                    if (field == null)
                        return;
                }
                field.SetValue(this, value == null ? IntPtr.Zero : value.Pointer);
            }
        }

        public static PageUserInfo Instance
        {
            get => VRCUiManager.GetPage<PageUserInfo>(userInfoScreenPath);
        }

        public static string userInfoScreenPath
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(userInfoScreenPath));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.IsStatic && x.ReturnType.Name == typeof(string).FullName && x.GetValue()?.GetValue<IL2String>().ToString().StartsWith("UserInterface") == true)).Name = nameof(userInfoScreenPath);
                return field.GetValue()?.GetValue<IL2String>().ToString();
            }
        }

        public void InitiateVoteToKick()
        {
            Instance_Class.GetMethod(nameof(InitiateVoteToKick)).Invoke(this);
        }

        public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Assembly-CSharp"].GetClasses().FirstOrDefault(x => x.GetMethod("RequestInvitation") != null);
    }
}
