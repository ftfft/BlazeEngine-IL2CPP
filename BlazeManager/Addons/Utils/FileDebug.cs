using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

namespace Addons.Utils
{
    public static class FileDebug
    {
        public static void debugGameObject(string file, GameObject gameObject)
        {
            try
            {
                using (StreamWriter streamWriter = File.CreateText(file))
                {
                    streamWriter.WriteLine(debugGetInfoGameObject(gameObject, 0));
                }
            }
            catch
            {
                Console.WriteLine("Error: 0x00D");
            }
        }

        public static string debugGetInfoGameObject(GameObject gameObject, int Index)
        {
            string result = string.Empty;
            if (gameObject == null)
                return result;

            string IndexChar = string.Empty.AddChar('\t', Index);

            result += IndexChar + "{\n";
            IndexChar = string.Empty.AddChar('\t', ++Index);
            result += IndexChar + "\"Name\":\"" + gameObject.name + "\"\n";
            result += IndexChar + "\"Components\":\n";
            result += IndexChar + "{\n";
            IndexChar = string.Empty.AddChar('\t', ++Index);
            foreach (Component component in gameObject.GetComponents<Component>())
            {
                result += IndexChar + "\"" + component.ToString() + "\"\n";
            }
            IndexChar = string.Empty.AddChar('\t', --Index);
            result += IndexChar + "}\n";
            if (gameObject.transform.childCount > 0)
            {
                result += IndexChar + "\"GameObjects\":\n";
                result += IndexChar + "[\n";
                foreach (Transform transform in gameObject.transform)
                {
                    result += debugGetInfoGameObject(transform.gameObject, Index + 1);
                }
                result += IndexChar + "]\n";
            }
            IndexChar = string.Empty.AddChar('\t', --Index);
            result += IndexChar + "},\n";
            return result;
        }

        public static string AddChar(this string str, char chr, int Index)
        {
            return str += string.Empty.PadRight(Index, chr);
        }
    }
}
