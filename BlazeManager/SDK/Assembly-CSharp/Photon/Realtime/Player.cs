using System;
using System.Collections;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using IL2ExitGames.Client.Photon;

namespace IL2Photon.Realtime
{

    public class Player : IL2Base
    {
        public Player(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        // <!---------- ---------- ---------->
        // <!---------- PROPERTY'S ---------->
        // <!---------- ---------- ---------->
        public Room RoomReference
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(RoomReference));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == Room.Instance_Class.FullName)).Name = nameof(RoomReference);
                return property?.GetGetMethod().Invoke(ptr)?.unbox<Room>();
            }
        }

        public int ActorNumber
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(ActorNumber));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == typeof(int).FullName)).Name = nameof(ActorNumber);
                IL2Object result = property?.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;
                return result.unbox_Unmanaged<int>();
            }
        }

        /*
        public Hashtable CustomProperties
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(CustomProperties));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == Hashtable.Instance_Class.FullName)).Name = nameof(CustomProperties);
                return property?.GetGetMethod().Invoke(ptr)?.unbox<Hashtable>();
            }
            set
            {
                IL2Property property = Instance_Class.GetProperty(nameof(CustomProperties));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == Hashtable.Instance_Class.FullName)).Name = nameof(CustomProperties);
                property?.GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
            }
        }

        */
        // <!---------- ------- ---------->
        // <!---------- FIELD'S ---------->
        // <!---------- ------- ---------->
        public bool IsLocal
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(IsLocal));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.IsPublic && x.ReturnType.Name == typeof(bool).FullName)).Name = nameof(IsLocal);
                IL2Object result = field?.GetValue(ptr);
                if (result == null)
                    return default;
                return result.unbox_Unmanaged<bool>();
            }
        }

        public new IL2String ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.unbox_ToString();
        }

        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses().FirstOrDefault(x => x.GetMethod("Equals") != null && x.GetProperties(y => y.GetGetMethod().ReturnType.Name == typeof(System.Collections.Hashtable).FullName).Length == 1);
    }
}