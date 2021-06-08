using System;
using BE4v.MenuEdit;
using BE4v.Mods;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace BE4v.Patch
{
    public delegate void _RoomManagerBase_OnConnectedToMaster(IntPtr instance);
    public static class Patch_Event_OnMasterConnected
    {
        public static void Start()
        {
            try
            {
                IL2Method method = RoomManager.Instance_Class.GetMethod("OnConnectedToMaster");

                if (method == null)
                    throw new Exception();

                patch = new IL2Patch(method, (_RoomManagerBase_OnConnectedToMaster)RoomManagerBase_OnConnectedToMaster);
                _delegateRoomManagerBase_OnConnectedToMaster = patch.CreateDelegate<_RoomManagerBase_OnConnectedToMaster>();
                "[Event] OnConnectedToMaster (Patch)".GreenPrefix(TMessage.SuccessPatch);
            }
            catch
            {
                "[Event] OnConnectedToMaster (Patch)".RedPrefix(TMessage.BadPatch);
            }
        }

        private static void RoomManagerBase_OnConnectedToMaster(IntPtr instance)
        {
            _delegateRoomManagerBase_OnConnectedToMaster.Invoke(instance);
            Patch_GlobalDynamicBones.currentPlayer = null;
            Patch_GlobalDynamicBones.timeToUpdate = 10f;
            Status.isSerilize = false;
            Mod_PortableMirror.OnDestroy();
        }

        public static IL2Patch patch;

        public static _RoomManagerBase_OnConnectedToMaster _delegateRoomManagerBase_OnConnectedToMaster;
    }
}
