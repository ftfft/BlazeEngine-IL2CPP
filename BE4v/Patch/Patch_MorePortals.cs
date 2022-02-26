using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace BE4v.Patch
{
    public delegate void _RoomManagerBase_ObjectInstantiator();
    public delegate void _dInstantiateObject(IntPtr instance, IntPtr CCMLFLPBHLG, Vector3 JMHCNJHDLEK, Quaternion EKMDDALCGDN, IntPtr AMFEMAIJHCP, int KMBNFJDDHEN, IntPtr NAAEAFNHFOI);
    public delegate void _dSendOnSpawn(IntPtr instance, int KMBNFJDDHEN, IntPtr OCCPLFDMNNM);
    public delegate bool _ObjectInstantiator_ObjectInstantiator(IntPtr instance, IntPtr ptr1, IntPtr ptr2);
    public static class Patch_MorePortals
    {
        public static void Start()
        {
            IL2Method[] methods;
            try
            {
                methods = RoomManager.Instance_Class.GetMethods().Where(x => x.GetParameters().Length == 1).Where(x => x.GetParameters()[0].ReturnType.Name == PortalInternal.Instance_Class.FullName).ToArray();
                if (methods == null)
                    throw new Exception();

                foreach (IL2Method method in methods)
                {
                    var patch2 = new IL2Patch(method, (_RoomManagerBase_ObjectInstantiator)RoomManagerBase_ObjectInstantiator);
                    patch.Add(patch2);
                    patch2.Enabled = false;
                }

                "More Portals [1]".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "More Portals [1]".RedPrefix(TMessage.BadPatch);
            }
            try
            {
                methods = ObjectInstantiator.Instance_Class.GetMethods(x => x.GetParameters().Length == 2).Where(x => x.GetParameters()[0].ReturnType.Name == VRC.Player.Instance_Class.FullName && x.GetParameters()[1].ReturnType.Name.StartsWith(ObjectInstantiator.Instance_Class.FullName + ".")).ToArray();
                if (methods == null)
                    throw new Exception();

                foreach (IL2Method method in methods)
                {
                    var patch2 = new IL2Patch(method, (_ObjectInstantiator_ObjectInstantiator)ObjectInstantiator_ObjectInstantiator);
                    patch.Add(patch2);
                    patch2.Enabled = false;
                }

                "More Portals [2]".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "More Portals [2]".RedPrefix(TMessage.BadPatch);
            }
            try
            {
                var method = ObjectInstantiator.Instance_Class.GetMethod("_InstantiateObject");
                if (method == null)
                    throw new Exception();

                var patch2 = new IL2Patch(method, (_dInstantiateObject)_InstantiateObject);
                patch.Add(patch2);
                patch2.Enabled = false;
                "More Portals [3]".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "More Portals [3]".RedPrefix(TMessage.BadPatch);
            }
            try
            {
                var method = ObjectInstantiator.Instance_Class.GetMethod("_SendOnSpawn");
                if (method == null)
                    throw new Exception();

                var patch2 = new IL2Patch(method, (_dSendOnSpawn)_SendOnSpawn);
                patch.Add(patch2);
                patch2.Enabled = false;

                "More Portals [4]".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "More Portals [4]".RedPrefix(TMessage.BadPatch);
            }
        }


        public static void RoomManagerBase_ObjectInstantiator()
        {

        }

        public static bool ObjectInstantiator_ObjectInstantiator(IntPtr instance, IntPtr ptr1, IntPtr ptr2)
        {
            return false;
        }
        
        public static void _InstantiateObject(IntPtr instance, IntPtr CCMLFLPBHLG, Vector3 JMHCNJHDLEK, Quaternion EKMDDALCGDN, IntPtr AMFEMAIJHCP, int KMBNFJDDHEN, IntPtr NAAEAFNHFOI)
        {
        }

        public static void _SendOnSpawn(IntPtr instance, int KMBNFJDDHEN, IntPtr OCCPLFDMNNM)
        {
        }

        public static List<IL2Patch> patch = new List<IL2Patch>();
        
    }
}
