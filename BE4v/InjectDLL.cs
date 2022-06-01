﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.ExceptionServices;
using VRCLoader.Attributes;
using VRCLoader.Modules;
using BE4v.MenuEdit.Construct;
using BE4v.SDK;

namespace BE4v
{
    [ModuleInfo("BE4V", "4.0", "BlazeBest")]
    public class InjectDLL : VRModule
    {
        [HandleProcessCorruptedStateExceptions]
        public static void Start()
        {
            Main();
        }

        public static void Main()
        {
            SDKLoader.Start();
            Patch.Core.Installer.Start();
            Patch.Patch_AntiCrash.Start();
            Mods.Core.Installer.Start();
            NetworkSanity.NetworkSanity.Start();
            SDKLoader.Finish();
            Mods.Min.ClientConsole.Start();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("--- Color For ESP ---");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[Cyan]   - You blocked or blocked by you");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Yellow] - You Friends");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[Red]    - Others");
            Console.ForegroundColor = ConsoleColor.Gray;
            if (NetworkManager.Instance_Class == null)
            {
                "NetworkManager not found".RedPrefix("ERROR");
            }
            else
            {
                "NetworkManager is found".GreenPrefix("GOOD");
            }
        }
    }
}
