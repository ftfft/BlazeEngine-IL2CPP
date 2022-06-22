using System;
using System.Linq;
using System.Collections.Generic;
using IL2CPP_Core.Objects;
using UnityEngine;
using BE4v.SDK;
using BE4v.Patch.Core;

namespace BE4v.Patch.List
{
    public static class MorePortals
    {
        /*
        public class ModePortals_RoomManagerBase : IPatch
        {
            public delegate void _RoomManager_ObjectInstantiator(IntPtr arg1);

            public void Start()
            {
                IL2Method[] methods = RoomManager.Instance_Class.GetMethods().Where(x => x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == PortalInternal.Instance_Class.FullName).ToArray();
                if (methods != null && methods.Length > 0)
                {
                    foreach (IL2Method method in methods)
                    {
                        var patch2 = new IL2Patch(method, (_RoomManager_ObjectInstantiator)RoomManager_ObjectInstantiator);
                        patch.Add(patch2);
                        patch2.Enabled = false;
                    }
                }
                else
                    throw new NullReferenceException();
            }

            public static void RoomManager_ObjectInstantiator(IntPtr arg1)
            {

            }
        }
        */
        public class ModePortals_ObjectInstantiator : IPatch
        {
            public delegate bool _ObjectInstantiator_ObjectInstantiator(IntPtr instance, IntPtr ptr1, IntPtr ptr2);

            public void Start()
            {
                IL2Method[] methods = ObjectInstantiator.Instance_Class.GetMethods(x => x.GetParameters().Length == 2).Where(x => x.GetParameters()[0].ReturnType.Name == VRC.Player.Instance_Class.FullName && x.GetParameters()[1].ReturnType.Name.StartsWith(ObjectInstantiator.Instance_Class.FullName + ".")).ToArray();
                if (methods.Length == 0)
                    throw new NullReferenceException();

                foreach (IL2Method method in methods)
                {
                    var patch2 = new IL2Patch(method, (_ObjectInstantiator_ObjectInstantiator)ObjectInstantiator_ObjectInstantiator);
                    patch.Add(patch2);
                    patch2.Enabled = false;
                }
            }

            public static bool ObjectInstantiator_ObjectInstantiator(IntPtr instance, IntPtr ptr1, IntPtr ptr2)
            {
                return false;
            }
        }
        
        public class ModePortals_InstantiateObject : IPatch
        {
            public delegate void _dInstantiateObject(IntPtr instance, IntPtr CCMLFLPBHLG, Vector3 JMHCNJHDLEK, Quaternion EKMDDALCGDN, IntPtr AMFEMAIJHCP, int KMBNFJDDHEN, IntPtr NAAEAFNHFOI);

            public void Start()
            {
                IL2Method method = ObjectInstantiator.Instance_Class.GetMethod("_InstantiateObject");
                if (method == null)
                    throw new NullReferenceException();
                
                var patch2 = new IL2Patch(method, (_dInstantiateObject)_InstantiateObject);
                patch.Add(patch2);
                patch2.Enabled = false;
            }

            public static void _InstantiateObject(IntPtr instance, IntPtr CCMLFLPBHLG, Vector3 JMHCNJHDLEK, Quaternion EKMDDALCGDN, IntPtr AMFEMAIJHCP, int KMBNFJDDHEN, IntPtr NAAEAFNHFOI)
            {
            }
        }
        
        public class ModePortals_SendOnSpawn : IPatch
        {
            public delegate void _dSendOnSpawn(IntPtr instance, int KMBNFJDDHEN, IntPtr OCCPLFDMNNM);

            public void Start()
            {
                IL2Method method = ObjectInstantiator.Instance_Class.GetMethod("_SendOnSpawn");
                if (method == null)
                    throw new NullReferenceException();

                var patch2 = new IL2Patch(method, (_dSendOnSpawn)_SendOnSpawn);
                patch.Add(patch2);
                patch2.Enabled = false;
            }

            public static void _SendOnSpawn(IntPtr instance, int KMBNFJDDHEN, IntPtr OCCPLFDMNNM)
            {
            }
        }

        public static List<IL2Patch> patch = new List<IL2Patch>();
    }
}
