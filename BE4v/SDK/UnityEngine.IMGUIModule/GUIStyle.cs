using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	public sealed class GUIStyle : IL2Base
	{
		public GUIStyle(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public GUIStyle() : base(IntPtr.Zero)
		{
			ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
			Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 0).Invoke(ptr);
		}

		unsafe public IntPtr GetStyleStatePtr(int idx)
		{
			return Instance_Class.GetMethod(nameof(GetStyleStatePtr)).Invoke(ptr, new IntPtr[] { new IntPtr(&idx) }).GetValuе<IntPtr>();
		}

		public GUIStyle box
		{
			get => Instance_Class.GetProperty(nameof(box)).GetGetMethod().Invoke(ptr)?.GetValue<GUIStyle>();
			set => Instance_Class.GetProperty(nameof(box)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
		}

		public GUIStyleState normal
		{
			get
			{
				if (m_Normal == null)
				{
					m_Normal = GUIStyleState.GetGUIStyleState(this, GetStyleStatePtr(0));
				}
				return m_Normal;
			}
			set
			{
				// AssignStyleState(0, value.m_Ptr);
			}
		}

		public GUIStyleState hover
		{
			get
			{
				if (m_Hover == null)
				{
					m_Hover = GUIStyleState.GetGUIStyleState(this, GetStyleStatePtr(1));
				}
				return m_Hover;
			}
			set
			{
				// AssignStyleState(1, value.m_Ptr);
			}
		}

		unsafe public int fontSize
		{
			set => Instance_Class.GetProperty(nameof(fontSize)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public FontStyle fontStyle
		{
			set => Instance_Class.GetProperty(nameof(fontStyle)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public TextAnchor alignment
		{
			set { } // Instance_Class.GetProperty(nameof(alignment)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		public GUIStyleState m_Normal
		{
			get => Instance_Class.GetField(nameof(m_Normal)).GetValue(ptr)?.GetValue<GUIStyleState>();
			set => Instance_Class.GetField(nameof(m_Normal)).SetValue(ptr, value == null ? IntPtr.Zero : value.ptr);
		}

		public GUIStyleState m_Hover
		{
			get => Instance_Class.GetField(nameof(m_Hover)).GetValue(ptr)?.GetValue<GUIStyleState>();
			set => Instance_Class.GetField(nameof(m_Hover)).SetValue(ptr, value == null ? IntPtr.Zero : value.ptr);
		}
		
		private bool isStatic = false;
        private IntPtr handleStatic = IntPtr.Zero;
        public bool Static
        {
            get => isStatic;
            set
            {
                isStatic = value;
                if (value)
                {
                    if (handleStatic == IntPtr.Zero)
                    {
                        handleStatic = Import.Handler.il2cpp_gchandle_new(ptr, true);
                    }
                }
                else
                {
                    if (handleStatic != IntPtr.Zero)
                    {
                        Import.Handler.il2cpp_gchandle_free(handleStatic);
                        handleStatic = IntPtr.Zero;
                    }
                }
            }
        }

		public static IL2Class Instance_Class = Assembler.list["UnityEngine.IMGUI"].GetClass("GUIStyle", "UnityEngine");
	}
}
