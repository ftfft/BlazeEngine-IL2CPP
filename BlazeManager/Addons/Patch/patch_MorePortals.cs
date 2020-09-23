using System;
using System.Linq;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeTools;

namespace Addons.Patch
{
    public delegate void _RoomManagerBase_ObjectInstantiator();
    public delegate bool _ObjectInstantiator_ObjectInstantiator(IntPtr instance, IntPtr ptr1, IntPtr ptr2);
    public static class patch_MorePortals
    {
        public static void Start()
        {
            IL2Method[] methods = null;
            try
            {
                methods = RoomManagerBase.Instance_Class.GetMethods().Where(x => x.GetParameters().Length == 1).Where(x => x.GetParameters()[0].ReturnType.Name == PortalInternal.Instance_Class.FullName).ToArray();
                if (methods == null)
                    throw new Exception();

                foreach (IL2Method method in methods)
                    IL2Ch.Patch(method, (_RoomManagerBase_ObjectInstantiator)RoomManagerBase_ObjectInstantiator);
                ConSole.Success("Patch: More Portals [1]");
            }
            catch
            {
                ConSole.Error("Patch: More Portals [1]");
            }
            try
            {
                methods = ObjectInstantiator.Instance_Class.GetMethods(x => x.GetParameters().Length == 2).Where(x => x.GetParameters()[0].ReturnType.Name == VRC.Player.Instance_Class.FullName && x.GetParameters()[1].ReturnType.Name.StartsWith(ObjectInstantiator.Instance_Class.FullName + ".")).ToArray();
                if (methods == null)
                    throw new Exception();

                foreach (IL2Method method in methods)
                    IL2Ch.Patch(method, (_ObjectInstantiator_ObjectInstantiator)ObjectInstantiator_ObjectInstantiator);
                ConSole.Success("Patch: More Portals [2]");
            }
            catch
            {
                ConSole.Error("Patch: More Portals [2]");
            }
        }

        public static void RoomManagerBase_ObjectInstantiator()
        {

        }

        public static bool ObjectInstantiator_ObjectInstantiator(IntPtr instance, IntPtr ptr1, IntPtr ptr2)
        {
            return false;
            /*
            if (isFastCreate)
                return false;

            IL2Object @object = pFastCreate.InvokeOriginal(instance, new IntPtr[] { ptr1, ptr2 });
            if (@object == null)
                return false;

            return @object.pUnbox<bool>();
            */
        }

        public static bool isFastCreate = false;
        private static IL2Patch pFastCreate = null;
    }
}
