using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using ExitGames.Client.Photon;

public class NetworkPeer : NetworkingPeer
{
    public NetworkPeer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static NetworkPeer Instance
    {
        get
        {
            if (!fields.ContainsKey(nameof(Instance)))
            {
                fields.Add(nameof(Instance), Instance_Class.GetField(x => x.Instance));
                if (!fields.ContainsKey(nameof(Instance)))
                    return null;
            }

            return fields[nameof(Instance)].GetValue()?.unbox<NetworkPeer>();
        }
    }

    public static Dictionary<string, IL2Property> properties = new Dictionary<string, IL2Property>();
    public static Dictionary<string, IL2Method> methods = new Dictionary<string, IL2Method>();
    public static Dictionary<string, IL2Field> fields = new Dictionary<string, IL2Field>();

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClasses().First(x => x.GetFields().Length == 2 && x.GetField(y => y.Instance) != null && x.GetMethod("OnEvent") != null);
}
