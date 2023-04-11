using CSharpModels = MtconnectTranspiler.Sinks.CSharp.Models;
using MtconnectTranspiler.Sinks.CSharp.Attributes;
using MtconnectTranspiler.Xmi;
using MtconnectTranspiler.Xmi.UML;

namespace MtconnectTranspiler.Sinks.MtconnectCore.Models
{
    [ScribanTemplate("MtconnectCore.ValueType.scriban")]
    public class MtconnectValueType : CSharpModels.Enum
    {
        public virtual string Category { get; set; }

        public virtual string ValueType { get; set; }

        public virtual string ExpectedUnits { get; set; }

        public List<string> SubTypes { get; set; } = new List<string>();

        public MtconnectValueType(string category, string valueType, XmiDocument model, UmlEnumeration source) : base(model, source)
        {
            Category = category;
            ValueType = valueType;
        }

        public MtconnectValueType(string category, string valueType, XmiDocument model, XmiElement source) : base(model, source, source.Name)
        {
            Category = category;
            ValueType = valueType;
        }
    }
}
