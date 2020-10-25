using System;
using System.Linq;
using System.Collections.Generic;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;

namespace VRC
{
    public class PlayerManager : MonoBehaviour
    {
        public PlayerManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        private static IL2Method methodGetAllPlayers;
        public static Player[] GetAllPlayers()
        {
            if(methodGetAllPlayers == null)
            {
                methodGetAllPlayers = Instance_Class.GetMethods().First(x => x.ReturnType.Name == Player.Instance_Class.FullName + "[]" && x.HasFlag(IL2BindingFlags.METHOD_STATIC));
                if (methodGetAllPlayers == null)
                    return null;
            }

            return methodGetAllPlayers.Invoke().UnboxArray<Player>();
        }

        private static IL2Method methodGetPlayer;
        public static Player GetPlayer(int photonId)
        {
            if (methodGetPlayer == null)
            {
                methodGetPlayer = Instance_Class.GetMethods().First(x => x.ReturnType.Name == Player.Instance_Class.FullName && x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == "System.Int32");
                if (methodGetPlayer == null)
                    return null;
            }

            return methodGetPlayer.Invoke(new IntPtr[] { photonId.MonoCast() })?.Unbox<Player>();
        }




        private static IL2Property propertyAllPlayers;
        public Player[] AllPlayers
        {
            get
            {
                if (propertyAllPlayers == null)
                {
                    propertyAllPlayers = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == Player.Instance_Class.FullName + "[]");
                    if (propertyAllPlayers == null)
                        return null;
                }
                return propertyAllPlayers.GetGetMethod().Invoke(ptr)?.UnboxArray<Player>();
            }
        }

        private static IL2Field fieldInstance;
        public static PlayerManager Instance
        {
            get
            {
                if (fieldInstance == null)
                {
                    fieldInstance = Instance_Class.GetFields().First(x => x.ReturnType.Name == Instance_Class.FullName);
                    if (fieldInstance == null)
                        return null;
                }
                return fieldInstance.GetValue()?.Unbox<PlayerManager>();
            }
        }

        public static Dictionary<string, IL2Property> properties = new Dictionary<string, IL2Property>();
        public static Dictionary<string, IL2Method> methods = new Dictionary<string, IL2Method>();
        public static Dictionary<string, IL2Field> fields = new Dictionary<string, IL2Field>();

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PlayerManager", "VRC");
    }
}