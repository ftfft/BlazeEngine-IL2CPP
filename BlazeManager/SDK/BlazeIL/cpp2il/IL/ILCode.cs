using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDisasm;

namespace BlazeIL.cpp2il.IL
{
    public class ILCode
    {
        public static IntPtr GetPointer(Instruction instruction) => new IntPtr((long)instruction.Offset + instruction.Length + instruction.Operands[0].LvalSDWord);

        public static bool IsJump(Instruction instruction) => Disassembler.Translator.Translate(instruction).StartsWith("jmp ");

        public static bool IsCall(Instruction instruction) => Disassembler.Translator.Translate(instruction).StartsWith("call ");
    }
}
