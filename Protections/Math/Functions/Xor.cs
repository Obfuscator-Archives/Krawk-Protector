﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Krawk_Protector.Protections.Math.Utils;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Krawk_Protector.Protections.Math.Functions
{
    public class Xor : iFunction
    {
        public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Xor;
        public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
        {
            Generator.Generator generator = new Generator.Generator();
            if (!ArithmeticUtils.CheckArithmetic(instruction)) return null;
            ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), generator.Next(), ArithmeticTypes);
            return (new ArithmeticVT(new Value(arithmeticEmulator.GetValue(), arithmeticEmulator.GetY()), new Token(OpCodes.Xor), ArithmeticTypes));
        }
    }
}
