using MtconnectCore.Standard.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Contracts.Attributes
{
    public abstract class MtconnectNodeAttribute : Attribute
    {
        public object Name { get; set; }

        public string XmlNamespace { get; set; }

        public MtconnectNodeAttribute(object name)
        {
            Name = name;
        }

        public string GetName(MtconnectNodeNameProcessors processor = MtconnectNodeNameProcessors.None)
        {
            string name = Name.ToString();
            if (name.Contains('/')) return name;
            switch (processor)
            {
                case MtconnectNodeNameProcessors.CamelCase:
                    name = XmlHelper.ToCamelCase(name);
                    break;
                case MtconnectNodeNameProcessors.PascalCase:
                    name = XmlHelper.ToPascalCase(name);
                    break;
                case MtconnectNodeNameProcessors.Lower:
                    name = name.ToLower();
                    break;
                case MtconnectNodeNameProcessors.Upper:
                    name = name.ToUpper();
                    break;
                default:
                    break;
            }
            return name;
        }
    }
}
