﻿using MtconnectTranspiler.Sinks.CSharp.Models;
using MtconnectTranspiler.Sinks.ScribanTemplates;
using MtconnectTranspiler.Xmi;
using MtconnectTranspiler.Xmi.UML;

namespace MtconnectTranspiler.Sinks.MtconnectCore.Models
{
    [ScribanTemplate("MtconnectCore.Class.scriban")]
    public class MtconnectCoreClass : Class
    {
        public MtconnectCoreClass(XmiDocument model, UmlClass source) : base(model, source) { }
    }
}
