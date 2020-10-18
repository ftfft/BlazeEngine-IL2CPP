using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL.il2cpp;

namespace Addons.Locale
{
    public class LangSource
    {
        public void Change(Lang lang, string word)
        {
            if (lang == Lang.en)
            {
                en = new IL2String(word);
                return;
            }
            ru = new IL2String(word);
        }
        public string Get(Lang lang)
        {
            if (lang == Lang.en)
                return en.ToString();

            return ru.ToString();
        }
        public IL2String en;
        public IL2String ru;
    }

    public static class Base
    {
        public static Dictionary<string, LangSource> pairs = new Dictionary<string, LangSource>();

        public static Lang lang = Lang.en;
    }
}
