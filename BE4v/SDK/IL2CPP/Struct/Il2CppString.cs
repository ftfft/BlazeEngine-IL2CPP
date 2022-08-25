using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IL2CPP.Struct
{
/*
typedef struct Il2CppString
{
    Il2CppObject object;
    int32_t length;                             ///< Length of string *excluding* the trailing null (which is included in 'chars').
    Il2CppChar chars[IL2CPP_ZERO_LEN_ARRAY];
} Il2CppString;
*/
    unsafe public struct Il2CppString
    {
        Il2CppObject obj;

        int length;

        char* chars;
    }

}
