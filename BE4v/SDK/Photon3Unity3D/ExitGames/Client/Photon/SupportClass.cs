using System;
using BE4v.SDK.CPP2IL;

namespace IL2ExitGames.Client.Photon
{
    public class SupportClass : IL2Base
    {
        public SupportClass(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static string DictionaryToString(IL2Dictionary dictionary)
        {
            return Instance_Class.GetMethod(nameof(DictionaryToString), x => x.GetParameters().Length == 1).Invoke(new IntPtr[] { dictionary == null ? IntPtr.Zero : dictionary.ptr })?.GetValue<string>();
        }


        public static IL2Class Instance_Class = Assembler.list["Photon"].GetClass("SupportClass", "ExitGames.Client.Photon");
    }
}