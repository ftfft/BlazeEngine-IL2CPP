using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
#if (DEBUG)
using ExitGames.Client.Photon;
#endif
unsafe public class PhotonPlayer : IL2Base
{
    public PhotonPlayer(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    private static IL2Method methodGetPhotonID = null;
    public int ID
    {
        get
        {
            if (methodGetPhotonID == null)
            {
#if (DEBUG)
                methodGetPhotonID = Instance_Class.GetMethods().Where(
                    x =>
                        x.Name.Length > 16 &&
                        x.GetReturnType().Name == "System.Int32" &&
                        x.GetParameters().Length == 0
                ).First(x => *(int*)x.Invoke(ptr).Unbox() > 0);
#else
                methodGetPhotonID = Instance_Class.GetMethods().First(x => x.token == IL2Load.FindOffset("PhotonId")[0]);
#endif
                if (methodGetPhotonID == null)
                    return default;
            }
                
            IL2Object result = methodGetPhotonID.Invoke(ptr);
            if (result == null)
                return default;

            return *(int*)result.Unbox();
        }
    }
#if (DEBUG)
    private static IL2Method methodGetPhotonUserId = null;
    public string UserId
    {
        get
        {
            if (methodGetPhotonUserId == null)
            {
                methodGetPhotonUserId = Instance_Class.GetMethods().First(
                    x =>
                        x.Name != "ToString" &&
                        x.GetReturnType().Name == "System.String" &&
                        x.GetParameters().Length == 0 &&
                        x.Invoke(ptr).UnboxString().Length == 36
                );
                if (methodGetPhotonUserId == null)
                    return string.Empty;
            }
            if (ptr == IntPtr.Zero)
                return string.Empty;

            var result = methodGetPhotonUserId.Invoke(ptr);
            return (result == null) ? string.Empty : result.UnboxString();
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
                    x.GetReturnType().Name == Instance_Class.Name &&
                    x.GetParameters().Length == 0
            );
            if (methodGetNext == null)
                return null;
        }
        if (ptr == IntPtr.Zero)
            return null;

        var result = methodGetNext.Invoke(ptr);
        return (result == null) ? null : result.ptr.MonoCast<PhotonPlayer>();
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
                    x.GetReturnType().Name == Instance_Class.Name &&
                    IL2Import.il2cpp_type_get_name(x.GetParameters()[0].ptr) == Instance_Class.Name
            ).Name;
            methodGetNextFor = Instance_Class.GetMethods().Where(
                x =>
                    x.Name == tempMethod &&
                    x.GetParameters().Length == 1 &&
                    !x.HasFlag(IL2BindingFlags.METHOD_STATIC)
            ).First(
                x =>
                    x.GetReturnType().Name == Instance_Class.Name &&
                    IL2Import.il2cpp_type_get_name(x.GetParameters()[0].ptr) == "System.Int32"
            );
            if (methodGetNextFor == null)
                return null;
        }
        if (ptr == IntPtr.Zero)
            return null;

        var result = methodGetNextFor.Invoke(ptr);
        return (result == null) ? null : result.ptr.MonoCast<PhotonPlayer>();
    }

    private static IL2Field fieldHashtable = null;
    public Hashtable hashtable
    {
        get
        {
            if (fieldHashtable == null)
            {
                fieldHashtable = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "ExitGames.Client.Photon.Hashtable");
                if (fieldHashtable == null)
                    return null;
            }
            if (ptr == IntPtr.Zero)
                return null;

            var result = fieldHashtable.GetValue(ptr);
            return (result == null) ? null : result.ptr.MonoCast<Hashtable>();
        }
        set
        {
            if (fieldHashtable == null)
            {
                fieldHashtable = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "ExitGames.Client.Photon.Hashtable");
                if (fieldHashtable == null)
                    return;
            }
            if (ptr == IntPtr.Zero)
                return;

            fieldHashtable.SetValue(ptr, value.ptr);
        }
    }
#endif

    private static IL2Field fieldIsLocal = null;
    public bool isLocal
    {
        get
        {
            if (fieldIsLocal == null)
            {
                fieldIsLocal = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "System.Boolean" && x.HasFlag(IL2BindingFlags.FIELD_PUBLIC));
                if (fieldIsLocal == null)
                    return default;
            }

            IL2Object result = fieldIsLocal.GetValue(ptr);
            if (result == null)
                return default;

            return *(bool*)result.Unbox();
        }
    }

    private static IL2Method methodToString = null;
    public override string ToString()
    {
        if (methodToString == null)
        {
            methodToString = Instance_Class.GetMethod("ToString");
            if (methodToString == null)
                return default;
        }

        IL2Object result = methodToString.Invoke(ptr);
        if (result == null)
            return default;

        return result.UnboxString();
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(PhotonPlayer))
            return false;
        return ((PhotonPlayer)obj).ptr == ptr;
    }

    public override int GetHashCode() =>
        ptr.GetHashCode();

    public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass(VRC.Player.Instance_Class.GetFields().First(x => x.GetReturnType().Name.Length > 64).GetReturnType().Name);
}