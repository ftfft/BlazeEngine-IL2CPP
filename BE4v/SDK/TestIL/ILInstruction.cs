using System;
using System.Reflection;
using System.Reflection.Emit;

namespace IL
{
    public struct ILInstruction
    {
        public ILInstruction(OpCode opCode, byte[] ilCode, int index)
        {
            OpCode = opCode;
            HasArgument = (opCode.OperandType != OperandType.InlineNone);
            HasSingleByteArgument = OpCodes.TakesSingleByteArgument(opCode);
            int size = opCode.Size;
            int num;
            if (HasArgument)
            {
                num = (HasSingleByteArgument ? 1 : 4);
            }
            else
            {
                num = 0;
            }
            Length = size + num;
            if (!HasArgument)
            {
                Argument = null;
                return;
            }
            if (!HasSingleByteArgument)
            {
                Argument = BitConverter.ToInt32(ilCode, index + opCode.Size);
            }
            else
            {
                Argument = ilCode[index + opCode.Size];
            }
            if (OpCode == OpCodes.Ldstr)
            {
                // Argument = manifest.ResolveString((int)Argument);
                return;
            }
            if (OpCode == OpCodes.Call || OpCode == OpCodes.Callvirt)
            {
                // Argument = manifest.ResolveMethod((int)Argument);
                return;
            }
            if (OpCode == OpCodes.Box)
            {
                // Argument = manifest.ResolveType((int)Argument);
                return;
            }
            if (OpCode == OpCodes.Ldfld || OpCode == OpCodes.Ldflda)
            {
                // Argument = manifest.ResolveField((int)Argument);
                return;
            }
        }

        public T GetArgument<T>()
        {
            return (T)Argument;
        }

        public override string ToString()
        {
            string arg = string.Empty;
            if (HasArgument)
            {
                if (Argument is int || Argument is byte)
                {
                    arg = string.Format(" 0x{0:X}", Argument);
                }
                else
                {
                    arg = (!(Argument is string)) ? (" " + Argument.ToString()) : (" \"" + Argument.ToString() + '"');
                }
            }
            return string.Format("{0}{1}", OpCode.Name, arg);
        }

        public readonly OpCode OpCode;

        public readonly object Argument;

        public readonly bool HasArgument;

        public readonly bool HasSingleByteArgument;

        public readonly int Length;
    }
}
