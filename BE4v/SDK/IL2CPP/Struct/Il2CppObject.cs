using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2CPP.Struct
{
/*
.cpp    
typedef struct Il2CppObject
{
    union
    {
        Il2CppClass* klass;
        Il2CppVTable* vtable;
    };
    MonitorData* monitor;
}
Il2CppObject;
*/
    unsafe public struct Il2CppObject
    {

        public Il2CppClass* klass;

        public Il2CppVTable* Il2CppVTable;

        public MonitorData* monitor;
    }
}
