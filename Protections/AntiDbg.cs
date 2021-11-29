﻿
using Krawk_Protector.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dnlib;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Krawk_Protector.Utils;
using Krawk.Helpers;

namespace Krawk_Protector.Protections
{
    class AntiDbg : IProtector
    {
        string IProtector.Name { get { return "Anti Debug"; } }
        MethodDef decryptmethod;
        public void InjectPhase(Context krawk) 
        {
            ModuleDefMD typeModule = ModuleDefMD.Load(typeof(Krawk.Runtime.AntiDebug).Module);
            TypeDef typeDef = typeModule.ResolveTypeDef(MDToken.ToRID(typeof(Krawk.Runtime.AntiDebug).MetadataToken));
            IEnumerable<IDnlibDef> members = InjectHelper.Inject(typeDef, krawk.GlobalType, krawk.ManifestModule);

            decryptmethod = (MethodDef)members.Single(method => method.Name == "StartAntiDebug");
        }
        public void ProtectionPhase(Context krawk) 
        {
            int cctorbdycount = krawk.cctor.Body.Instructions.Count;
            krawk.cctor.Body.Instructions.Insert(cctorbdycount - 1, Instruction.Create(OpCodes.Call, decryptmethod));
            
        }
    }
}
