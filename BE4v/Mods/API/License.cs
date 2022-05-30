using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE4v.Mods.API
{
    public static class License
    {
        private static string _license = null;
        public static string GetLicense
        {
            get
            {
                if (_license == null)
                {
                    if (File.Exists("lic.ss"))
                    {
                        _license = File.ReadAllText("lic.ss");
                    }
                    else
                        _license = string.Empty;
                }
                return _license;
            }
        }

        public static void Connect()
        {
            IsLicense = true;
        }

        public static bool IsLicense { get; set; }
        public static string _api_url = "https://client.icefrag.ru/";
    }
}
