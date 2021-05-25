using BE4v.SDK.CPP2IL;
using System;
using System.Data.SqlTypes;

namespace VRC.Core
{
    public class ApiPlayerModeration : ApiModel
    {
        public ApiPlayerModeration(IntPtr ptr) : base(ptr) => base.ptr = ptr;


		public enum ModerationType
		{
			None,
			Block,
			Mute,
			Unmute,
			HideAvatar,
			ShowAvatar
		}

		public class ModerationType_Class : IL2Base
		{
			public ModerationType_Class(IntPtr ptr) : base(ptr) => base.ptr = ptr;

			public static IL2Class Instance_Class = ApiPlayerModeration.Instance_Class.GetNestedType("ModerationType", ApiPlayerModeration.Instance_Class.FullName);
		}

		public static new IL2Class Instance_Class = Assembler.list["VRCCore-Standalone"].GetClass("ApiPlayerModeration", "VRC.Core");
    }
}