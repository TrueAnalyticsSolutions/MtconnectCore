using MtconnectTranspiler.Model;
using MtconnectTranspiler.Sinks.CSharp.Attributes;
using MtconnectTranspiler.Xmi.UML;

namespace MtconnectTranspiler.Sinks.MtconnectCore.Models
{
    [ScribanTemplate("MtconnectCore.Enum.scriban")]
    public class MtconnectCoreEnum : CSharp.Models.Enum
    {
        public MtconnectCoreEnum(MTConnectModel model, UmlEnumeration source) : base(model, source) { }

        public MtconnectCoreEnum(MTConnectModel model, UmlPackage source) : base(model, source) { }

        public MtconnectCoreEnum(MTConnectModel model, MTConnectDeviceInformationModel source) : base(model, source) { }
    }
}
