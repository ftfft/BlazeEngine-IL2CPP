using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace ExitGames.Client.Photon
{
    public class EventData : IL2Base
    {
        public EventData(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        private static IL2Property propertySender = null;
        public int Sender
        {
            get
            {
                if (propertySender == null)
                {
                    propertySender = Instance_Class.GetProperty("Sender");
                    if (propertySender == null)
                        return default;
                }

                return propertySender.GetGetMethod().Invoke(ptr).MonoCast<int>();
            }
        }
        
        private static IL2Property propertyCustomData = null;
        public IL2Object CustomData
        {
            get
            {
                if (propertyCustomData == null)
                {
                    propertyCustomData = Instance_Class.GetProperty("CustomData");
                    if (propertyCustomData == null)
                        return null;
                }

                return propertyCustomData.GetGetMethod().Invoke(ptr);
            }
        }
        
        private static IL2Field fieldCode = null;
        public byte Code
        {
            get
            {
                if (fieldCode == null)
                {
                    fieldCode = Instance_Class.GetField("Code");
                    if (fieldCode == null)
                        return default;
                }

                return fieldCode.GetValue(ptr).MonoCast<byte>();
            }
        }

        static IL2Method methodToString = null;
        public override string ToString()
        {
            if (!IL2Get.Method("ToString", Instance_Class, ref methodToString))
                return default;

            return methodToString.Invoke(ptr)?.Unbox<string>();
        }

        public static IL2Type Instance_Class = Assemblies.a["Photon3Unity3D"].GetClass("EventData", "ExitGames.Client.Photon");
    }
}