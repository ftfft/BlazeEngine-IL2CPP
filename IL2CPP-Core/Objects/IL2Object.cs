using System;
using System.Linq;

namespace IL2CPP_Core.Objects
{
    unsafe public class IL2Object<T> : IL2Object where T : unmanaged
    {
        public IL2Object(IntPtr ptr) : base(ptr) => Pointer = ptr;
        public IL2Object(T value, IL2Class type) : base(IntPtr.Zero)
        {
            Pointer = Import.Object.il2cpp_object_new(type.Pointer);
            if (Pointer == IntPtr.Zero)
                throw new NullReferenceException();

            *(T*)(Pointer + 0x10) = value;
        }
    }

    public class IL2Object
    {
        public IL2Object(IntPtr ptr) => Pointer = ptr;
        unsafe public IL2Object CreateNewObject<T>(T value, IL2Class type) where T : unmanaged
        {
            IntPtr result = Import.Object.il2cpp_object_new(type.Pointer);
            if (result == IntPtr.Zero)
                return null;
            *(T*)(result + 0x10) = value;
            return new IL2Object(result);
        }


        /// <summary>
        ///     NOT UNMANAGED
        /// </summary>
        /// <returns></returns>
        unsafe public T1 GetValue<T1>()
        {
            if (typeof(T1) == typeof(string))
                return (T1)(object)(new IL2String(Pointer).ToString());
            return (T1)typeof(T1).GetConstructors().First(x => x.GetParameters().Length == 1).Invoke(new object[] { Pointer });
        }

        /// <summary>
        ///     IS UNMANAGED
        /// </summary>
        /// <returns></returns>
        unsafe public T1 GetValuе<T1>() where T1 : unmanaged
        {
            return *(T1*)(Pointer + 0x10).ToPointer();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return this == null;
            if (obj is IL2Object b) return b.Pointer == Pointer;
            return false;
        }
        public override int GetHashCode() => Pointer.GetHashCode();
        public static bool operator !=(IL2Object x, IL2Object y) => !(x == y);
        public static bool operator ==(IL2Object x, IL2Object y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return x.Pointer == y.Pointer;
        }
        ~IL2Object()
        {
            // For Clear RAM Pointer
            GC.SuppressFinalize(this);
        }

        public bool Static
        {
            get => handleStatic > 0;
            set
            {
                if (value)
                {
                    if (handleStatic > 0)
                    {
                        handleStatic = Import.Handler.il2cpp_gchandle_new(Pointer, true);
                    }
                }
                else
                {
                    if (handleStatic < 1)
                    {
                        Import.Handler.il2cpp_gchandle_free(handleStatic);
                        handleStatic = 0;
                    }
                }
            }
        }

        public IntPtr Pointer;

        private uint handleStatic = 0;
    }
}
