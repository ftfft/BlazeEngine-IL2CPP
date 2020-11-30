using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace BlazeIL.il2delegate
{
    public delegate TT method<TT>();
    public delegate TT method<TT, T1>(T1 arg1);
    public delegate TT method<TT, T1, T2>(T1 arg1, T2 arg2);
    public delegate TT method<TT, T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);
    public delegate TT method<TT, T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    public delegate TT method<TT, T1, T2, T3, T4, T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    public delegate TT method<TT, T1, T2, T3, T4, T5, T6>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
}
