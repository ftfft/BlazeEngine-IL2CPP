using System;
using System.Collections;
using System.Reflection;
using System.Reflection.Emit;

namespace IL
{
    public static class ILParser
    {
        static ILParser()
        {
            FieldInfo[] fields = typeof(OpCodes).GetFields();
            for (int i = 0; i < fields.Length; i++)
            {
                OpCode opCode = (OpCode)fields[i].GetValue(null);
                if (opCode.Size != 1)
                {
                    MultiOpCodes[opCode.Value & 255] = opCode;
                }
                else
                {
                    OpCodes[opCode.Value] = opCode;
                }
            }
        }

        public static ILInstruction[] Parse(this IL2MethodInfo method)
        {
            return Parse(IL2MethodBase.GetMethodBody(method.MethodHandle.value).GetILAsByteArray());
        }

        public static ILInstruction[] Parse(this IL2MethodBase methodBase)
        {
            return Parse(methodBase.GetMethodBody().GetILAsByteArray());
        }

        public static ILInstruction[] Parse(this IL2MethodBody methodBody)
        {
            return Parse(methodBody.GetILAsByteArray());
        }

        private static ILInstruction[] Parse(byte[] ilCode)
        {
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < ilCode.Length; i++)
            {
                ILInstruction ilinstruction = new ILInstruction((ilCode[i] == 254) ? MultiOpCodes[ilCode[i + 1]] : OpCodes[ilCode[i]], ilCode, i);
                arrayList.Add(ilinstruction);
                i += ilinstruction.Length - 1;
            }
            return (ILInstruction[])arrayList.ToArray(typeof(ILInstruction));
        }

        private static readonly OpCode[] OpCodes = new OpCode[256];

        private static readonly OpCode[] MultiOpCodes = new OpCode[31];
    }
}
