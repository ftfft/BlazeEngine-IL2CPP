using System;
using BE4v.SDK.CPP2IL;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
    public class InputField : Selectable
    {
        public InputField(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UI"].GetClass("InputField", "UnityEngine.UI");



		public enum ContentType
		{
			Standard,
			Autocorrected,
			IntegerNumber,
			DecimalNumber,
			Alphanumeric,
			Name,
			EmailAddress,
			Password,
			Pin,
			Custom
		}

		public enum InputType
		{
			Standard,
			AutoCorrect,
			Password
		}

		public enum CharacterValidation
		{
			None,
			Integer,
			Decimal,
			Alphanumeric,
			Name,
			EmailAddress
		}

		public enum LineType
		{
			SingleLine,
			MultiLineSubmit,
			MultiLineNewline
		}

		protected enum EditState
		{
			Continue,
			Finish
		}

	}
}
