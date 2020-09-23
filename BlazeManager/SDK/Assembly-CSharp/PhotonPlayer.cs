using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using ExitGames.Client.Photon;

public class PhotonPlayer : IL2Base
{
    public PhotonPlayer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    private static IL2Property propertyID  = null;
    public int ID
    {
        get
        {
            if (propertyID == null)
            {
                propertyID = Instance_Class.GetProperties().First(x => x.GetGetMethod()?.ReturnType.Name == "System.Int32");
                if (propertyID == null)
                    return default;
            }
            return propertyID.GetGetMethod().Invoke(ptr).Unbox<int>();
        }
    }

    public static PhotonPlayer Find(int ID)
    {
        /*if (PhotonNetwork.networkingPeer != null)
        {
            return PhotonNetwork.networkingPeer.GetPlayerWithId(ID);
        }*/
        return null;
    }

    public PhotonPlayer Get(int id)
    {
        return PhotonPlayer.Find(id);
    }

    private static IL2Method methodGetNext = null;
    public PhotonPlayer GetNext()
    {
        if (methodGetNext == null)
        {
            methodGetNext = Instance_Class.GetMethods().FirstOrDefault(
                x =>
                    x.ReturnType.Name == Instance_Class.Name &&
                    x.GetParameters().Length == 0
            );
            if (methodGetNext == null)
                return null;
        }

        IL2Object result = methodGetNext.Invoke(ptr);
        if (result == null)
            return null;
        
        return result.Unbox<PhotonPlayer>();
    }

    private static IL2Method methodGetNextFor = null;
    public PhotonPlayer GetNextFor(PhotonPlayer currentPlayer) => GetNextFor(currentPlayer.ID);
    public PhotonPlayer GetNextFor(int currentPlayer)
    {
        if (methodGetNextFor == null)
        {
            string tempMethod = Instance_Class.GetMethods().Where(
                x =>
                    x.GetParameters().Length == 1 &&
                    !x.HasFlag(IL2BindingFlags.METHOD_STATIC)
            ).First(
                x =>
                    x.ReturnType.Name == Instance_Class.Name &&
                    x.GetParameters()[0].Name == Instance_Class.Name
            ).Name;
            methodGetNextFor = Instance_Class.GetMethods().Where(
                x =>
                    x.Name == tempMethod &&
                    x.GetParameters().Length == 1 &&
                    !x.HasFlag(IL2BindingFlags.METHOD_STATIC)
            ).First(
                x =>
                    x.ReturnType.Name == Instance_Class.Name &&
                    x.GetParameters()[0].Name == "System.Int32"
            );
            if (methodGetNextFor == null)
                return null;
        }

        IL2Object result = methodGetNextFor.Invoke(ptr);
        if (result == null)
            return null;

        return result.Unbox<PhotonPlayer>();
    }

    private static IL2Field fieldHashtable = null;
    public Hashtable hashtable
    {
        get
        {
            if (fieldHashtable == null)
            {
                fieldHashtable = Instance_Class.GetFields().First(x => x.ReturnType.Name == Hashtable.Instance_Class.FullName);
                if (fieldHashtable == null)
                    return null;
            }

            return fieldHashtable.GetValue(ptr)?.Unbox<Hashtable>();
        }
        set
        {
            if (fieldHashtable == null)
            {
                fieldHashtable = Instance_Class.GetFields().First(x => x.ReturnType.Name == Hashtable.Instance_Class.FullName);
                if (fieldHashtable == null)
                    return;
            }

            fieldHashtable.SetValue(ptr, value.ptr);
        }
    }

    private static IL2Field fieldIsLocal = null;
    public bool isLocal
    {
        get
        {
            if (fieldIsLocal == null)
            {
                fieldIsLocal = Instance_Class.GetFields(IL2BindingFlags.FIELD_PUBLIC).First(x => x.ReturnType.Name == "System.Boolean");
                if (fieldIsLocal == null)
                    return default;
            }

            return fieldIsLocal.GetValue(ptr).Unbox<bool>();
        }
    }

    private static IL2Method methodToString = null;
    public override string ToString()
    {
        if (!IL2Get.Method("ToString", Instance_Class, ref methodToString))
            return default;

        return methodToString.Invoke(ptr)?.Unbox<string>();
    }

    public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass(VRC.Player.Instance_Class.GetFields().First(x => x.ReturnType.Name.Length > 64).ReturnType.Name);
}