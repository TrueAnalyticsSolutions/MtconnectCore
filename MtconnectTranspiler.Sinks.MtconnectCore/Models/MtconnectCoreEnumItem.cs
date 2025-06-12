using MtconnectTranspiler.Sinks.CSharp.Contracts.Interfaces;

namespace MtconnectTranspiler.Sinks.MtconnectCore.Models
{
    public class MtconnectCoreEnumItem : ICloneable
    {
        private const string HELP_URL = "https://model.mtconnect.org/#Enumeration__";

        public string HelpUrl { get; internal set; } = HELP_URL;

        /// <summary>
        /// Reference to any Comments written in the SysML model to be converted into a C# format <c>&lt;summary /&gt;</c>
        /// </summary>
        public string Summary { get; protected set; }

        /// <summary>
        /// Internal string, used by <see cref="Name"/>.
        /// </summary>
        protected string _name { get; set; }
        /// <summary>
        /// <inheritdoc cref="CsharpType.Name"/>
        /// </summary>
        public string Name {
            get => _name;
            set { _name = value; }
        }

        public string NormativeVersion { get; internal set; }

        public string DeprecatedVersion { get; internal set; }

        public MtconnectCoreEnumItem(IClass source)
        {
            _name = source.Name;
            Summary = source.Summary;
            NormativeVersion = source.NormativeVersion;
            DeprecatedVersion = source.DeprecatedVersion;
            HelpUrl = source.HelpUrl;
        }

        public MtconnectCoreEnumItem(IEnumInstance source)
        {
            _name = source.Name;
            Summary = source.Summary;
            NormativeVersion = source.NormativeVersion;
            DeprecatedVersion = source.DeprecatedVersion;
        }

        public object Clone() => this.MemberwiseClone();
    }
}
