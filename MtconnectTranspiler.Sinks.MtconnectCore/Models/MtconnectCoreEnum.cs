using MtconnectTranspiler.Model;
using MtconnectTranspiler.Sinks.CSharp.Attributes;
using MtconnectTranspiler.Xmi;
using MtconnectTranspiler.Xmi.UML;

namespace MtconnectTranspiler.Sinks.MtconnectCore.Models
{
    [ScribanTemplate("MtconnectCore.Enum.scriban")]
    public class MtconnectCoreEnum : CSharp.Models.Enum
    {
        // NOTE: Only used for CATEGORY types that have subTypes.
        public Dictionary<string, string> SubTypes { get; set; } = new Dictionary<string, string>();

        public MtconnectCoreEnum(MTConnectModel model, XmiElement source, string name) : base(model, source, name) { }

        public MtconnectCoreEnum(MTConnectModel model, UmlEnumeration source) : base(model, source) { }

        public MtconnectCoreEnum(MTConnectModel model, UmlPackage source) : base(model, source) { }

        public MtconnectCoreEnum(MTConnectModel model, MTConnectDeviceInformationModel source) : base(model, source) { }
    }
}
