using System;
using System.Collections.Generic;
using System.Linq;
using BlazeIL.il2cpp;
using BlazeIL;


namespace VRC
{
    public class PlayerManager
    {
        private static IL2Method methodGetAllPlayers;
        public static Player[] GetAllPlayers()
        {
            if(methodGetAllPlayers == null)
            {
                methodGetAllPlayers = Instance_Class.GetMethods().First(x => x.GetReturnType().Name == "VRC.Player[]" && x.HasFlag(IL2BindingFlags.METHOD_STATIC));
                if (methodGetAllPlayers == null)
                    return null;
            }

            List<Player> result = new List<Player>();
            IL2Object obj = methodGetAllPlayers.Invoke();
            if (obj == null)
                return null;

            foreach (IntPtr ptr in obj.UnboxArray())
                result.Add(ptr.MonoCast<Player>());
                
            return result.ToArray();
        }
        public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PlayerManager", "VRC");
    }
}