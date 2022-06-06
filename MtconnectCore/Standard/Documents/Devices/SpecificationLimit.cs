using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// A set of limits defining a range of values designating acceptable performance for a variable.
    /// </summary>
    public class SpecificationLimit : MtconnectNode
    {
        /// <inheritdoc cref="SpecificationLimitElements.UPPER_LIMIT"/>
        [MtconnectNodeElement(SpecificationLimitElements.UPPER_LIMIT)]
        public double? UpperLimit { get; set; }

        /// <inheritdoc cref="SpecificationLimitElements.NOMINAL"/>
        [MtconnectNodeElement(SpecificationLimitElements.NOMINAL)]
        public double? Nominal { get; set; }

        /// <inheritdoc cref="SpecificationLimitElements.LOWER_LIMIT"/>
        [MtconnectNodeElement(SpecificationLimitElements.LOWER_LIMIT)]
        public double? LowerLimit { get; set; }

        /// <inheritdoc />
        public SpecificationLimit() : base() { }

        /// <inheritdoc />
        public SpecificationLimit(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, Constants.DEFAULT_DEVICES_XML_NAMESPACE, version) { }

    }
}
