using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE4v.Mods
{
    public static class Mod_AutoClearRAM
    {
        public static void Clear()
        {
            GC.Collect();
            VRC.Core.GC.Collect(compacting: true);
            VRC.Core.GC.MaybeCollect(compacting: true);
            "Clear RAM is success!".RedPrefix("ClearRAM");
        }

        public static bool CheckTime()
        {
            var time = UnixTimeNow();
            if (timestamp > time) return false;
            timestamp = time + 300;
            return true;
        }
        public static long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }

        private static long timestamp = 0;
    }
}
