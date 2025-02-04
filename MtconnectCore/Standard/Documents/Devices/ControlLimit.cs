using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Devices.Elements;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Devices
{
    /// <summary>
    /// A set of limits used to indicate whether a process variable is stable and in control.
    /// </summary>
    public class ControlLimit : MtconnectNode
    {
        /// <inheritdoc cref="ControlLimitElements.UPPER_LIMIT"/>
        [MtconnectNodeElement(ControlLimitElements.UPPER_LIMIT)]
        public double? UpperLimit { get; set; }

        /// <inheritdoc cref="ControlLimitElements.UPPER_WARNING"/>
        [MtconnectNodeElement(ControlLimitElements.UPPER_WARNING)]
        public double? UpperWarning { get; set; }

        /// <inheritdoc cref="ControlLimitElements.NOMINAL"/>
        [MtconnectNodeElement(ControlLimitElements.NOMINAL)]
        public double? Nominal { get; set; }

        /// <inheritdoc cref="ControlLimitElements.LOWER_WARNING"/>
        [MtconnectNodeElement(ControlLimitElements.LOWER_WARNING)]
        public double? LowerWarning { get; set; }

        /// <inheritdoc cref="ControlLimitElements.LOWER_LIMIT"/>
        [MtconnectNodeElement(ControlLimitElements.LOWER_LIMIT)]
        public double? LowerLimit { get; set; }

        /// <inheritdoc />
        public ControlLimit() : base() { }

        /// <inheritdoc />
        public ControlLimit(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version) { }

    }
}
