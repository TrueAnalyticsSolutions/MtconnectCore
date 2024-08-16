using MtconnectTranspiler.CodeGenerators.ScribanTemplates;
using MtconnectTranspiler.Sinks.CSharp.Contracts.Interfaces;

namespace MtconnectTranspiler.Sinks.MtconnectCore.Models
{
    [ScribanTemplate("MtconnectCore.Enum.scriban")]
    public class MtconnectCoreEnum
    {

        public string Name { get; internal set; }

        public System.Type DataType { get; internal set; }

        public System.Type Instance { get; internal set; }

        public string NormativeVersion { get; internal set; }

        public string DeprecatedVersion { get; internal set; }

        public string Summary { get; internal set; }

        public IEnumInstance[] Values { get; internal set; }


        // NOTE: Only used for CATEGORY types that have subTypes.
        public List<MtconnectCoreEnum> SubTypes { get; internal set; } = new List<MtconnectCoreEnum>();

        public MtconnectCoreEnum() { }

        public MtconnectCoreEnum(IEnum source)
        {
            Name = source.Name;
            DataType = source.DataType;
            Instance = source.Instance;
            NormativeVersion = source.NormativeVersion;
            DeprecatedVersion = source.DeprecatedVersion;
            Summary = source.Summary;
            Values = source.Values;
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
            Name = source.Name.Replace("Enum", string.Empty);
            DataType = resultType?.Type ?? typeof(String);
            Instance = enumInstance?.Instance ?? null;
            NormativeVersion = enumInstance?.NormativeVersion ?? resultType?.NormativeVersion ?? "1.0";
            DeprecatedVersion = enumInstance?.DeprecatedVersion ?? resultType?.DeprecatedVersion ?? "1.0";
            Summary = enumInstance?.Summary ?? resultType?.Summary ?? "";
            if (enumInstance != null)
            {
                Values = enumInstance.Values;
            } else
            {
                Values = new IEnumInstance[] { };
            }
        }
    }
}
