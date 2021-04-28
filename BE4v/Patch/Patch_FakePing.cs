using System;
using System.Linq;
using BE4v.MenuEdit;
using BE4v.Mods;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using IL2Photon.Pun;
using SharpDisasm.Udis86;

namespace BE4v.Patch
{
    public delegate int _NetworkPing();
    
    public static class Patch_FakePing
    {
        public static void Toggle()
        {
            Status.isFakePing = !Status.isFakePing;
            ClickClass_FakePing.OnClick_FakePingToggle_Refresh();
        }

        public static void Start()
        {

            try
            {
                IL2Method method = VRC.UI.DebugDisplayText.Instance_Class.GetMethod("Update");
                var methods = PhotonNetwork.Instance_Class.GetMethods(x => x.ReturnType.Name == typeof(int).FullName && x.GetParameters().Length == 0);

                unsafe
                {
                    var disassembler = method.GetDisassembler(0x512);
                    var instructions = disassembler.Disassemble().Where(x => x.Mnemonic == ud_mnemonic_code.UD_Icall);
                    foreach (var instruction in instructions)
                    {
                        IntPtr addr = new IntPtr((long)instruction.Offset + instruction.Length + instruction.Operands[0].LvalSDWord);
                        if ((method = methods.FirstOrDefault(x => *(IntPtr*)x.ptr == addr)) != null)
                            break;
                    }
                }
                patch = new IL2Patch(method, (_NetworkPing)methodNetworkPing);
                _delegateNetworkPing = patch.CreateDelegate<_NetworkPing>();
                "Fake Ping".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "Fake Ping".RedPrefix(TMessage.BadPatch);
            }
        }

        private static int methodNetworkPing()
        {
            int result = 777;
            if (!Status.isFakePing || VRC.Player.Instance == null)
                result = _delegateNetworkPing.Invoke();
            return result;
        }

        public static IL2Patch patch;

        public static _NetworkPing _delegateNetworkPing;
    }
}
