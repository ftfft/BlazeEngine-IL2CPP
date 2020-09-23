using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using BlazeTools;

namespace Addons.Mods
{
    public static class CoreMask
    {

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        private static extern bool SetProcessAffinityMask(IntPtr hProcess, IntPtr dwProcessAffinityMask);

        public static void Start()
        {
			long num = 0L;
			int num2 = processorCount - 1;
			int num3 = 2; // 2 : 1 Hyperthread
			int processorCur = 0;
			while (processorCur < 4 && num2 > 0)
			{
				num |= 1L << num2;
				num2 -= num3;
				processorCur++;
			}

			ConSole.Success("CoreMask: You cores " + processorCount + " set to " + processorCur);
			IntPtr handle = Process.GetCurrentProcess().Handle;
			SetProcessAffinityMask(handle, new IntPtr(num));
		}

		public static int processorCur;

		public static int processorCount = Environment.ProcessorCount;
	}
}
