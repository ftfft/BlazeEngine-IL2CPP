using System;
using System.Runtime.InteropServices;

namespace BE4v.SDK.CPP2IL
{
	public class IL2Array<T> : IL2Base where T : unmanaged
	{
		public IL2Array(int length, IL2Class typeobject = null) : base(IntPtr.Zero)
		{
			if (typeobject == null)
				typeobject = Assembler.list["mscorlib"].GetClass("Object", "System");

			ptr = Import.Object.il2cpp_array_new(typeobject.ptr, (ulong)length);
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
				// return *(T*)((IntPtr)((long*)ptr + 4) + index * sizeof(T));
				return *(T*)((byte*)IntPtr.Add(ptr, 4 * IntPtr.Size).ToPointer() + index * sizeof(T));
			}
			set
			{
				if (index < 0 || index >= Length)
				{
					throw new ArgumentOutOfRangeException();
				}
				// *(IntPtr*)((IntPtr)((long*)ptr + 4) + index * sizeof(T)) = new IntPtr(&value);
				*(T*)((byte*)IntPtr.Add(ptr, 4 * IntPtr.Size).ToPointer() + index * sizeof(T)) = value;
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

		public T[] ToArray()
        {
			int len = Length;
			T[] result = new T[Length];
			for(int i = 0;i< len; i++)
            {
				result[i] = this[i];
			}
			return result;
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

		unsafe public byte[] ToBytesArray()
        {
			int size = Length;
			byte[] result = new byte[size];
			if (size > 0)
				Marshal.Copy((IntPtr)((long*)ptr + 4), result, 0, size);
			return result;
		}
	}
}
