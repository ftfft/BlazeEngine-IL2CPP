using System;

public static class ClientDebug
{
    public static bool IsEnableDebug() => System.IO.File.Exists("enable_test");
}

public static class SDKUtils
{
    public static void RedPrefix(this string message, string prefix)
    {
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(prefix);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("] " + message);
    }
    
    public static void GreenPrefix(this string message, string prefix)
    {
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(prefix);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("] " + message);
    }

    public static void WriteMessage(this string message, string prefix)
    {
        Console.WriteLine($"[{prefix}] {message}");
    }

    public static void WriteMessage(this string message)
    {
        Console.WriteLine(message);
    }

}