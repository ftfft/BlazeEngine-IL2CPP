using System;
using System.Reflection;
using BlazeIL;

namespace MonoEngine
{
    public class MonoHandler
    {
        private static int iNumber = 0;

        public string Name { get; private set; }
        public bool Pre { get; private set; }
        public InvocationDelegate methodInfo { get; private set; }
        internal MonoHandler(string function, MethodInfo method, bool pre)
        {
            iNumber++;
            Pre = pre;
            methodInfo = IL2Tools.GetMethodInvoker(method);
            Name = function.ToLower() + "_" + iNumber;
            // This do work...
        }
    }
}
