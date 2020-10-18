using System;
using BlazeIL.il2cpp;

namespace BlazeIL.il2reflection
{
    internal class IL2Get
    {
        public static bool Constructor(Func<IL2Constructor, bool> func, IL2Type il2type, ref IL2Constructor il2constructor)
        {
            if (il2constructor != null)
                return true;

            return (il2constructor = il2type.GetConstructor(func)) != null;
        }

        public static bool Constructor(IL2Type il2type, ref IL2Constructor il2constructor)
        {
            if (il2constructor != null)
                return true;

            return (il2constructor = il2type.GetConstructors()[0]) != null;
        }

        public static bool Property(string name, IL2Type il2type, ref IL2Property il2property, bool isName = true)
        {
            if (il2property != null)
                return true;

            if (isName)
            {
                il2property = il2type.GetProperty(name);
                goto END;
            }

            foreach (var property in il2type.GetProperties())
            {
                if (property.GetGetMethod().ReturnType.Name == name)
                {
                    il2property = property;
                    goto END;
                }
            }

            END:
            return il2property != null;
        }

        public static bool Method(string name, IL2Type il2type, ref IL2Method il2method, bool isName = true)
        {
            if (il2method != null)
                return true;

            if (isName)
            {
                il2method = il2type.GetMethod(name);
                goto END;
            }

            foreach (var method in il2type.GetMethods())
            {
                if (method.ReturnType.Name == name)
                {
                    il2method = method;
                    goto END;
                }
            }
            END:
            return il2method != null;
        }
        public static bool Field(string name, IL2Type il2type, ref IL2Field il2field, bool isName = true)
        {
            if (il2field != null)
                return true;

            if (isName)
            {
                il2field = il2type.GetField(name);
                goto END;
            }

            foreach (var field in il2type.GetFields())
            {
                if (field.ReturnType.Name == name)
                {
                    il2field = field;
                    goto END;
                }
            }

            END:
            return il2field != null;
        }
    }
}
