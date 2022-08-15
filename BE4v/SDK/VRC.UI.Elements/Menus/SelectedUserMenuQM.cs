using System;
using System.Linq;
using VRC.DataModel.Interfaces;
using IL2CPP_Core.Objects;

namespace VRC.UI.Elements.Menus
{
    public class SelectedUserMenuQM : UIPage
	{
        public SelectedUserMenuQM(IntPtr ptr) : base(ptr) { }

        public User _iUser
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(_iUser));
                if (field == null)
                    (field = Instance_Class.GetField(ClassIUser.Instance_Class)).Name = nameof(_iUser);
                return field.GetValue(this)?.GetValue<User>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(_iUser));
                if (field == null)
                    (field = Instance_Class.GetField(ClassIUser.Instance_Class)).Name = nameof(_iUser);
                field.SetValue(this, value == null ? IntPtr.Zero : value.Pointer);
            }
        }

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["VRC.UI.Elements"].GetClasses().FirstOrDefault(x => x.GetField("_editPlaylistInputField") != null);
    }
}