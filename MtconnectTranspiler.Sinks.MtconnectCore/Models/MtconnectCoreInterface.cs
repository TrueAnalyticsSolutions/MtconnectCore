using CaseExtensions;
using MtconnectTranspiler.CodeGenerators.ScribanTemplates;
using MtconnectTranspiler.Sinks.CSharp.Contracts.Interfaces;

namespace MtconnectTranspiler.Sinks.MtconnectCore.Models
{
    [ScribanTemplate("MtconnectCore.Interface.scriban")]
    public class MtconnectCoreInterface : IFileSource
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

        /// <summary>
        /// Internal reference to the class filename.
        /// </summary>
        protected string _filename { get; set; }
        /// <inheritdoc />
        public virtual string Filename {
            get {
                if (string.IsNullOrEmpty(_filename))
                    _filename = $"{ScribanHelperMethods.ToCodeSafe(Name)}.cs";
                return _filename;
            }
            set { _filename = value; }
        }

        public MtconnectCoreInterface(IClass source)
        {
            _class = source;
        }
    }
}
