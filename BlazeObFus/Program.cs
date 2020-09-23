using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.MD;
using dnlib.DotNet.Writer;
using dnlib.IO;
using dnlib.PE;

namespace BlazeObFus
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data = System.IO.File.ReadAllBytes("BlazeManager.dll");
            // See comment above about the assembly resolver
            ModuleContext modCtx = ModuleDef.CreateModuleContext();
            ModuleDefMD module = ModuleDefMD.Load(data, modCtx);

            string[] whitelist_class = new string[] { "<Module>", "BlazeManager", "BlazeLoad" };
            string[] target_opcode_names = new string[] {
                "AntiBlock", "RPC Block", "Global Events", "Invis API",
                "No Portal Join", "No Portal Spawn", "Photon Serilize",
                "Infinity Jump", "Fly Mode", "Fly Enabled", "More Portals",
                "AntiKick", "Fly Enable", "Fly Type", "Hide Pickup"
            };


            foreach (var type in module.Types)
            {
                if (type.Name == "Enumerator")
                    continue;

                // ReName all field to << Empty_Name >>
                foreach (var field in type.Fields)
                {
                    field.Name = random_Name(32);
                }

                // Job to Method's
                foreach (var method in type.Methods)
                {
                    if (method.IsCheckAccessOnOverride || method.IsVirtual)
                        continue;

                    if (method.Name == "GetEnumerator")
                        continue;

                    if (method.Name.StartsWith("op_"))
                        continue;

                    if (method.Name.ToString() == "Start" && type.Name.ToString() == "BlazeManager")
                        continue;

                    // ReName paramName's to China symbol's
                    foreach (var param in method.Parameters)
                    {
                        param.Name = random_Name(32);
                    }

                    if (method.Name.StartsWith(".c") || method.Name == type.Name)
                        continue;

                    if (method.Body != null)
                    {
                        // RePlace Dict["Name"] to Xyeta
                        foreach (var instruct in method.Body.Instructions)
                        {
                            if (instruct.OpCode != OpCodes.Ldstr)
                                continue;

                            if (target_opcode_names.Contains(instruct.Operand))
                            {
                                string temp = (string)instruct.Operand;
                                int num = target_opcode_names.ToList().IndexOf(temp);
                                instruct.Operand = (char)('\u9999' - num * 10) + "";
                                for (int u=0;u<= num + 5;u++)
                                    instruct.Operand += (char)('\u9999' - u * 10) + ".";
                            }
                        }
                    }

                    method.Name = random_Name(32);
                }

                foreach(var property in type.Properties)
                {
                    if (property.Name == "Item")
                        continue;

                    property.Name = random_Name(32);
                }


                if (whitelist_class.Contains(type.Name.ToString()))
                    continue;

                type.Name = random_Name(32);

                type.Namespace = "";
            }
            module.NativeWrite("BlazeSaved.dll");
            Console.WriteLine("End..");
            Console.ReadLine();
        }

        static string random_Name(int count)
        {
            string result = null;
            do
            {
                Random r = new Random();
                result = string.Empty;
                for (int i = 0; i < count; i++)
                {
                    int rand = r.Next(abc.Length - 1);
                    result += abc[rand];
                }
            } while (random.Contains(result) || string.IsNullOrEmpty(result));
            Console.WriteLine(result);
            random.Add(result);
            return result;
        }

        static string[] abc = new string[] {
            "a", "b", "c", "d",
            "e", "f", "g", "h",
            "i", "j", "k", "l",
            "m", "n", "o", "p",
            "q", "r", "s", "t",
            "u", "v", "w", "x",
            "y", "z"
        };

        static List<string> random = new List<string>();
    }
}
