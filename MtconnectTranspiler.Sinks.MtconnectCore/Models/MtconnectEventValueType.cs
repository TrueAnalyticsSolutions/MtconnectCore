using MtconnectTranspiler.Sinks.ScribanTemplates;
using MtconnectTranspiler.Xmi;
using MtconnectTranspiler.Xmi.UML;

namespace MtconnectTranspiler.Sinks.MtconnectCore.Models
{
    [ScribanTemplate("MtconnectCore.ValueType.scriban")]
    public class MtconnectEventValueType : MtconnectValueType
    {
        public override string Category { get; set; } = "Event";

        public override string ValueType { get; set; } = "string";

        public MtconnectEventValueType(XmiDocument model, UmlEnumeration source) : base("Event", "string", model, source) { }

        public MtconnectEventValueType(XmiDocument model, UmlClass source) : base("Event", "string", model, source) { }
    }
}
