using MtconnectCore.Standard.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MtconnectCore.Standard.Contracts.Attributes
{
    /// <summary>
    /// An attribute used as a shortcut to deserialize a MTConnect Response Document.
    /// </summary>
    public abstract class MtconnectNodeAttribute : Attribute
    {
        /// <summary>
        /// Reference to the name of the node (element or attribute) name. Supports both <see cref="string"/> and <see cref="Enum"/> references.
        /// </summary>
        public object Name { get; set; }

        /// <summary>
        /// Reference to the XML namespace used in the MTConnect Response Document.
        /// </summary>
        public string XmlNamespace { get; set; }

        /// <summary>
        /// Initializes a <see cref="MtconnectNodeAttribute"/> for automatic processing of a MTConnect node's XML attribute.
        /// </summary>
        /// <param name="name"></param>
        public MtconnectNodeAttribute(object name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets a formatted version of the <see cref="Name"/> based on the provided <paramref name="processor"/>.
        /// </summary>
        /// <param name="processor">Reference to the function used ot format the <see cref="Name"/>.</param>
        /// <returns>Formatted version of the <see cref="Name"/>.</returns>
        public string GetName(MtconnectNodeNameProcessors processor = MtconnectNodeNameProcessors.None)
        {
            string name = Name.ToString();
            if (name.Contains("/")) return name;
            switch (processor)
            {
                case MtconnectNodeNameProcessors.CamelCase:
                    name = EnumHelper.ToCamelCase(name);
                    break;
                case MtconnectNodeNameProcessors.PascalCase:
                    name = EnumHelper.ToPascalCase(name);
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
