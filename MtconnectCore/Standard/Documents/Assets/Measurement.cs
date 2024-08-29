using MtconnectCore.Standard.Contracts;
using MtconnectCore.Standard.Contracts.Attributes;
using MtconnectCore.Standard.Contracts.Enums;
using MtconnectCore.Standard.Contracts.Enums.Assets.Attributes;
using System.Xml;

namespace MtconnectCore.Standard.Documents.Assets
{
    /// <inheritdoc />
    public abstract class Measurement : MtconnectNode
    {
        /// <inheritdoc cref="MeasurementAttributes.CODE"/>
        [MtconnectNodeAttribute(MeasurementAttributes.CODE)]
        public string Code { get; set; }

        /// <inheritdoc cref="MeasurementAttributes.MAXIMUM"/>
        [MtconnectNodeAttribute(MeasurementAttributes.MAXIMUM)]
        public double? Maximum { get; set; }

        /// <inheritdoc cref="MeasurementAttributes.MINIMUM"/>
        [MtconnectNodeAttribute(MeasurementAttributes.MINIMUM)]
        public double? Minimum { get; set; }

        /// <inheritdoc cref="MeasurementAttributes.NOMINAL"/>
        [MtconnectNodeAttribute(MeasurementAttributes.NOMINAL)]
        public double? Nominal { get; set; }

        /// <inheritdoc cref="MeasurementAttributes.SIGNIFICANT_DIGITS"/>
        [MtconnectNodeAttribute(MeasurementAttributes.SIGNIFICANT_DIGITS)]
        public double? SignificantDigits { get; set; }

        /// <inheritdoc cref="MeasurementAttributes.UNITS"/>
        [MtconnectNodeAttribute(MeasurementAttributes.UNITS)]
        public string Units { get; set; }

        /// <inheritdoc cref="MeasurementAttributes.NATIVE_UNITS"/>
        [MtconnectNodeAttribute(MeasurementAttributes.NATIVE_UNITS)]
        public string NativeUnits { get; set; }

        public string SubType { get; set; }

        /// <inheritdoc />
        public Measurement() : base() { }

        /// <inheritdoc />
        public Measurement(XmlNode xNode, XmlNamespaceManager nsmgr, MtconnectVersions version) : base(xNode, nsmgr, version)
        {
            SubType = xNode.LocalName;
        }
    }
}
