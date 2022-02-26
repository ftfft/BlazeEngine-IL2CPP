using System;
using System.Reflection;

namespace BE4v.SDK.CPP2IL
{
	unsafe public class IL2Dictionary : IL2Base
	{
		public IL2Dictionary(IntPtr ptrNew) : base(ptrNew) =>
			ptr = ptrNew;

		public int Count
		{
			get => Instance_Class.GetProperty(nameof(Count)).GetGetMethod().Invoke(ptr).GetValuе<int>();
		}

		public void Clear()
		{
			Instance_Class.GetMethod(nameof(Clear)).Invoke(ptr, ex: false);
		}

		public static IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("Dictionary`2", "System.Collections.Generic");
	}

	public class IL2DictinaryNew<TKey, TValue> : IL2Dictionary
	{
		public IL2DictinaryNew(IntPtr ptr) : base(ptr) =>
			base.ptr = ptr;

		public IntPtr this[IntPtr key]
		{
			get => Instance_Class.GetProperty("Item").GetGetMethod().Invoke(ptr, new IntPtr[] { key, Instance_Class.GetProperty("Item").GetGetMethod().ptr }).ptr;
			set => Instance_Class.GetProperty("Item").GetSetMethod().Invoke(ptr, new IntPtr[] { key, value, Instance_Class.GetProperty("Item").GetSetMethod().ptr });
		}



		public static new IL2Class Instance_Class = IL2Dictionary.Instance_Class.MakeGenericType(new Type[] { typeof(TKey), typeof(TValue) });
	}

	unsafe public class IL2Dictionary<TKey, TValue> : IL2Dictionary
	{
		public IL2Dictionary(IntPtr ptrNew) : base(ptrNew) =>
			ptr = ptrNew;

		private static IL2Property propertyItem = null;
		public string this[string key]
		{
			get => Instance_Class.GetProperty("Item").GetGetMethod().Invoke(ptr, new IntPtr[] { new IL2String(key).ptr, propertyItem.GetGetMethod().ptr })?.GetValue<string>();
			set => Instance_Class.GetProperty("Item").GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(key).ptr, new IL2String(value).ptr, propertyItem.GetSetMethod().ptr });
		}

		public int FindEntry(IntPtr key)
		{
			return Instance_Class.GetMethod("FindEntry").Invoke(ptr, new IntPtr[] { key }).GetValuе<int>();
		}

		private static IL2Method methodAdd = null;
		public void Add(IntPtr key, IntPtr value)
		{
			if (methodAdd == null)
			{
				methodAdd = Instance_Class.GetMethod("Add");
				if (methodAdd == null)
					return;
			}
			methodAdd.Invoke(ptr, new IntPtr[] { key, value, methodAdd.ptr });
		}

		private static IL2Method methodRemove = null;
		public bool Remove(IntPtr key)
		{
			if (methodRemove == null)
			{
				methodRemove = Instance_Class.GetMethod("Remove");
				if (methodRemove == null)
					return default;
			}
			IL2Object result = methodRemove.Invoke(ptr, new IntPtr[] { key, methodRemove.ptr });
			if (result == null)
				return default;

			return result.GetValuе<bool>();
		}

		public static new IL2Class Instance_Class = IL2Dictionary.Instance_Class.MakeGenericType(new Type[] {typeof(TKey), typeof(TValue) });
	}
}
