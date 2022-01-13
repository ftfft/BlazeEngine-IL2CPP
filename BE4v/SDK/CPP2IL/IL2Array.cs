using System;

namespace BE4v.SDK.CPP2IL
{
	public class IL2Array<T> : IL2Base where T : unmanaged
	{
		public IL2Array(int length, IL2Class typeobject = null) : base(IntPtr.Zero)
		{
			if (typeobject == null)
				typeobject = Assembler.list["mscorlib"].GetClass("Object", "System");

			ptr = Import.Object.il2cpp_array_new(typeobject.ptr, length);
		}

		public IL2Array(IntPtr ptr) : base(ptr)
		{
			this.ptr = ptr;
		}

		unsafe public T this[int index]
		{
			get
			{
				if (index < 0 || index >= Length)
				{
					throw new ArgumentOutOfRangeException();
				}
				return *(T*)((IntPtr)((long*)ptr + 4) + index * sizeof(T));
			}
			set
			{
				if (index < 0 || index >= Length)
				{
					throw new ArgumentOutOfRangeException();
				}
				*(IntPtr*)((IntPtr)((long*)ptr + 4) + index * sizeof(T)) = new IntPtr(&value);
			}
		}

		public int Length
		{
			get
			{
				int result;
				if (typeof(T) == typeof(byte))
				{
					result = (int)Import.Object.il2cpp_array_get_byte_length(ptr);
				}
				else
				{
					result = Import.Object.il2cpp_array_length(ptr);
				}
				return result;
			}
		}
	}
}
