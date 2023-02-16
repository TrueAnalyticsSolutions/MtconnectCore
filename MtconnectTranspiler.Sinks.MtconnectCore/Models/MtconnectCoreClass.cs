using MtconnectTranspiler.Model;
using MtconnectTranspiler.Sinks.CSharp.Attributes;
using MtconnectTranspiler.Sinks.CSharp.Models;
using MtconnectTranspiler.Xmi.UML;

namespace MtconnectTranspiler.Sinks.MtconnectCore.Models
{
    [ScribanTemplate("MtconnectCore.Class.scriban")]
    public class MtconnectCoreClass : Class
    {
        public MtconnectCoreClass(MTConnectModel model, UmlClass source) : base(model, source) { }
    }
}
