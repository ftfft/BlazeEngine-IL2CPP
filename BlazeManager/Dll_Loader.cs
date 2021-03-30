using System;
using System.Collections.Generic;

public static class Dll_Loader
{
    public static void Start()
    {
        LangTransfer.LoadData();
    }
    
    public static void Finish()
    {
        bool isFirst;
        if (success_Patch.Count > 0)
        {
            isFirst = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"[+] Success Patch [{success_Patch.Count}] ");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var name in success_Patch)
            {
                Console.Write((isFirst ? "," : "") + " " + name);
                isFirst = true;
            }
            Console.WriteLine();
        }
        if (failed_Patch.Count > 0)
        {
            isFirst = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"[-] Failed Patch [{failed_Patch.Count}] ");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var name in failed_Patch)
            {
                Console.Write((isFirst ? "," : "") + " " + name);
                isFirst = true;
            }
            Console.WriteLine();
        }
        Console.ForegroundColor = ConsoleColor.Gray;
        success_Patch = null;
        failed_Patch = null;
    }

    public static List<string> success_Patch = new List<string>();
    public static List<string> failed_Patch = new List<string>();
}
