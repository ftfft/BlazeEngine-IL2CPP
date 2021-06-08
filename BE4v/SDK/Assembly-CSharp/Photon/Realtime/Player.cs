using System;
using System.Collections;
using System.Linq;
using BE4v.SDK.CPP2IL;
// using IL2ExitGames.Client.Photon;

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
                    (property = Instance_Class.GetProperty(Room.Instance_Class)).Name = nameof(RoomReference);
                return property?.GetGetMethod().Invoke(ptr)?.GetValue<Room>();
            }
        }

        public int ActorNumber
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(ActorNumber));
                if (property == null)
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == typeof(int).FullName)).Name = nameof(ActorNumber);
                return property?.GetGetMethod().Invoke(ptr)?.GetValuå<int>() ?? default(int);
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
                return field?.GetValue(ptr)?.GetValuå<bool>() ?? default(bool);
            }
        }

        public override string ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.GetValue<string>();
        }

        public static IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("Equals") != null && x.GetProperties(y => y.GetGetMethod().ReturnType.Name == typeof(System.Collections.Hashtable).FullName).Length == 1);
    }
}