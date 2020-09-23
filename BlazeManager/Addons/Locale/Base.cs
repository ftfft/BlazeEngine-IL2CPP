using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Addons.Locale
{
    public class LangSource
    {
        public void Change(Lang lang, string word)
        {
            if (lang == Lang.en)
            {
                en = word;
                return;
            }
            ru = word;
        }
        public string Get(Lang lang)
        {
            if (lang == Lang.en)
                return en;

            return ru;
        }
        public string en;
        public string ru;
    }

    public static class Base
    {
        public static Dictionary<string, LangSource> pairs = new Dictionary<string, LangSource>();

        public static Lang lang = Lang.en;
    }
}
