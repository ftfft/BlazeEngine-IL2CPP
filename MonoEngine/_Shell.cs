using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Collections.Generic;
using BlazeIL;
using BlazeIL.il2cpp;

namespace MonoEngine
{
    unsafe public class _Shell
    {
        public static void StartModule()
        {
            IL2Assembly Assembly = IL2Cmds.GetAssembly("Assembly-CSharp");
            if (Assembly == null)
                return;

            // Patch [1] - ClientOnThink
            try
            {
                pClientUpdate = Assembly.GetClass("DebugLogGui").GetMethod("Update");
                if (pClientUpdate == null)
                    throw new Exception();

                pClientUpdateOrig = *(IntPtr*)pClientUpdate.ptr.ToPointer();
                *(IntPtr*)pClientUpdate.ptr.ToPointer() = mClientUpdate;
                IL2Tools.Print(ConsoleColor.Yellow, "[MonoEmu]", "Is success patch #1");
            }
            catch
            {
                IL2Tools.Print(ConsoleColor.Yellow, "[MonoEmu]", "Not working patch #1");
            }

            // Patch [2] - PlayerOnThink
            try
            {
                pControlUpdate = Assembly.GetClass("LocomotionInputController").GetMethod("Update");
                if (pControlUpdate == null)
                    throw new Exception();

                pControlUpdateOrig = *(IntPtr*)pControlUpdate.ptr.ToPointer();
                *(IntPtr*)pControlUpdate.ptr.ToPointer() = mControlUpdate;
                IL2Tools.Print(ConsoleColor.Yellow, "[MonoEmu]", "Is success patch #2");
            }
            catch
            {
                IL2Tools.Print(ConsoleColor.Yellow, "[MonoEmu]", "Not working patch #2");
            }

            // Patch [3] - FixFastQuit
            try
            {
                pQuitApplication = Assembly.GetClass("VRCApplication").GetMethod("OnApplicationQuit");
                if (pQuitApplication == null)
                    throw new Exception();

                *(IntPtr*)pQuitApplication.ptr.ToPointer() = mQuitApplication;
                IL2Tools.Print(ConsoleColor.Yellow, "[MonoEmu]", "Is success patch #3 [FixFastQuit]");
            }
            catch
            {
                IL2Tools.Print(ConsoleColor.Yellow, "[MonoEmu]", "Not working patch #3 [FixFastQuit]");
            }


            // DebugLogGui
        }

        private static List<MonoHandler> handlerList = new List<MonoHandler>();
        // Patch void (IntPtr instance, IntPtr xxx1, IntPtr instance2, IntPtr xxx, IntPtr args)
        public static void shellUpdate(IntPtr instance)
        {
            handlerList.Where(x => x.Name.Split('_')[0] == "update" && x.Pre == true).ToList().ForEach(x => {
                x.methodInfo(null, null);
            });
            *(IntPtr*)pClientUpdate.ptr.ToPointer() = pClientUpdateOrig;
            pClientUpdate.Invoke(instance);
            *(IntPtr*)pClientUpdate.ptr.ToPointer() = mClientUpdate;
            handlerList.Where(x => x.Name.Split('_')[0] == "update" && x.Pre == false).ToList().ForEach(x => {
                x.methodInfo(null, null);
            });
        }

        public static void shellPlayerUpdate(IntPtr instance)
        {
            handlerList.Where(x => x.Name.Split('_')[0] == "playerupdate" && x.Pre == true).ToList().ForEach(x => {
                x.methodInfo(null, null);
            });
            *(IntPtr*)pControlUpdate.ptr.ToPointer() = pControlUpdateOrig;
            pControlUpdate.Invoke(instance);
            *(IntPtr*)pControlUpdate.ptr.ToPointer() = mControlUpdate;
            handlerList.Where(x => x.Name.Split('_')[0] == "playerupdate" && x.Pre == false).ToList().ForEach(x => {
                 x.methodInfo(null, null);
            });
        }

        public static void OnApplicationQuit()
        {
            try
            {
                Type tQuit = Activator.CreateInstance("BlazeManager", "BlazeLoad").Unwrap().GetType();
                if (tQuit == null)
                    throw new Exception();
                MethodInfo mQuit = tQuit.GetMethod("VaultSave");
                if (mQuit == null)
                    throw new Exception();
                mQuit.Invoke(null, null);
            }
            finally
            {
                Process.GetCurrentProcess().Kill();
            }
        }

        public static MonoHandler RegisterHandler(string function, MethodInfo targetMethod, bool bPre = false)
        {
            MonoHandler hMono = new MonoHandler(function, targetMethod, bPre);
            handlerList.Add(hMono);
            return hMono;
        }

        private static readonly Type type = typeof(_Shell); 

        private static IL2Method pClientUpdate = null;
        private static IntPtr pClientUpdateOrig;
        private static readonly IntPtr mClientUpdate = type.GetMethod("shellUpdate").MethodHandle.GetFunctionPointer();

        private static IL2Method pControlUpdate = null;
        private static IntPtr pControlUpdateOrig;
        private static readonly IntPtr mControlUpdate = type.GetMethod("shellPlayerUpdate").MethodHandle.GetFunctionPointer();

        private static IL2Method pQuitApplication = null;
        private static readonly IntPtr mQuitApplication = type.GetMethod("OnApplicationQuit").MethodHandle.GetFunctionPointer();
    }
}