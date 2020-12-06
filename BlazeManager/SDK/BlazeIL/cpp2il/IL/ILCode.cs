using System;
using System.Collections.Generic;
using SharpDisasm;
using SharpDisasm.Udis86;
using BlazeIL.il2cpp;

namespace BlazeIL.cpp2il.IL
{
    public class ILCode
    {
        public static IntPtr GetPointer(Instruction instruction) => new IntPtr((long)instruction.Offset + instruction.Length + instruction.Operands[0].LvalSDWord);

        public static bool IsJump(Instruction instruction) => instruction.Mnemonic == ud_mnemonic_code.UD_Ijmp;

        public static bool IsCall(Instruction instruction) => instruction.Mnemonic == ud_mnemonic_code.UD_Icall;
        
        public static bool IsString(Instruction instruction) => instruction.Mnemonic == ud_mnemonic_code.UD_Istr;

        public unsafe static ILObject[] CastToILObject(IEnumerable<Instruction> instructions)
        {
            List<ILObject> objects = new List<ILObject>();
            foreach (var instruction in instructions)
            {
                if (instruction.Mnemonic == ud_mnemonic_code.UD_Iint3)
                    continue;

                if (IsCall(instruction) || IsJump(instruction))
                {
                    objects.Add(new ILObject(GetPointer(instruction), ILType.method));
                }
            }

            return objects.ToArray();
        }
    }

    public class ILObject : IL2Base
    {
        public ILType Type;
        public ILObject(IntPtr ptr, ILType type) : base(ptr)
        {
            base.ptr = ptr;
            Type = type;
        }
    }

    public enum ILType
    {
        none,
        method,
        field
    }
}
