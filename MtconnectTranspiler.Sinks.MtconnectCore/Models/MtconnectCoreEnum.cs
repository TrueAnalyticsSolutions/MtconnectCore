using MtconnectTranspiler.Sinks.ScribanTemplates;
using MtconnectTranspiler.Xmi;
using MtconnectTranspiler.Xmi.UML;

namespace MtconnectTranspiler.Sinks.MtconnectCore.Models
{
    [ScribanTemplate("MtconnectCore.Enum.scriban")]
    public class MtconnectCoreEnum : CSharp.Models.Enum
    {
        // NOTE: Only used for CATEGORY types that have subTypes.
        public Dictionary<string, string> SubTypes { get; set; } = new Dictionary<string, string>();

        // NOTE: Only used for CATEGORY types that have value enums.
        public Dictionary<string, string> ValueTypes { get; set; } = new Dictionary<string, string>();

        public MtconnectCoreEnum(XmiDocument model, XmiElement source, string name) : base(model, source, name) { }

        public MtconnectCoreEnum(XmiDocument model, UmlEnumeration source) : base(model, source) { }

        public MtconnectCoreEnum(XmiDocument model, UmlPackage source) : base(model, source) { }
    }
}
