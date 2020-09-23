using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL;
using BlazeIL.il2cpp;

namespace VRC.Core
{
    public class ApiContainer : IL2Base
    {
        public ApiContainer(IntPtr newPtr) : base(newPtr) =>
            ptr = newPtr;


        public static IL2Method constructApiContaner = null;
        public ApiContainer() : base(IntPtr.Zero)
        {

            if (constructApiContaner == null)
            {
                constructApiContaner = Instance_Class.GetMethod(".ctor");
                if (constructApiContaner == null)
                    return;
            }

            ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
            constructApiContaner.Invoke(ptr);
        }



        public static IL2Type Instance_Class = Assemblies.a["VRCCore-Standalone"].GetClass("ApiContainer", "VRC.Core");
    }
}
