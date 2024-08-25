using CaseExtensions;
using MtconnectTranspiler.CodeGenerators.ScribanTemplates;
using MtconnectTranspiler.Sinks.CSharp;
using MtconnectTranspiler.Sinks.CSharp.Contracts.Interfaces;

namespace MtconnectTranspiler.Sinks.MtconnectCore.Models
{
    [ScribanTemplate("MtconnectCore.Enum.scriban")]
    public class MtconnectCoreEnum : IFileSource, ICloneable
    {
        private const string HELP_URL = "https://model.mtconnect.org/#Enumeration__";

        public string HelpUrl { get; internal set; } = HELP_URL;

        public string Namespace { get; internal set; } = "MtconnectCore.Standard.Contracts.Enums";

        public string Name { get; internal set; }

        public System.Type DataType { get; internal set; }

        public System.Type Instance { get; internal set; }

        public string NormativeVersion { get; internal set; }

        public string DeprecatedVersion { get; internal set; }

        public string Summary { get; internal set; }

        public IEnumInstance[] Values { get; internal set; }


        // NOTE: Only used for CATEGORY types that have subTypes.
        public List<MtconnectCoreEnum> SubTypes { get; internal set; } = new List<MtconnectCoreEnum>();
        public Dictionary<string, MtconnectCoreEnum> SubTypesByName => SubTypes?.ToDictionary(o => o.Name, o => o)
            ?? new Dictionary<string, MtconnectCoreEnum>();

        public string FilenameSuffix { get; internal set; } = string.Empty;

        /// <summary>
        /// Internal reference to the class filename.
        /// </summary>
        protected string _filename { get; set; }
        /// <inheritdoc />
        public virtual string Filename {
            get {
                if (string.IsNullOrEmpty(_filename))
                    _filename = $"{ScribanHelperMethods.ToCodeSafe(Name)}{FilenameSuffix}.cs";
                return _filename;
            }
            set { _filename = value; }
        }

        public MtconnectCoreEnum() { }

        public MtconnectCoreEnum(IEnum source)
        {
            HelpUrl = source.HelpUrl;
            Name = source.Name;
            DataType = source.DataType;
            Instance = source.Instance;
            NormativeVersion = source.NormativeVersion;
            DeprecatedVersion = source.DeprecatedVersion;
            Summary = TrimLineBreaks(source.Summary);
            Values = source.Values.ToList().OrderBy(o => o.NormativeVersion).ThenBy(o => o.Name).ToArray();
        }

        public MtconnectCoreEnum(IClass source)
        {
            var resultType = source.Properties.Properties.FirstOrDefault(o => o.Name == "result");
            var isEnum = resultType.Type.GetInterfaces().Contains(typeof(IEnum));// Where(o => o is IEnum);
            IEnum enumInstance = null;
            if (isEnum)
            {
                enumInstance = Activator.CreateInstance(resultType.Type) as IEnum;
            }

            HelpUrl = source.HelpUrl;
            Name = source.Name.Replace("Enum", string.Empty);
            DataType = resultType?.Type ?? typeof(String);
            Instance = enumInstance?.Instance ?? null;
            NormativeVersion = enumInstance?.NormativeVersion ?? resultType?.NormativeVersion ?? "1.0";
            DeprecatedVersion = enumInstance?.DeprecatedVersion ?? resultType?.DeprecatedVersion ?? "1.0";
            Summary = TrimLineBreaks(enumInstance?.Summary ?? resultType?.Summary ?? "");
            if (enumInstance != null)
            {
                Values = enumInstance.Values.ToList().OrderBy(o => o.NormativeVersion).ThenBy(o => o.Name).ToArray();
            } else
            {
                Values = new IEnumInstance[] { };
            }
        }

        public MtconnectCoreEnum(ObservationType source)
        {

            var resultProperty = source.Properties.FirstOrDefault(o => o.Name == "result");
            IEnum resultInstance = null;
            CSharp.Contracts.Interfaces.IEnumInstance[] values = null;
            if (resultProperty?.Type?.GetInterfaces()?.Any(o => o == (typeof(IEnum))) == true)
            {
                resultInstance = Activator.CreateInstance(resultProperty.Type) as IEnum;
                if (resultInstance != null)
                {
                    values = resultInstance.Values.OrderBy(o => o.NormativeVersion).ThenBy(o => o.Name).ToArray();
                }
            }

            HelpUrl = source.HelpUrl;
            Name = source.Name;
            DataType = resultProperty?.Type ?? typeof(string);// typeof(string), // TODO: Get result type
            NormativeVersion = source.Introduced;
            DeprecatedVersion = source.Deprecated;
            Summary = TrimLineBreaks(source.Definition);
            Instance = resultInstance?.Instance;
            SubTypes = source.SubTypes?.Select(o => new MtconnectCoreEnum() {
                HelpUrl = o.HelpUrl,
                Namespace = Namespace,
                Name = o.Name.Substring(o.Name.LastIndexOf(".") + 1),
                DataType = typeof(string),
                NormativeVersion = o.NormativeVersion,
                DeprecatedVersion = o.DeprecatedVersion,
                Summary = TrimLineBreaks(o.Summary),
                Instance = resultInstance?.Instance,
                Values = values
            })?.OrderBy(o => o.NormativeVersion)?.ThenBy(o => o.Name)?.ToList() ?? Enumerable.Empty<MtconnectCoreEnum>().ToList();
            Values = values;
        }

        public object Clone() => this.MemberwiseClone();

        private string TrimLineBreaks(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string[] lineBreakStrings = new string[] { "\r\n", "&#10;" };

            foreach (string lineBreak in lineBreakStrings)
            {
                while (input.StartsWith(lineBreak))
                {
                    input = input.Substring(lineBreak.Length);
                }

                while (input.EndsWith(lineBreak))
                {
                    input = input.Substring(0, input.Length - lineBreak.Length);
                }
            }

            return input;
        }
    }
}
