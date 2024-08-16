using MtconnectTranspiler.CodeGenerators.ScribanTemplates;
using MtconnectTranspiler.Sinks.CSharp.Contracts.Interfaces;

namespace MtconnectTranspiler.Sinks.MtconnectCore.Models
{
    [ScribanTemplate("MtconnectCore.Class.scriban")]
    public class MtconnectCoreClass : IClass
    {
        private readonly IClass _class;

        public string ReferenceId => _class.ReferenceId;

        public string Name => _class.Name;

        public string AccessModifier => _class.AccessModifier;

        public string Modifier => _class.Modifier;

        public string NormativeVersion => _class.NormativeVersion;

        public string DeprecatedVersion => _class.DeprecatedVersion;

        public System.Type Generalization => _class.Generalization;

        public IPropertyList Properties => _class.Properties;

        public string Summary => _class.Summary;

        public MtconnectCoreClass(IClass source)
        {
            _class = source;
        }
    }
}
