using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Addons.Locale
{
    public static class Locale_Data
    {
        public static void Start()
        {
            LangSource source = new LangSource();
            source.en = "";
            Base.pairs.Add("", source);
        }
    }
}
